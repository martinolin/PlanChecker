using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using PlanChecker;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;

namespace PlanCheckerGroup
{
    /// <summary>
    /// This handles the interface of Group Investigations, it uses a PatientManager to handle the Patients.  The PatientManager in turn has 
    /// a ProtocolManager that deals the actual plan and Protocol. Protocol owns Strucutres that in turn owns Criteria. These Protocols are matched 
    /// against the actual plans and could parhaps also have been called tamplates. 
    /// </summary>
    public partial class GroupInvestigation : Form
    {
        List<string> structures = new List<string>();
        List<string> criterias = new List<string>();
        List<string> planName = new List<string>();
        List<string> printpersonnr = new List<string>();
        List<string> personnr = new List<string>();
        List<List<double>> values = new List<List<double>>();
        List<List<double>> valuesWithNaN = new List<List<double>>();
        List<List<bool>> passed = new List<List<bool>>();
        List<List<bool>> passedWithNaN = new List<List<bool>>();
        int protocol = -1;
        bool haveSetUpDataBase;
        PatientManager patientManager;
        VMS.TPS.Common.Model.API.Application app;
        string user;
        public GroupInvestigation()
        {
            InitializeComponent();
            app = VMS.TPS.Common.Model.API.Application.CreateApplication(null,null);
            user = app.CurrentUser.Id;
            Filtering.Start();
            bool runscript = false;
            if (runscript)
            {
                Patient patient = app.OpenPatientById("test_MO_dosplanering");
                Course course = patient.Courses.First();
                course = patient.Courses.ElementAt(2);
                PlanSetup planSetup = course.PlanSetups.ElementAt(1);

                DateTime? f = patient.CreationDateTime;
                PlanChecker.MainWindow mainWindow = new PlanChecker.MainWindow(patient, course, /*null*/ planSetup, app.CurrentUser);
                mainWindow.ShowDialog();
            }
            else
            {
            }
            Load();
        }
        private void Load()
        {
            labelPlanPicked.BackColor = Color.FromArgb(255, 192, 192);
            labelDataBase.BackColor = Color.FromArgb(255, 192, 192);
            comboBoxPlanPick.Items.Clear();
            protocol = -1;
            haveSetUpDataBase = false;
            dataBaseReminder.SetToolTip(labelDataBase, "");
            patientManager = new PatientManager();
        }
        private void AdjustProtocolListWidth()
        {
            int width = 277;
            foreach (var text in comboBoxPlanPick.Items)
                if (TextRenderer.MeasureText(text.ToString(), comboBoxPlanPick.Font).Width > width)
                    width = TextRenderer.MeasureText(text.ToString(), comboBoxPlanPick.Font).Width;
            comboBoxPlanPick.DropDownWidth = width;
        }
        private void PrintProtocolRecommanded()
        {
            ResultPresentation.Visible = true;
            buttonClearResult.Visible = true;
            ResultPresentation.Columns.Clear();
            List<string> printStructures = patientManager.PrintStructures;
            List<string> printCriterias = patientManager.PrintCriterias;
            List<string> printPersonnrs = patientManager.PrintPersonnrs;
            List<string> printPlanNames = patientManager.PrintPlanNames;
            List<List<double>> values = patientManager.Values;
            if (values.Count == 0)
            {
                ResultPresentation.ColumnCount = 1;
                ResultPresentation.RowCount = 1;
                ResultPresentation[0, 0].Value = "No hits";
            }
            else
            {
                List<List<double>> valuesWithNaN = patientManager.ValuesWithNaN;
                List<List<bool>> passed = patientManager.Passed;
                List<List<bool>> passedWithNaN = patientManager.PassedWithNaN;
                int lengthofCriteriaList = values.First().Count;
                int offsetRows = 2;
                int offsetColumns = 2;
                int columns = values.Count + offsetColumns;
                ResultPresentation.ColumnCount = columns;

                ResultPresentation.RowCount = lengthofCriteriaList + offsetRows;
                for (int i = offsetColumns; i < columns; i++)
                {
                    ResultPresentation[i, 0].Value = printPersonnrs.ElementAt(i - offsetColumns);
                    ResultPresentation[i, 1].Value = printPlanNames.ElementAt(i - offsetColumns);
                    for (int t = offsetRows; t < values.ElementAt(i - offsetColumns).Count + offsetRows; t++)
                    {
                        ResultPresentation[i, t].Value = values.ElementAt(i - offsetColumns).ElementAt(t - offsetRows);
                        if (!passed.ElementAt(i - offsetColumns).ElementAt(t - offsetRows))
                            ResultPresentation[i, t].Style.ForeColor = Color.Red;
                    }
                }
                ResultPresentation.Columns[1].Width = 160;
                for (int t = offsetRows; t < values.First().Count + offsetRows; t++)
                {
                    ResultPresentation[1, t].Value = printCriterias.ElementAt(t - offsetRows);
                    ResultPresentation[0, t].Value = printStructures.ElementAt(t - offsetRows);

                }
            }
            ResultPresentation.ClearSelection();
            Summary.ClearSelection();
        }
        private void Go_Click(object sender, EventArgs e)
        {
            if (CheckValidDataBaseAndProtocol())
            {
                if (radioButtonUseFilter.Checked) // we use filter
                {
                    if (!patientManager.EnsureNoUncertaintyPlanEvalutionForDataBaseFiltering()) //if we have uncertainty plan and tries to evalute these for now we will breake this
                    {
                        MessageBox.Show("Dont use protocols for uncertainty plans when filtering");
                    }
                    else
                    {
                        Filtering.Reset();
                        ResetFilter();
                        IEnumerable<PatientSummary> patients = from ps in app.PatientSummaries
                                                               where Filtering.Serach(ps)
                                                               select ps;
                        foreach (var p in patients)
                        {
                            var hej = app.OpenPatient(p);
                            patientManager.InvestigatePatientWithFixedProtocol(hej);
                            app.ClosePatient();
                            if (Filtering.MatchAGivenNumber)
                                if (Filtering.Done)
                                    break;
                        }
                    }
                }
                else // go with list
                {
                    List<string> l = new List<string>();
                    foreach (string s in listBoxPatient.Items)
                        l.Add(s);
                    AnalyzePatients(l);
                }
                patientManager.GatherStrucutresAndCriteraInfo();
                PrintProtocolRecommanded();
                ExtractStatisticalData();
                patientManager.Reset();
            }
        }
        private void ResetFilter()
        {
            Filtering.CreationLowerAge = dateTimePickerFrom.Value.Date;
            Filtering.CreationUpperAge = dateTimePickerTo.Value.Date;
        }
        private void ExtractStatisticalData()
        {
            panelStatistiaclSummary.Visible = true;
            List<List<double>> ans = patientManager.ExtractStatisticalData();
            if (ans.First().Count > 0)
            {
                int length = ans.First().Count;
                Summary.RowCount = length;
                for (int i = 0; i < length; i++)
                {
                    Summary["Median", i].Value = ans[1].ElementAt(i);
                    Summary["Mean", i].Value = ans[0].ElementAt(i);
                    Summary["STD", i].Value = ans[2].ElementAt(i);
                    Summary["precentagePass", i].Value = ans[3].ElementAt(i) * 100;
                }
            }
        }
        private void AnalyzePatients(List<string> patientssnr)
        {
            try
            {
                foreach (string ssnr in patientssnr)
                {
                    Patient p = app.OpenPatientById(ssnr);
                    patientManager.InvestigatePatientWithFixedProtocol(p);
                    app.ClosePatient();
                }
            }
            catch
            {
                app.ClosePatient();
                MessageBox.Show("Atleast one of your patients does not exists", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxPlanPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlanPick.SelectedIndex != -1)
            {
                protocol = comboBoxPlanPick.SelectedIndex;
                patientManager.SetProtocol(protocol);
                labelPlanPicked.BackColor = Color.FromArgb(128, 255, 128);
            }
            else
                labelPlanPicked.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDataBase();
        }
        private bool OpenDataBase()
        {
            protocol = -1; // -1 means not yet picked what protocol
            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "|*.xml";
            if (odf.ShowDialog() == DialogResult.OK)
            {
                patientManager.ProtocolManager.SetDataBase(odf.FileName);
                foreach (Protocol prot in patientManager.ProtocolManager.DataBase.Protocols)
                {
                    comboBoxPlanPick.Items.Add(prot.GetListName());
                }
                AdjustProtocolListWidth();
                haveSetUpDataBase = true;
                labelDataBase.BackColor = Color.FromArgb(128, 255, 128);
                dataBaseReminder.SetToolTip(labelDataBase, "removes " + patientManager.ProtocolManager.DataBase.PrefixLength.ToString() + " first letter in plan names");
                return true;
            }
            else
                return false;
        }
        private void editDatabasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminSite a = new AdminSite(user, patientManager.ProtocolManager.DataBasePath);
            a.ShowDialog();
            Load();
        }
        bool CheckValidDataBaseAndProtocol()
        {
            if (haveSetUpDataBase)
            {
                if (protocol != -1)
                {
                    return true;
                }
                else
                    MessageBox.Show("please pick a protocol to evaluate");
            }
            else
            {
                MessageBox.Show("please pick a database");
            }
            return false;
        }
        private void controllFilterifSerachingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void radioButtonImportList_CheckedChanged(object sender, EventArgs e)
        {
            panelListPatients.Visible = true;
            panelFilter.Visible = false;
        }
        private void radioButtonUseFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelListPatients.Visible = false;
            panelFilter.Visible = true;
        }
        private void buttonImportPatients_Click(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "Text Files (.txt)|*.txt";
            if (odf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ssnr;
                    StreamReader s = new StreamReader(odf.FileName);
                    while (!s.EndOfStream)
                    {
                        ssnr = s.ReadLine();
                        if (listBoxPatient.Items.Contains(ssnr))
                            MessageBox.Show(ssnr + " is a dublicate, no dublicates allowed");
                        else
                        {
                            listBoxPatient.Items.Add(ssnr);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }
        private void buttonAddSinglePatient_Click(object sender, EventArgs e)
        {
            if (textBoxPatient.Text != "")
                listBoxPatient.Items.Add(textBoxPatient.Text);
        }
        private void buttonRemovePatientFromList_Click(object sender, EventArgs e)
        {
            if (listBoxPatient.SelectedIndex != -1)
                listBoxPatient.Items.RemoveAt(listBoxPatient.SelectedIndex);
        }
        private void buttonPickDataBase_Click(object sender, EventArgs e)
        {
            OpenDataBase();
        }
        private void checkBoxSex_CheckedChanged(object sender, EventArgs e)
        {
            panelSex.Visible = checkBoxSex.Checked;
            Filtering.MatchSex = checkBoxSex.Checked;
        }
        private void checkBoxAge_CheckedChanged(object sender, EventArgs e)
        {
            panelAge.Visible = checkBoxAge.Checked;
            Filtering.MatchAge = checkBoxAge.Checked;
        }
        private void checkBoxSsnr_CheckedChanged(object sender, EventArgs e)
        {
            panelSsnr.Visible = checkBoxSsnr.Checked;
            Filtering.MatchId = checkBoxSsnr.Checked;
        }
        private void checkBoxPlanCreation_CheckedChanged(object sender, EventArgs e)
        {
            panelCreationTime.Visible = checkBoxPlanCreation.Checked;
            Filtering.MatchCreationDate = checkBoxPlanCreation.Checked;
            Filtering.CreationLowerAge = dateTimePickerFrom.Value.Date;
            Filtering.CreationUpperAge = dateTimePickerTo.Value.Date;
        }
        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            Filtering.Sex = "Male";
        }
        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            Filtering.Sex = "Female";
        }
        private void textBoxSsnr_TextChanged(object sender, EventArgs e)
        {
            Filtering.ID = textBoxSsnr.Text;
        }
        private void textBoxAgeFrom_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (double.TryParse(textBoxAgeFrom.Text, out temp))
                Filtering.LowerAge = double.Parse(textBoxAgeFrom.Text);
            else
                if (textBoxAgeFrom.TextLength - 1 > 0)
                    textBoxAgeFrom.Text = textBoxAgeFrom.Text.Substring(0, textBoxAgeFrom.TextLength - 1);
        }
        private void textBoxAgeTo_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (double.TryParse(textBoxAgeTo.Text, out temp))
                Filtering.UpperAge = double.Parse(textBoxAgeTo.Text);
            else
                if (textBoxAgeTo.TextLength - 1 > 0)
                    textBoxAgeTo.Text = textBoxAgeTo.Text.Substring(0, textBoxAgeTo.TextLength - 1);
        }
        private void checkBoxNumberOfPatients_CheckedChanged(object sender, EventArgs e)
        {
            Filtering.MatchAGivenNumber = checkBoxNumberOfPatients.Checked;
            textBoxNumberOfPatients.Visible = checkBoxNumberOfPatients.Checked;
        }
        private void textBoxNumberOfPatients_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBoxNumberOfPatients.Text, out temp))
                Filtering.Hits = int.Parse(textBoxNumberOfPatients.Text);
            else
                if (textBoxNumberOfPatients.TextLength - 1 > 0)
                    textBoxNumberOfPatients.Text = textBoxNumberOfPatients.Text.Substring(0, textBoxNumberOfPatients.TextLength - 1);
        }
        private void buttonClearResult_Click(object sender, EventArgs e)
        {
            patientManager.Reset();
            ResultPresentation.Columns.Clear();
            Summary.Rows.Clear();
        }
        private void GroupInvestigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            app.Dispose();
        }
    }
}

