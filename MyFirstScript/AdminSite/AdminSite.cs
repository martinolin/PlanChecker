using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using VMS.TPS.Common.Model.API;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace PlanChecker
{
    public partial class AdminSite : Form
    {
        string user;
        string dataBaseFullName="";
        public AdminSite(string inUser,string databaseName) //remove copy of dataBase open new session in here.
        {
            dataBaseFullName = databaseName;
            user = inUser;
            if (dataBaseFullName!=null)
             dataBase = Serialization.XMLFileDeserialize<DataBase>(databaseName);
            else
                CreateNewDataBase();
            InitializeComponent();
            foreach (String protocolName in dataBase.GetProtocolListNames())
            {
                listBoxProtocols.Items.Add(protocolName);
            }
            listBoxStruct.Items.Clear();
            listBoxCrit.Items.Clear();
            buttonAddCriteria.Enabled = false;
            buttonAddProtocol.Enabled = false;
        }
        private void UseScriptDataBase()
        {

        }
        private void listBoxProtocols_SelectedIndexChanged(object sender, EventArgs e) // select a protocol and show strucutres 
        {
            if (listBoxProtocols.SelectedIndex != -1)
            {
                UpdateDataAndRewriteLists(2);
                CheckEnableAddCriteriaButtonStatus();
                comboBoxPlanSumPart.Items.Clear();
                if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose == -1)
                {
                    labelHelpPickPlan.Text = "Part of plan sum:";
                    comboBoxPlanSumPart.Items.Add("Plan Sum");
                    for (int i = 1; i < ((PlanSumProtocol)dataBase.GetProtocol(listBoxProtocols.SelectedIndex)).AllSubFractions.Length+1; i++)
                        comboBoxPlanSumPart.Items.Add("Only plan nr " + (i).ToString());
                }
                else
                {
                    labelHelpPickPlan.Text = "Type of plan:";
                    comboBoxPlanSumPart.Items.Add("Normal");
                    comboBoxPlanSumPart.Items.Add("Uncertainty");
                }
                comboBoxPlanSumPart.SelectedIndex = 0;
                if (listBoxProtocols.SelectedIndex != -1)
                    labelProtocolCreatedBy.Text = "created by " + dataBase.GetProtocol(listBoxProtocols.SelectedIndex).CreatedBy + " updated: "+ dataBase.GetProtocol(listBoxProtocols.SelectedIndex).LastUpdated;
                else
                    labelProtocolCreatedBy.Text = "";
            }
        }

        private void buttonRemoveProtocol_Click(object sender, EventArgs e)//remove a protocol
        {
            if (listBoxProtocols.SelectedIndex != -1 && listBoxProtocols.SelectedItem.ToString() != "unknown")
            {
                dataBase.RemoveProtocol(listBoxProtocols.SelectedIndex);
                int currentIndex = listBoxProtocols.SelectedIndex;
                UpdateDataAndRewriteLists(1);

                if (currentIndex > listBoxProtocols.Items.Count - 1)
                    listBoxProtocols.SelectedIndex = currentIndex - 1;
                else
                    if (listBoxProtocols.Items.Count > 0)
                        listBoxProtocols.SelectedIndex = currentIndex;
                    else
                    { }
                subDoses.Clear();
                subFractions.Clear();
                CheckEnableAddProtocolButtonStatus();
                UpdateDateOfUpdateDataBase();
            }
        }
        private void buttonAddProtcol_Click(object sender, EventArgs e) //add protocol
        {
            panelSubPlans.Visible = false;
            if (textBoxProtocolName.Text != "" && textBoxProtocolName.Text != "unknown")
            {
                Protocol newPortocol;
                if (radioButtonSinglePlan.Checked)
                    newPortocol = new Protocol(textBoxProtocolName.Text.ToString(), double.Parse(textBoxDosePerFraction.Text), int.Parse(textBoxFractions.Text));
                else
                {
                    newPortocol = new PlanSumProtocol(textBoxProtocolName.Text.ToString(), subFractions, subDoses); //-1 flag for PlanSumProtocol
                    resetAddPlanSumProtocol();
                }
                if (listBoxProtocols.FindStringExact(newPortocol.GetListName()) == -1) //dont allow copys
                {
                    newPortocol.CreatedBy = user;
                    newPortocol.LastUpdated = DateTime.Now.Date.ToShortDateString();
                    UpdateDateOfUpdateDataBase();
                    dataBase.AddProtocol(newPortocol);
                    
                    dataBase.SortProtocolsAlpahbetic(); // when adding protocols, we also sort protocols. but we need this to not lose structs .. hm
                    UpdateDataAndRewriteLists(1);
                    listBoxProtocols.SelectedIndex = listBoxProtocols.FindStringExact(newPortocol.GetListName());
                }
                else
                    MessageBox.Show("the protocol " + textBoxProtocolName.Text + " already exists");
            }
            else
                MessageBox.Show("There can only be one unknown plan");
        }
        private void listBoxStructures_SelectedIndexChanged(object sender, EventArgs e) // select a strucutre
        {
            UpdateDataAndRewriteLists(3); //updates the criterion list
            if (listBoxStruct.SelectedIndex != -1)
                labelStrucutreCreatedBy.Text = "created by " + dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).CreatedBy;
            else
                labelStrucutreCreatedBy.Text = "";
            CheckEnableAddCriteriaButtonStatus();
        }
        private void buttonAddStructure_Click(object sender, EventArgs e) //add strucutre
        {
            if (textBoxNewStruct.Text != "" && textBoxNewStruct.Text != "-")
            {
                if (listBoxProtocols.SelectedIndex != -1)
                {
                    if (listBoxStruct.FindStringExact(textBoxNewStruct.Text.ToString()) == -1) //tillåt ej dubbletter
                    {
                        Structure newStructure = new Structure(textBoxNewStruct.Text.ToString());
                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).AddStrucutre(textBoxNewStruct.Text.ToString(),user); //adds to dataBase
                        listBoxStruct.Items.Add(textBoxNewStruct.Text.ToString());
                        listBoxStruct.SelectedIndex = listBoxStruct.FindStringExact(textBoxNewStruct.Text.ToString());
                        UpdateDateOfUpdate();
                        UpdateDataAndRewriteLists(3);
                    }
                    else
                        MessageBox.Show("the structure " + textBoxNewStruct.Text + " already exists");
                }
                else MessageBox.Show("please choose what to what protocol first");
            }

        }

        private void buttonRemoveStrucutre_Click(object sender, EventArgs e) // remove structure
        {
            if (listBoxStruct.SelectedIndex != -1)
            {
                int currentIndex = listBoxStruct.SelectedIndex;
                dataBase.GetProtocol(listBoxProtocols.SelectedIndex).RemoveStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem));
                UpdateDateOfUpdateDataBase();
                UpdateDataAndRewriteLists(2);

                if (currentIndex > listBoxStruct.TopIndex)
                    listBoxStruct.SelectedIndex = currentIndex - 1;
                else
                    if (listBoxStruct.Items.Count > 0)
                        listBoxStruct.SelectedIndex = currentIndex;
                    else
                    { }
            }

        }
        private DataBase dataBase = new DataBase();
        private List<int> subFractions = new List<int>();
        private List<double> subDoses = new List<double>();

        private void buttonAddCriterion_Click(object sender, EventArgs e) //addCriteria
        {
            //do we have a plan?
            if (listBoxProtocols.SelectedIndex == -1)
                MessageBox.Show("no protocol chosen, plz add?");
            else
            {   //do we have a structure?
                if (listBoxStruct.SelectedIndex == -1)
                    MessageBox.Show("no structure chosen, plz add?");
                else
                    if (int.Parse(textBoxPriority.Text) < 999 && int.Parse(textBoxPriority.Text) > -999)
                    {
                        {
                            try
                            {
                                string typeOfCriteria = comboBoxType.SelectedItem.ToString();
                                switch (typeOfCriteria)
                                {

                                    case "Dxx":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                            if (checkBoxRelativeOrAbsVoulme.Checked) //volume  =abs
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveDoseAbsAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictDoseAbsAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }
                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowDoseAbsAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictDoseAbsAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }
                                            }
                                            else //Dose Abs Volume Rel
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveDoseAbsAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictDoseAbsAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }
                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowDoseAbsAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictDoseAbsAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                            }
                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (checkBoxRelativeOrAbsVoulme.Checked) //volume  =abs
                                                {
                                                    if (radioButtonAbove.Checked) // its an upper
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveDoseRelAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictDoseRelAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    }
                                                    else // its an lower
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowDoseRelAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictDoseRelAtVolumeAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    }
                                                }
                                                else // volume = rel
                                                {
                                                    if (radioButtonAbove.Checked) // its an upper
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveDoseRelAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictDoseRelAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                    }
                                                    else // its an lower
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowDoseRelAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictDoseRelAtVolumeRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                    }
                                                }
                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                        }
                                        break;
                                    case "Vxx":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                            if (checkBoxRelativeOrAbsVoulme.Checked) //volume  =abs
                                            {
                                                if (radioButtonAbove.Checked) // its an upper 
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveVolumeAbsAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictVolumeAbsAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }
                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowVolumeAbsAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictVolumeAbsAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }
                                            }
                                            else //Dose Abs Volume Rel
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveVolumeRelAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictVolumeRelAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }
                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowVolumeRelAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictVolumeRelAtDoseAbsCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }

                                            }
                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (checkBoxRelativeOrAbsVoulme.Checked) //volume  =abs
                                                {
                                                    if (radioButtonAbove.Checked) // its an upper
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveVolumeAbsAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictVolumeAbsAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    }

                                                    else // its an lower
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowVolumeAbsAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictVolumeAbsAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                    }
                                                }
                                                else // volume = rel
                                                {
                                                    if (radioButtonAbove.Checked) // its an upper
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveVolumeRelAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictVolumeRelAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                    }
                                                    else // its an lower
                                                    {
                                                        if (radioButtonNotStrict.Checked)
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowVolumeRelAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                        else
                                                            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictVolumeRelAtDoseRelCriterion(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                    }
                                                }
                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                            //  dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBox2.GetItemText(listBox2.SelectedItem)).Criteria.Last().Priority = int.Parse(textBox5.Text);
                                        }

                                        break;
                                    case "Mean dose":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                        {
                                            if (radioButtonAbove.Checked) // its an upper 
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMeanDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMeanDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                            }
                                            else // its an lower
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMeanDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMeanDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }
                                        }

                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMeanDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMeanDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMeanDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMeanDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                            //  dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBox2.GetItemText(listBox2.SelectedItem)).Criteria.Last().Priority = int.Parse(textBox5.Text);
                                        }

                                        break;
                                    case "Median dose":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                        {
                                            if (radioButtonAbove.Checked) // its an upper 
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMedianDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMedianDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                            else // its an lower
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMedianDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMedianDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                        }

                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMedianDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMedianDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }
                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMedianDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMedianDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }
                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                        }

                                        break;
                                    case "Max dose":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                        {
                                            if (radioButtonAbove.Checked) // its an upper 
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMaxDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMaxDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                            else // its an lower
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMaxDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMaxDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                        }

                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMaxDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMaxDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMaxDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMaxDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));

                                                }
                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                        }

                                        break;
                                    case "Min dose":
                                        if (checkBoxRelativeOrAbsDose.Checked) //Dose = abs
                                        {
                                            if (radioButtonAbove.Checked) // its an upper 
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMinDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMinDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                            else // its an lower
                                            {
                                                if (radioButtonNotStrict.Checked)
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMinDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                else
                                                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMinDoseAbs(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                            }

                                        }

                                        else //Dose Rel
                                        {
                                            if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose != -1 || comboBoxPlanSumPart.SelectedIndex != 0)
                                            {
                                                if (radioButtonAbove.Checked) // its an upper
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveMinDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new AboveStrictMinDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                                else // its an lower
                                                {
                                                    if (radioButtonNotStrict.Checked)
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowMinDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                    else
                                                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).AddCriterion(new BelowStrictMinDoseRel(Double.Parse(textBoxDose.Text), Double.Parse(textBoxVolume.Text), int.Parse(textBoxPriority.Text), comboBoxPlanSumPart.SelectedIndex));
                                                }

                                            }
                                            else
                                                MessageBox.Show("I have not define relative doses for plan sums");
                                        }

                                        break;

                                    default:
                                        MessageBox.Show("This is a bug now with the naming of criteras, contact martinooolin@gmail.com", "Please tell the creator of this program", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        break;
                                }

                                dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).Criteria.Last().CreatedBy = user ;
                                UpdateDateOfUpdate();
                                UpdateDataAndRewriteLists(3);
                               // listBoxCrit.SelectedIndex = listBoxCrit.Items.Count-1;
                            }
                            catch
                            {
                                MessageBox.Show("error when making criteria");
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please make a priority between -998 and 998");
            }
        }
        private void buttonRemoveCriterion_Click(object sender, EventArgs e) //remove Criteria
        {
            if (listBoxCrit.SelectedIndex != -1)
            {
                int currentIndex = listBoxCrit.SelectedIndex;
                dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).RemoveCriterion(currentIndex);
                UpdateDateOfUpdate();
                UpdateDataAndRewriteLists(3);
                if (currentIndex > listBoxCrit.TopIndex)
                    listBoxCrit.SelectedIndex = currentIndex - 1;
                else
                    if (listBoxCrit.Items.Count > 0)
                        listBoxCrit.SelectedIndex = currentIndex;
                    else
                    { }
            }
        }
        private void checkBoxRelativeOrAbsolutDose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRelativeOrAbsDose.Checked)
                checkBoxRelativeOrAbsDose.Text = "Absolute";
            else
                checkBoxRelativeOrAbsDose.Text = "Relative";
        }

        private void checkBoxRelativeOrAbsVoulme_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRelativeOrAbsVoulme.Checked)
                checkBoxRelativeOrAbsVoulme.Text = "Absolute";
            else
                checkBoxRelativeOrAbsVoulme.Text = "Relative";
        }

        private void textBoxVolume_TextChanged(object sender, EventArgs e)
        {
            CheckEnableAddCriteriaButtonStatus();
        }

        private void textBoxDose_TextChanged(object sender, EventArgs e)
        {
            CheckEnableAddCriteriaButtonStatus();
        }
        private void CheckEnableAddCriteriaButtonStatus()
        {
            if (listBoxProtocols.SelectedIndex != -1 && listBoxStruct.SelectedIndex != -1)
            {
                if (comboBoxType.SelectedIndex != -1)
                {
                    double temp;
                    double temp2;
                    double temp3;
                    if (double.TryParse(textBoxDose.Text, out temp) && double.TryParse(textBoxVolume.Text, out temp2) && double.TryParse(textBoxPriority.Text, out temp3))
                        buttonAddCriteria.Enabled = (double.Parse(textBoxDose.Text) >= 0 && double.Parse(textBoxVolume.Text) >= 0);
                    else
                        buttonAddCriteria.Enabled = false;
                }
                else
                    buttonAddCriteria.Enabled = false;
            }
            else
                buttonAddCriteria.Enabled = false;

        }
        private void CheckEnableAddProtocolButtonStatus()
        {

            double temp2;
            double temp3;
            if (radioButtonSinglePlan.Checked)
                buttonAddProtocol.Enabled = textBoxProtocolName.Text != "" && (double.TryParse(textBoxDosePerFraction.Text, out temp2) ? double.Parse(textBoxDosePerFraction.Text) > 0 : false) && double.TryParse(textBoxFractions.Text, out temp3);
            else
            {
                CheckEnableAddSubProtocolButtonStatus();
                buttonAddProtocol.Enabled = subFractions.Count > 0;
            }
        }
        private void CheckEnableAddSubProtocolButtonStatus()
        {
            double temp2;
            double temp3;
            buttonAddSubProtocol.Enabled = textBoxProtocolName.Text != "" && (double.TryParse(textBoxDosePerFraction.Text, out temp2) ? double.Parse(textBoxDosePerFraction.Text) > 0 : false) && double.TryParse(textBoxFractions.Text, out temp3);
        }
        private void UpdateDataAndRewriteLists(int lvl) //update lvl=1 Protocol, 2=Structure and 3=Criterion
        {
            switch (lvl)
            {
                case 1: //protocls
                    {
                        listBoxProtocols.Items.Clear();
                        foreach (String protocolName in dataBase.GetProtocolListNames())
                        {
                            listBoxProtocols.Items.Add(protocolName);
                        }
                        listBoxStruct.Items.Clear();
                        listBoxCrit.Items.Clear();
                        labelCriterionCreatedBy.Text = "";
                        labelStrucutreCreatedBy.Text = "";
                    }
                    break;
                case 2: // Strucutres
                    {
                        if (listBoxProtocols.SelectedIndex == -1)
                        {
                            MessageBox.Show("errors with StructuureListBox, no protocol chosen");
                            labelCriterionCreatedBy.Text = "";
                        return;
                        }
                        else
                        {
                            listBoxStruct.Items.Clear();
                            foreach (String strucutreName in dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructureNames())
                            {
                                listBoxStruct.Items.Add(strucutreName);
                            }
                        }
                        listBoxCrit.Items.Clear();
                        labelCriterionCreatedBy.Text = "";
                        labelStrucutreCreatedBy.Text = "";
                    }
                    break;

                case 3: //Critera
                    {
                        listBoxCrit.Items.Clear();
                      if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose == -1)
                        {
                            foreach (Criterion criterion in dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).Criteria)
                            {
                                if (criterion.PartPlan!=0)
                                    listBoxCrit.Items.Add(criterion.Priority.ToString()+ ": " +"P"+criterion.PartPlan.ToString()+ " "+criterion.Name);
                                else
                                    listBoxCrit.Items.Add(criterion.Priority.ToString()+ ": "+ criterion.Name);
                            }
                            labelCriterionCreatedBy.Text = "";
                        }
                      else
                           foreach (Criterion criterion in dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).Criteria)
                            {
                                if (criterion.PartPlan!=0)
                                    listBoxCrit.Items.Add(criterion.Priority.ToString()+ ": " +"U "+ criterion.Name);
                                else
                                    listBoxCrit.Items.Add(criterion.Priority.ToString()+ ": "+ criterion.Name);
                            }
                            labelCriterionCreatedBy.Text = "";
                    }
                    break;
                default:
                    {
                        MessageBox.Show("something was not updated", "Errrroooozzzz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)//save
        {
            Save();
        }

        private void buttonMoveStrucutreUpInList_Click_1(object sender, EventArgs e) //move strucutre up in list //will call  UpdateData-- 2times
        {
            if (listBoxStruct.SelectedIndex > 0)
            {
                dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Swap(listBoxStruct.SelectedIndex, listBoxStruct.SelectedIndex - 1);

                int index = listBoxStruct.SelectedIndex - 1;
                UpdateDataAndRewriteLists(2);
                listBoxStruct.SelectedIndex = index;
            }
        }

        private void buttonMoveStrucutreDownInList_Click(object sender, EventArgs e)// down structure in list //will call  UpdateData-- 2times
        {
            if (listBoxStruct.SelectedIndex < listBoxStruct.Items.Count - 1)
            {
                dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Swap(listBoxStruct.SelectedIndex, listBoxStruct.SelectedIndex + 1);

                int index = listBoxStruct.SelectedIndex + 1;
                UpdateDataAndRewriteLists(2);
                listBoxStruct.SelectedIndex = index;
            }
        }

        private void textBoxDosPerFraction_TextChanged(object sender, EventArgs e) //dos per fraction
        {
            CheckEnableAddProtocolButtonStatus();
        }

        private void textBoxNrOfFractions_TextChanged(object sender, EventArgs e) //nr of fractions
        {
            CheckEnableAddProtocolButtonStatus();
        }

        private void textBoxPriority_TextChanged(object sender, EventArgs e)
        {
            CheckEnableAddCriteriaButtonStatus();
        }

        private void textBoxProtocolName_TextChanged(object sender, EventArgs e)
        {
            CheckEnableAddProtocolButtonStatus();
        }

        private void radioButtonPlanSum_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlanSum.Checked)
            {


            }
        }
  
        private void radioButtonPlanSetup_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnableAddProtocolButtonStatus();
            if (radioButtonSinglePlan.Checked)
            {
                panelSubPlans.Visible = false;
                buttonRemoveProtocol.Location = new Point(buttonRemoveProtocol.Location.X - 50 * 2, buttonRemoveProtocol.Location.Y);
                buttonChangeNameProtocol.Location = new Point(buttonChangeNameProtocol.Location.X - 50 * 2, buttonRemoveProtocol.Location.Y);
                buttonAddSubProtocol.Visible = false;
                textBoxProtocolName.Enabled = true;
                labelHelpPickPlan.Text = "Type of plan:";
            }
            else
            {
                buttonRemoveProtocol.Location = new Point(buttonRemoveProtocol.Location.X + 50*2, buttonRemoveProtocol.Location.Y);
                buttonChangeNameProtocol.Location = new Point(buttonChangeNameProtocol.Location.X + 50 * 2, buttonRemoveProtocol.Location.Y);
                labelHelpPickPlan.Text = "Part of plan sum:";
                resetAddPlanSumProtocol();
            }
        }
        private void resetAddPlanSumProtocol() {
            subDoses.Clear();
            subFractions.Clear();
            textBoxProtocolName.Enabled = true;
            buttonAddSubProtocol.Visible = true;
            buttonAddProtocol.Enabled = false;
            textBoxProtocolName.Text = "";
            textBoxDosePerFraction.Text = "";
            textBoxFractions.Text = "";
            listBoxSubPlansDosePerFraction.Items.Clear();
            listBoxSubPlansFractions.Items.Clear();
        }

        private void buttonAddSubProtocol_Click(object sender, EventArgs e)
        {
            panelSubPlans.Visible = true;
            listBoxSubPlansDosePerFraction.Items.Add(double.Parse(textBoxDosePerFraction.Text));
            listBoxSubPlansFractions.Items.Add(int.Parse(textBoxFractions.Text));
            textBoxProtocolName.Enabled = false;
            buttonAddProtocol.Enabled = true;
            subDoses.Add(double.Parse(textBoxDosePerFraction.Text));
            subFractions.Add(int.Parse(textBoxFractions.Text));
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableAddCriteriaButtonStatus();
        }

        private void listBoxCrit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCrit.SelectedIndex != -1)
            {
                List<string> createdBy = new List<string>(30);
                foreach (String creator in dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.GetItemText(listBoxStruct.SelectedItem)).GetListOfCriterionCreatedBy())
                    createdBy.Add(creator);
                labelCriterionCreatedBy.Text = "created by " + createdBy.ElementAt(listBoxCrit.SelectedIndex);
            }
        }

        private void buttonExitPlanSumCreation_Click(object sender, EventArgs e)
        {
            resetAddPlanSumProtocol();
            panelSubPlans.Visible = false;
        }

        private void buttonChangeNameProtocol_Click(object sender, EventArgs e)
        {
            if (listBoxProtocols.SelectedIndex != -1 && textBoxProtocolName.Text != "")
            {
                Protocol newPortocol;

                if (dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Fractions == -1)
                {

                    newPortocol = new PlanSumProtocol(textBoxProtocolName.Text.ToString(), dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetSubFractions(), dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetSubDoses());
                    if (listBoxProtocols.FindStringExact(newPortocol.GetListName()) == -1)
                    {
                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Name = textBoxProtocolName.Text;
                        UpdateDateOfUpdateDataBase();
                        UpdateDataAndRewriteLists(1);
                    }
                    else
                        MessageBox.Show("this protocol already exists, try name it to something different");

                }
                else
                {
                    newPortocol = new Protocol(textBoxProtocolName.Text.ToString(), dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Dose, dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Fractions);
                    int index = listBoxProtocols.SelectedIndex;
                    if (listBoxProtocols.FindStringExact(newPortocol.GetListName()) == -1)
                    {
                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).Name = textBoxProtocolName.Text;
                        dataBase.GetProtocol(listBoxProtocols.SelectedIndex).CreatedBy =user;
                        UpdateDataAndRewriteLists(1);
                        listBoxProtocols.SelectedIndex = index;
                    }
                    else
                        MessageBox.Show("this protocol already exists, try name it to something different");
                }

            }
        }

        private void buttonChangeStrucutreName_Click(object sender, EventArgs e)
        {
            if (textBoxNewStruct.Text != "")
                if (listBoxStruct.FindStringExact(textBoxNewStruct.Text) == -1)
                { 
                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.Text).Name = textBoxNewStruct.Text;
                    dataBase.GetProtocol(listBoxProtocols.SelectedIndex).GetStructure(listBoxStruct.Text).CreatedBy = user;
                    UpdateDateOfUpdate();
                    UpdateDataAndRewriteLists(2);
                    listBoxStruct.SelectedItem = textBoxNewStruct.Text;
                }
            else
                    MessageBox.Show("You already have this structure");

        }
        private void UpdateDateOfUpdate()
        {
            dataBase.GetProtocol(listBoxProtocols.SelectedIndex).LastUpdated = DateTime.Now.Date.ToShortDateString();
            labelProtocolCreatedBy.Text = "created by " + dataBase.GetProtocol(listBoxProtocols.SelectedIndex).CreatedBy + " updated: " + dataBase.GetProtocol(listBoxProtocols.SelectedIndex).LastUpdated;
            UpdateDateOfUpdateDataBase();
        }
        private void UpdateDateOfUpdateDataBase()
        {
            dataBase.LastUpdated = DateTime.Now.Date.ToShortDateString();
            
        }
        private void prefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void Save()
        {
            if (dataBaseFullName == "")
                SaveAs();
            else
            {
                try
                {
                    Serialization.XMLFileSerialize(dataBaseFullName,dataBase);
                    SettingsScript.Default.Save();
                }
                catch
                {
                    MessageBox.Show("failed to save");
                }
            }
        }
        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog()==DialogResult.OK)
                try
                {
                    dataBaseFullName = sfd.FileName;
                    if (dataBaseFullName.Length > 4)
                        if (dataBaseFullName.Substring(dataBaseFullName.Length - 4) != ".xml")
                            dataBaseFullName = dataBaseFullName + ".xml";
                    Serialization.XMLFileSerialize(dataBaseFullName, dataBase);
                    SettingsScript.Default.Save();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "|*.xml";
            if (odf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataBase = Serialization.XMLFileDeserialize<DataBase>(odf.FileName);
                    dataBaseFullName = odf.FileName;
                    UpdateDataAndRewriteLists(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void MenuCreateDB_Click(object sender, EventArgs e)
        {
            CreateNewDataBase();
            UpdateDataAndRewriteLists(1);
        }
        private void CreateNewDataBase()
        {
            dataBaseFullName = "";
            dataBase = new DataBase();
            Protocol oneTimeRun = new UnknownProtocol();
            dataBase.AddProtocol(oneTimeRun);
        }
        private void MenuSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs(); //DataBaseManager?
        }

        private void MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataBaseFullName != "")
            { 
                SettingsScript.Default.CustomScriptDataBasePath = dataBaseFullName;
                SettingsScript.Default.CustomScriptDataBase = true;
            }
        }


        private void lastUpdatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Database was last updated: " + dataBase.LastUpdated);
        }
        private void MenuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void editWordToHighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlighterEditor h = new HighlighterEditor(dataBase);
            h.ShowDialog();
        }

        private void setPrefixLengthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                SetPrefix s = new SetPrefix(dataBase);
                s.ShowDialog();
            }
        }

        private void letterSimilarityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNameSimilarity s = new SetNameSimilarity(dataBase);
            s.ShowDialog();
        }

        private void setConfigToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsScript.Default.CustomScriptDataBase = false;
        }

        private void whatDatabaseAmIOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataBaseFullName != "")
                MessageBox.Show(dataBaseFullName);
            else
                MessageBox.Show("You have created a new database, if you want to you can save it with the save button");
        }

        private void MenuDisallowScriptToEnterAdminsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsScript.Default.accessAdmin = false;
        }

        private void MenuAllowScriptToEnterAdminsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsScript.Default.accessAdmin = true;
        }


    }
}
