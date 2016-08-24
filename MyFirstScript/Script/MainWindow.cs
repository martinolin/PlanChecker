using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using System.Diagnostics;
namespace PlanChecker
{
    /// <summary>
    /// This is the class that is used for the script, it handles the displaying but still uses the protocolManager do to the work
    /// </summary>
    public partial class MainWindow : Form
    {
        private int forceThisStrucutreEclipseStructure;
        ProtocolManager protocolManager;
        Course course = null;
        PlanSetup planSetup = null;
        PlanSum planSum = null;
        private bool dense = true; //viewing mode is dense as opose to lose
        string userId;
        public MainWindow(Patient patient, Course inCourse, PlanSetup inplanSetup /*, PlanSum inPlanSum*/, User user)
        {
            //orders of Criterias will matter for the sorting of criteria priority, so unless you add a sort function dont add new ones through xml..
            course = inCourse;
            InitializeComponent();
            userId = user.Id.ToString();
            ResultatPresentation.MouseClick += new MouseEventHandler(dataGridView1_Click);
            this.KeyDown += new KeyEventHandler(KeyShortCuts);
            comboBoxPlanPick.KeyDown += new KeyEventHandler(combobox2_KeyPress);
            comboBoxPlanPick.KeyDown += (s, e) => e.Handled = true;
            comboBoxPlanPick.KeyUp += (s, e) => e.Handled = true;
            comboBoxPlanPick.KeyPress += (s, e) => e.Handled = true;
            comboBox2.KeyDown += (s, e) => e.Handled = true;
            comboBox2.KeyUp += (s, e) => e.Handled = true;
            comboBox2.KeyPress += (s, e) => e.Handled = true;
            comboBoxSortmode.KeyDown += (s, e) => e.Handled = true;
            comboBoxSortmode.KeyUp += (s, e) => e.Handled = true;
            comboBoxSortmode.KeyPress += (s, e) => e.Handled = true;
            if (patient != null)
            {
                labelPatientId.Text = "Patient id is " + patient.Id;
                planSetup = inplanSetup;

                protocolManager = new ProtocolManager();
                protocolManager.UseScriptDataBase();
                if (!SettingsScript.Default.accessAdmin)
                {
                    buttonEdit.Visible = false;
                    buttonHelp.Location = new Point(712, 12);
                }
                //Do we have a planSetup or planSum active?
                if (planSetup == null) //its a planSum
                {
                    if (course.PlanSums.Count() == 1) //its 1 planSum
                    {
                        planSum = course.PlanSums.First();
                        string labelName = "";
                        foreach (PlanSetup p in planSum.PlanSetups)
                            labelName += p.Id.ToString() + " + ";
                        if (labelName.Length > 0)
                            labelName = labelName.Substring(0, labelName.Length - 2);
                        else
                            labelName = "empty Plan Sum";
                        labelPlanid.Text = labelName;
                        try
                        {
                            protocolManager.ChangeProtocol(planSum);
                            protocolManager.AnalyzeProtocol(planSum);
                            PrintProtocol();
                            AutoSizeMainWindow();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, "this plan has atleast one plane with unknown fractions, try another plan");
                            labelPlanid.Text = "click here";
                        }
                    }
                    else //dont know what planSum
                    {
                        MessageBox.Show(this, "Please chose what plan to investigate by clicking on the upper middle text (\"click here\")");
                        labelPlanid.Text = "click here";
                    }
                }
                else //its a planSetup
                {
                    labelPlanid.Text = "Investigating " + inplanSetup.Id;
                    protocolManager.ChangeProtocol(planSetup);
                    protocolManager.AnalyzeProtocol(planSetup);
                    PrintProtocol();
                    AutoSizeMainWindow();
                }
                foreach (Protocol prot in protocolManager.DataBase.Protocols)
                {
                    comboBoxPlanPick.Items.Add(prot.GetListName());
                }
                if (protocolManager.Protocol != null)
                    comboBoxPlanPick.SelectedIndex = comboBoxPlanPick.Items.IndexOf(protocolManager.Protocol.GetListName()) == -1 ? comboBoxPlanPick.Items.IndexOf("unknown") : comboBoxPlanPick.Items.IndexOf(protocolManager.Protocol.GetListName());
            }
            else
            {
                labelPatientId.Text = "No patient selected";
                this.Close();
            }

            this.ActiveControl = buttonHelp;
            this.comboBoxPlanPick.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        }
        private void Highlighter()
        {
            var highlightList = protocolManager.DataBase.HighLight;
            int row = 0;
            Font font = new System.Drawing.Font("Arial", 10);
            foreach (Structure structure in protocolManager.Protocol.Structures)
            {
                foreach (Highlight highlight in protocolManager.DataBase.HighLight)
                {
                    if (structure.Name == highlight.Name)
                    {
                        DataGridViewCellStyle color = new DataGridViewCellStyle() { ForeColor = highlight.Color, BackColor = ResultatPresentation.Rows[row].Cells[0].Style.BackColor, Font = font };
                        ResultatPresentation.Rows[row].Cells[0].Style = color;
                    }
                }
                row = row + (dense ? 2 : 3);
            }
        }
        private void dataGridView1_Click(object sender, MouseEventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            if (e.Button == MouseButtons.Left)
            {
                if (ResultatPresentation.HitTest(e.X, e.Y).ColumnIndex == 0)
                {
                    List<string> temp = new List<string>();
                    foreach (VMS.TPS.Common.Model.API.Structure eclipseStructure in planSetup == null ? planSum.StructureSet.Structures : planSetup.StructureSet.Structures)
                    {
                        temp.Add(eclipseStructure.Id.ToString());
                    }
                    temp.Sort();
                    foreach (string s in temp)
                        menu.Items.Add(s).Name = s;


                    menu.Items.Add("none \"-\"").Name = "-";
                    ResultatPresentation.HitTest(e.X, e.Y).RowIndex.ToString();
                    ResultatPresentation.HitTest(e.X, e.Y).ColumnIndex.ToString();

                    if (ResultatPresentation.HitTest(e.X, e.Y).RowIndex % (dense ? 2 : 3) == 0)
                    {
                        forceThisStrucutreEclipseStructure = ResultatPresentation.HitTest(e.X, e.Y).RowIndex / (dense ? 2 : 3);
                        ResultatPresentation[ResultatPresentation.HitTest(e.X, e.Y).ColumnIndex, ResultatPresentation.HitTest(e.X, e.Y).RowIndex + 1].Selected = true;
                        menu.Show(ResultatPresentation, new Point(e.X, e.Y));
                    }
                    else
                        if (dense)
                        {
                            ResultatPresentation[ResultatPresentation.HitTest(e.X, e.Y).ColumnIndex, ResultatPresentation.HitTest(e.X, e.Y).RowIndex - 1].Selected = true;
                            forceThisStrucutreEclipseStructure = (ResultatPresentation.HitTest(e.X, e.Y).RowIndex - 1) / 2;
                            menu.Show(ResultatPresentation, new Point(e.X, e.Y));
                        }
                        else
                            if (ResultatPresentation.HitTest(e.X, e.Y).RowIndex % 3 == 1)
                            {
                                ResultatPresentation[ResultatPresentation.HitTest(e.X, e.Y).ColumnIndex, ResultatPresentation.HitTest(e.X, e.Y).RowIndex - 1].Selected = true;
                                forceThisStrucutreEclipseStructure = (ResultatPresentation.HitTest(e.X, e.Y).RowIndex - 1) / 3;
                                menu.Show(ResultatPresentation, new Point(e.X, e.Y));
                            }

                    menu.ItemClicked += new ToolStripItemClickedEventHandler(ForceEclipseStructureStructureAssignment);
                }
            }
        }
        private void AnalyzeProtocol(int protocolIndex)
        {
            if (protocolManager.DataBase.GetProtocol(protocolIndex).Dose == -1) // its a plansum
            {
                protocolManager.AnalyzeProtocol(planSum);
            }
            else
            {
                protocolManager.AnalyzeProtocol(planSetup);
            }
        }
        private void ForceEclipseStructureStructureAssignment(object sender, ToolStripItemClickedEventArgs arg)
        {
            if (arg.ClickedItem.Name == "-")
            {
                protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure].NameCertainty = protocolManager.NameCertaintyThreashold - .00001;
                if (planSetup != null)
                    protocolManager.EvaluateProtocolStrucutre(planSetup, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure], null);
                else
                    protocolManager.EvaluatePlanSumCriterion(planSum, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure], null);
            }
            else
            {
                protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure].EclipsStrucureName = arg.ClickedItem.Name.ToString();

                protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure].NameCertainty = 1;
                if (planSetup != null)
                    protocolManager.EvaluateProtocolStrucutre(planSetup, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure], protocolManager.GetEclipseStructure(planSetup.StructureSet, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure].EclipsStrucureName));
                else
                    protocolManager.EvaluatePlanSumCriterion(planSum, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure], protocolManager.GetEclipseStructure(planSum.StructureSet, protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure].EclipsStrucureName));
            }
            PrintProtocolRow(forceThisStrucutreEclipseStructure * (dense ? 2 : 3), protocolManager.Protocol.Structures[forceThisStrucutreEclipseStructure]);
            AutoSizeMainWindow();
        }
        private void PrintProtocol()
        {
            ResultatPresentation.Rows.Clear();
            ResultatPresentation.Refresh();
            ResultatPresentation.ColumnCount = protocolManager.Protocol.MaxNumberOfCriteras;
            ResultatPresentation.RowCount = (protocolManager.Protocol.NumberOfStrucutres) * (dense ? 2 : 3);
            labelUpdate.Text = "Protocol last updated: " + protocolManager.Protocol.LastUpdated;
            int row = 0;
            int row2 = 0;
            int column = 0;
            bool passed = true;
            Font font = new System.Drawing.Font("Arial", 10);
            DataGridViewCellStyle green = new DataGridViewCellStyle() { BackColor = Color.FromArgb(204, 255, 204), Font = font };
            DataGridViewCellStyle red = new DataGridViewCellStyle() { BackColor = Color.FromArgb(255, 102, 102), Font = font };
            DataGridViewCellStyle orange = new DataGridViewCellStyle() { BackColor = Color.FromArgb(255, 140, 0), Font = font };
            DataGridViewCellStyle fontGreen = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(0, 142, 0), Font = font };
            DataGridViewCellStyle fontRed = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(255, 102, 102), Font = font };
            DataGridViewCellStyle fontOrange = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(255, 0, 0), Font = font };

            foreach (Structure structure in protocolManager.Protocol.Structures)
            {
                if (structure.NameCertainty > protocolManager.NameCertaintyThreashold) //we will evalute else not
                {
                    ResultatPresentation.Rows[row].Cells[0].Value = structure.Name;
                    column = 0;
                    row = row + (dense ? 0 : 1);
                    row2 = row + 1;

                    passed = true;
                    if (structure.NameCertainty == 1)
                    {
                        ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Style = fontGreen;
                        ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Value = "as " + structure.EclipsStrucureName;
                    }
                    else
                    {
                        ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Style = fontRed;
                        ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Value = "as " + structure.EclipsStrucureName + " ?";
                    }
                    //
                    foreach (Criterion criterion in structure.Criteria)
                    {
                        ResultatPresentation.Rows[row].Cells[++column].Value = criterion.ListName;
                        if (criterion.Passed)
                        {
                            ResultatPresentation.Rows[row].Cells[column].Style = green;
                            ResultatPresentation.Rows[row2].Cells[column].Style = green;
                            ResultatPresentation.Rows[row2].Cells[column].Value = criterion.ReadValue;
                        }
                        else
                        {
                            if (passed) //this assumes criterions are orderd,
                                structure.HealthStatus = criterion.Priority;
                            passed = false;
                            ResultatPresentation.Rows[row].Cells[column].Style = red;
                            ResultatPresentation.Rows[row2].Cells[column].Style = red;
                            ResultatPresentation.Rows[row2].Cells[column].Value = criterion.ReadValue;
                        }
                    }
                    row = row + (dense ? 0 : -1);
                    if (passed)
                        ResultatPresentation.Rows[row].Cells[0].Style = green;
                    else
                        ResultatPresentation.Rows[row].Cells[0].Style = red;
                    row = row + (dense ? 0 : 1);
                }
                else
                {
                    ResultatPresentation.Rows[row].Cells[0].Value = structure.Name;
                    ResultatPresentation.Rows[row].Cells[0].Style = orange;
                    ResultatPresentation.Rows[row + 1].Cells[0].Value = "as ?";
                    column = 0;
                    row = row + (dense ? 0 : 1);
                    row2 = row + 1;


                    string letterSymbolizeNotNormalCriteria;
                    if (protocolManager.Protocol.Dose == -1) //flag for plansumprotocol
                        letterSymbolizeNotNormalCriteria = "P";
                    else
                        letterSymbolizeNotNormalCriteria = "U";

                    foreach (Criterion criterion in structure.Criteria)
                    {

                        if (criterion.PartPlan != 0)
                            ResultatPresentation.Rows[row].Cells[++column].Value = criterion.Priority + ": " + letterSymbolizeNotNormalCriteria + " " + criterion.Name;
                        else
                            ResultatPresentation.Rows[row].Cells[++column].Value = criterion.Priority + ": " + criterion.Name;

                        ResultatPresentation.Rows[row].Cells[column].Style = orange;
                        ResultatPresentation.Rows[row2].Cells[column].Value = "-";
                    }
                }
                row = row + 2;
            }
            Highlighter();
        }
        private void PrintProtocolRow(int row, Structure structure)
        {
            row = row + (dense ? 0 : 1);
            bool passed = true;
            int row2 = row + 1;
            int column = 0;
            Font font = new System.Drawing.Font("Arial", 10);
            DataGridViewCellStyle green = new DataGridViewCellStyle() { BackColor = Color.FromArgb(204, 255, 204), Font = font };
            DataGridViewCellStyle red = new DataGridViewCellStyle() { BackColor = Color.FromArgb(255, 102, 102), Font = font };
            DataGridViewCellStyle orange = new DataGridViewCellStyle() { BackColor = Color.FromArgb(255, 140, 0), Font = font };
            DataGridViewCellStyle fontGreen = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(0, 142, 0), Font = font };
            DataGridViewCellStyle fontRed = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(255, 102, 102), Font = font };
            DataGridViewCellStyle fontOrange = new DataGridViewCellStyle() { ForeColor = Color.FromArgb(255, 0, 0), Font = font };
            structure.HealthStatus = 1000;
            ResultatPresentation.ColumnCount = protocolManager.Protocol.MaxNumberOfCriteras;
            if (structure.NameCertainty > protocolManager.NameCertaintyThreashold) //we will evalute else not
            {
                if (structure.NameCertainty == 1)
                {
                    ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Style = fontGreen;
                    ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Value = "as " + structure.EclipsStrucureName;
                }
                else
                {
                    ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Style = fontRed;
                    ResultatPresentation.Rows[row + (dense ? 1 : 0)].Cells[0].Value = "as " + structure.EclipsStrucureName + " ?";
                }
                //
                foreach (Criterion criterion in structure.Criteria)
                {
                    ResultatPresentation.Rows[row].Cells[++column].Value = criterion.ListName;
                    if (criterion.Passed)
                    {
                        ResultatPresentation.Rows[row].Cells[column].Style = green;
                        ResultatPresentation.Rows[row2].Cells[column].Style = green;
                        ResultatPresentation.Rows[row2].Cells[column].Value = criterion.ReadValue;
                    }
                    else
                    {
                        if (passed) //this assumes criterions are orderd, if u write em in from xml, they must be ordered first. we could do it, but we dont atm.
                            structure.HealthStatus = criterion.Priority;
                        passed = false;
                        ResultatPresentation.Rows[row].Cells[column].Style = red;
                        ResultatPresentation.Rows[row2].Cells[column].Style = red;
                        ResultatPresentation.Rows[row2].Cells[column].Value = criterion.ReadValue;
                    }
                }
                row = row + (dense ? 0 : -1);
                if (passed)
                    ResultatPresentation.Rows[row].Cells[0].Style = green;
                else
                    ResultatPresentation.Rows[row].Cells[0].Style = red;
                row = row + (dense ? 0 : 1);
            }
            else
            {
                structure.HealthStatus = 999;
                ResultatPresentation.Rows[row].Cells[0].Value = structure.Name;
                ResultatPresentation.Rows[row].Cells[0].Style = orange;
                ResultatPresentation.Rows[row + 1].Cells[0].Value = "as ?";
                column = 0;
                row = row + (dense ? 0 : 1);
                row2 = row + 1;
                DataGridViewCellStyle white = new DataGridViewCellStyle() { BackColor = Color.White };
                string letterSymbolizeNotNormalCriteria;
                if (protocolManager.Protocol.Dose == -1) //flag for plansumprotocol
                    letterSymbolizeNotNormalCriteria = "P";
                else
                    letterSymbolizeNotNormalCriteria = "U";
                foreach (Criterion criterion in structure.Criteria)
                {
                    if (criterion.PartPlan != 0)
                        ResultatPresentation.Rows[row].Cells[++column].Value = criterion.Priority + ": " + letterSymbolizeNotNormalCriteria + " " + criterion.Name;
                    else
                        ResultatPresentation.Rows[row].Cells[++column].Value = criterion.Priority + ": " + criterion.Name;

                    ResultatPresentation.Rows[row].Cells[column].Style = orange;
                    ResultatPresentation.Rows[row2].Cells[column].Value = "-";
                    ResultatPresentation.Rows[row2].Cells[column].Style = white;

                }
            }
            Highlighter();
        }
        private void AutoSizeMainWindow()
        {
            if (protocolManager.Protocol.Structures.Length > 0)
            {
                for (int i = 1; i < protocolManager.Protocol.MaxNumberOfCriteras; i++)
                { ResultatPresentation.Columns[i].Width = 160; }
                if (ResultatPresentation.Columns[0].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true) > 160)
                    ResultatPresentation.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                {
                    ResultatPresentation.Columns[0].Width = 160;
                    ResultatPresentation.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                int maxWidth = Screen.PrimaryScreen.Bounds.Width;
                if (ResultatPresentation.Columns[0].Width + ResultatPresentation.ColumnCount * 160 > 806)
                {
                    if (ResultatPresentation.Columns[0].Width + ResultatPresentation.ColumnCount * 160 + 50 + this.Left > Screen.PrimaryScreen.Bounds.Width)
                        this.Width = Screen.PrimaryScreen.Bounds.Width - this.Left;
                    else
                        this.Width = ResultatPresentation.Columns[0].Width + ResultatPresentation.ColumnCount * 160 + 50;
                }
                else
                    this.Width = 806;

                if (ResultatPresentation.Rows[0].Height * ResultatPresentation.RowCount > 528)
                {
                    if (ResultatPresentation.Rows[0].Height * ResultatPresentation.RowCount + 200 + this.Top > Screen.PrimaryScreen.Bounds.Height)
                        this.Height = Screen.PrimaryScreen.Bounds.Height - this.Top - 40;
                    else
                        this.Height = ResultatPresentation.Rows[0].Height * ResultatPresentation.RowCount + 200;
                }
                else this.Height = 528;
            }
            else
            {
                this.Width = 806;
                this.Height = 528;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // change plan 
        {
            ResultatPresentation.Rows.Clear();
            ResultatPresentation.Refresh();
            bool print = true;
            if (comboBoxPlanPick.SelectedItem.ToString() != "")
            {
                protocolManager.SetProtocol(comboBoxPlanPick.SelectedIndex);
                if (protocolManager.Protocol.Dose != -1)
                {
                    if (planSetup != null)
                    {
                        protocolManager.MatchStrucutres(planSetup);
                        protocolManager.AnalyzeProtocol(planSetup);
                    }
                    else
                    {
                        MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "pick a plan first");
                        print = false;
                    }
                }
                else
                {
                    if (planSetup == null)
                    {
                        if (planSum != null)
                        {
                            protocolManager.MatchInternalsInPlanSum(planSum);
                            protocolManager.MatchStrucutres(planSum);
                            protocolManager.AnalyzeProtocol(planSum);
                        }
                        else
                        {
                            print = false;
                            MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "pick a Plan Sum first");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "pick a plan sum first");
                        print = false;
                    }
                }
            }
            if (print)
            {
                PrintProtocol();
                AutoSizeMainWindow();
                ResultatPresentation.ClearSelection();
            }
        }
        private void AdjustProtocolListWidth()
        {
            int width = 277;
            foreach (var text in comboBoxPlanPick.Items)
                if (TextRenderer.MeasureText(text.ToString(), comboBoxPlanPick.Font).Width > width)
                    width = TextRenderer.MeasureText(text.ToString(), comboBoxPlanPick.Font).Width;
            comboBoxPlanPick.DropDownWidth = width;
            comboBoxPlanPick.Width = width;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdminSite adminSite = new AdminSite(userId, protocolManager.DataBasePath);
            adminSite.ShowDialog();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //dense or lose?=
        {
            if (comboBox2.SelectedIndex == 0)
                dense = true;
            else
                dense = false;
            if (protocolManager.Protocol != null)
            {
                PrintProtocol();
            }
            AutoSizeMainWindow();
            ResultatPresentation.ClearSelection();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // sort mode
        {
            switch (comboBoxSortmode.SelectedIndex)
            {
                case 0: protocolManager.SortStructureNormalOrder();
                    break;
                case 1:
                    protocolManager.SortStructureNameCertainty();
                    break;
                case 2:
                    protocolManager.SortStrucutreHealthStatus();
                    break;
                default:
                    MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "corrupted data, dont use this program");
                    break;
            }
            if (protocolManager.Protocol != null)
            {
                PrintProtocol();
                ResultatPresentation.ClearSelection();
            }
        }
        private void KeyShortCuts(object sender, KeyEventArgs e)
        {

            e.Handled = true;
            switch (e.KeyValue)
            {
                case 52:
                    comboBox2.SelectedIndex = (comboBox2.SelectedIndex == 0) ? 1 : 0;
                    break;
                case 51:
                    comboBoxSortmode.SelectedIndex = 2;
                    break;
                case 50:
                    comboBoxSortmode.SelectedIndex = 1;
                    break;
                case 49:
                    comboBoxSortmode.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            return;
        }
        private void combobox2_KeyPress(object sender, KeyEventArgs e) //remove this!?
        {
            e.Handled = true;
            MessageBox.Show("hallå");
            return;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            int i = 0;
            int t = 0;
            foreach (PlanSetup pSetup in course.PlanSetups)
            {
                menu.Items.Add(pSetup.Id.ToString()).Name = i.ToString();
                i++;
            }
            foreach (PlanSum pSum in course.PlanSums)
            {
                menu.Items.Add(pSum.Id.ToString()).Name = (i + t).ToString();
                t++;
            }
            menu.Show(this, new Point(labelPlanid.Location.X, labelPlanid.Location.Y));
            menu.ItemClicked += new ToolStripItemClickedEventHandler(ChangePlanUnderInvestigation);
        }
        private void ChangePlanUnderInvestigation(object sender, ToolStripItemClickedEventArgs arg)
        {
            ResultatPresentation.Rows.Clear();
            ResultatPresentation.Refresh();
            int index = int.Parse(arg.ClickedItem.Name);
            if (index >= (int)course.PlanSetups.Count())
            {
                planSetup = null;
                planSum = course.PlanSums.ElementAt(index - (int)course.PlanSetups.Count());
                labelPlanid.Text = protocolManager.ChangeProtocol(planSum);
                int removethis = (int)course.PlanSetups.Count();
                if (protocolManager.Protocol != null && protocolManager.Protocol.GetListName().Equals(comboBoxPlanPick.SelectedText))
                {
                    protocolManager.AnalyzeProtocol(planSum);
                }
                else
                    MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "Please also pick a protocol");// serach for a plansum protocol instead.
            }
            else
            {
                planSetup = course.PlanSetups.ElementAt(index);

                labelPlanid.Text = "Invetigating " + planSetup.Id;
                protocolManager.ChangeProtocol(planSetup);
                if (protocolManager.Protocol.GetListName().Equals(comboBoxPlanPick.SelectedText)) // else combobox will update.
                {
                    protocolManager.AnalyzeProtocol(planSetup);
                }
            }
            comboBoxPlanPick.SelectedIndex = protocolManager.Protocol.Name == null ? comboBoxPlanPick.Items.IndexOf("unknown") : comboBoxPlanPick.Items.IndexOf(protocolManager.Protocol.GetListName());
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            ResultatPresentation.ClearSelection();
            this.Load -= MainWindow_Load;
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dense)
            {
                if (e.RowIndex % 2 == 0)
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                else
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                e.Paint(e.ClipBounds, e.PaintParts);

                Pen pen = new Pen(ResultatPresentation.GridColor);
                pen.DashPattern = new float[] { 1f, 2f, 2f };
                e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                e.Handled = true;
            }
        }
    }
}
