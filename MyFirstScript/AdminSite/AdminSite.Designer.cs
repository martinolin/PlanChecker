namespace PlanChecker
{
    partial class AdminSite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSite));
            this.listBoxProtocols = new System.Windows.Forms.ListBox();
            this.buttonAddProtocol = new System.Windows.Forms.Button();
            this.buttonRemoveProtocol = new System.Windows.Forms.Button();
            this.listBoxStruct = new System.Windows.Forms.ListBox();
            this.buttonRemoveStruct = new System.Windows.Forms.Button();
            this.buttonAddStruct = new System.Windows.Forms.Button();
            this.listBoxCrit = new System.Windows.Forms.ListBox();
            this.buttonRemoveCriteria = new System.Windows.Forms.Button();
            this.buttonAddCriteria = new System.Windows.Forms.Button();
            this.checkBoxRelativeOrAbsDose = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProtocolName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewStruct = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.checkBoxRelativeOrAbsVoulme = new System.Windows.Forms.CheckBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonAbove = new System.Windows.Forms.RadioButton();
            this.radioButtonBelow = new System.Windows.Forms.RadioButton();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.textBoxDosePerFraction = new System.Windows.Forms.TextBox();
            this.textBoxFractions = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonPlanSum = new System.Windows.Forms.RadioButton();
            this.radioButtonSinglePlan = new System.Windows.Forms.RadioButton();
            this.buttonAddSubProtocol = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonNotStrict = new System.Windows.Forms.RadioButton();
            this.radioButtonStrict = new System.Windows.Forms.RadioButton();
            this.labelHelpPickPlan = new System.Windows.Forms.Label();
            this.comboBoxPlanSumPart = new System.Windows.Forms.ComboBox();
            this.labelProtocolCreatedBy = new System.Windows.Forms.Label();
            this.labelStrucutreCreatedBy = new System.Windows.Forms.Label();
            this.labelCriterionCreatedBy = new System.Windows.Forms.Label();
            this.panelSubPlans = new System.Windows.Forms.Panel();
            this.buttonExitPlanSumCreation = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.listBoxSubPlansFractions = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelinfo = new System.Windows.Forms.Label();
            this.listBoxSubPlansDosePerFraction = new System.Windows.Forms.ListBox();
            this.buttonChangeStrucutreName = new System.Windows.Forms.Button();
            this.buttonChangeNameProtocol = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCreateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.opitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setConfigToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPrefixLengthToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editWordToHighlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameMatchningToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.letterSimilarityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastUpdatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatDatabaseAmIOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelSubPlans.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxProtocols
            // 
            this.listBoxProtocols.FormattingEnabled = true;
            this.listBoxProtocols.Location = new System.Drawing.Point(26, 46);
            this.listBoxProtocols.Name = "listBoxProtocols";
            this.listBoxProtocols.Size = new System.Drawing.Size(212, 381);
            this.listBoxProtocols.TabIndex = 0;
            this.listBoxProtocols.SelectedIndexChanged += new System.EventHandler(this.listBoxProtocols_SelectedIndexChanged);
            // 
            // buttonAddProtocol
            // 
            this.buttonAddProtocol.Location = new System.Drawing.Point(21, 558);
            this.buttonAddProtocol.Name = "buttonAddProtocol";
            this.buttonAddProtocol.Size = new System.Drawing.Size(93, 34);
            this.buttonAddProtocol.TabIndex = 1;
            this.buttonAddProtocol.Text = "Add";
            this.buttonAddProtocol.UseVisualStyleBackColor = true;
            this.buttonAddProtocol.Click += new System.EventHandler(this.buttonAddProtcol_Click);
            // 
            // buttonRemoveProtocol
            // 
            this.buttonRemoveProtocol.Location = new System.Drawing.Point(120, 558);
            this.buttonRemoveProtocol.Name = "buttonRemoveProtocol";
            this.buttonRemoveProtocol.Size = new System.Drawing.Size(93, 34);
            this.buttonRemoveProtocol.TabIndex = 2;
            this.buttonRemoveProtocol.Text = "Remove";
            this.buttonRemoveProtocol.UseVisualStyleBackColor = true;
            this.buttonRemoveProtocol.Click += new System.EventHandler(this.buttonRemoveProtocol_Click);
            // 
            // listBoxStruct
            // 
            this.listBoxStruct.FormattingEnabled = true;
            this.listBoxStruct.Location = new System.Drawing.Point(343, 46);
            this.listBoxStruct.Name = "listBoxStruct";
            this.listBoxStruct.Size = new System.Drawing.Size(212, 381);
            this.listBoxStruct.TabIndex = 3;
            this.listBoxStruct.SelectedIndexChanged += new System.EventHandler(this.listBoxStructures_SelectedIndexChanged);
            // 
            // buttonRemoveStruct
            // 
            this.buttonRemoveStruct.Location = new System.Drawing.Point(442, 473);
            this.buttonRemoveStruct.Name = "buttonRemoveStruct";
            this.buttonRemoveStruct.Size = new System.Drawing.Size(93, 34);
            this.buttonRemoveStruct.TabIndex = 5;
            this.buttonRemoveStruct.Text = "Remove";
            this.buttonRemoveStruct.UseVisualStyleBackColor = true;
            this.buttonRemoveStruct.Click += new System.EventHandler(this.buttonRemoveStrucutre_Click);
            // 
            // buttonAddStruct
            // 
            this.buttonAddStruct.Location = new System.Drawing.Point(343, 473);
            this.buttonAddStruct.Name = "buttonAddStruct";
            this.buttonAddStruct.Size = new System.Drawing.Size(93, 34);
            this.buttonAddStruct.TabIndex = 4;
            this.buttonAddStruct.Text = "Add";
            this.buttonAddStruct.UseVisualStyleBackColor = true;
            this.buttonAddStruct.Click += new System.EventHandler(this.buttonAddStructure_Click);
            // 
            // listBoxCrit
            // 
            this.listBoxCrit.FormattingEnabled = true;
            this.listBoxCrit.Location = new System.Drawing.Point(657, 46);
            this.listBoxCrit.Name = "listBoxCrit";
            this.listBoxCrit.Size = new System.Drawing.Size(212, 381);
            this.listBoxCrit.TabIndex = 6;
            this.listBoxCrit.SelectedIndexChanged += new System.EventHandler(this.listBoxCrit_SelectedIndexChanged);
            // 
            // buttonRemoveCriteria
            // 
            this.buttonRemoveCriteria.Location = new System.Drawing.Point(752, 551);
            this.buttonRemoveCriteria.Name = "buttonRemoveCriteria";
            this.buttonRemoveCriteria.Size = new System.Drawing.Size(92, 34);
            this.buttonRemoveCriteria.TabIndex = 8;
            this.buttonRemoveCriteria.Text = "Remove";
            this.buttonRemoveCriteria.UseVisualStyleBackColor = true;
            this.buttonRemoveCriteria.Click += new System.EventHandler(this.buttonRemoveCriterion_Click);
            // 
            // buttonAddCriteria
            // 
            this.buttonAddCriteria.Location = new System.Drawing.Point(639, 551);
            this.buttonAddCriteria.Name = "buttonAddCriteria";
            this.buttonAddCriteria.Size = new System.Drawing.Size(94, 34);
            this.buttonAddCriteria.TabIndex = 10;
            this.buttonAddCriteria.Text = "AddCritera";
            this.buttonAddCriteria.UseVisualStyleBackColor = true;
            this.buttonAddCriteria.Click += new System.EventHandler(this.buttonAddCriterion_Click);
            // 
            // checkBoxRelativeOrAbsDose
            // 
            this.checkBoxRelativeOrAbsDose.AutoSize = true;
            this.checkBoxRelativeOrAbsDose.Location = new System.Drawing.Point(812, 479);
            this.checkBoxRelativeOrAbsDose.Name = "checkBoxRelativeOrAbsDose";
            this.checkBoxRelativeOrAbsDose.Size = new System.Drawing.Size(65, 17);
            this.checkBoxRelativeOrAbsDose.TabIndex = 11;
            this.checkBoxRelativeOrAbsDose.Text = "Relative";
            this.checkBoxRelativeOrAbsDose.UseVisualStyleBackColor = true;
            this.checkBoxRelativeOrAbsDose.CheckedChanged += new System.EventHandler(this.checkBoxRelativeOrAbsolutDose_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Protocol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Strucutre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Criterion:";
            // 
            // textBoxProtocolName
            // 
            this.textBoxProtocolName.Location = new System.Drawing.Point(82, 471);
            this.textBoxProtocolName.Name = "textBoxProtocolName";
            this.textBoxProtocolName.Size = new System.Drawing.Size(174, 20);
            this.textBoxProtocolName.TabIndex = 15;
            this.textBoxProtocolName.TextChanged += new System.EventHandler(this.textBoxProtocolName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "New protocol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "New strucutre:";
            // 
            // textBoxNewStruct
            // 
            this.textBoxNewStruct.Location = new System.Drawing.Point(422, 439);
            this.textBoxNewStruct.Name = "textBoxNewStruct";
            this.textBoxNewStruct.Size = new System.Drawing.Size(174, 20);
            this.textBoxNewStruct.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Dose:";
            // 
            // textBoxDose
            // 
            this.textBoxDose.Location = new System.Drawing.Point(703, 473);
            this.textBoxDose.Name = "textBoxDose";
            this.textBoxDose.Size = new System.Drawing.Size(103, 20);
            this.textBoxDose.TabIndex = 20;
            this.textBoxDose.TextChanged += new System.EventHandler(this.textBoxDose_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 502);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Volume:";
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.Location = new System.Drawing.Point(703, 499);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(103, 20);
            this.textBoxVolume.TabIndex = 22;
            this.textBoxVolume.TextChanged += new System.EventHandler(this.textBoxVolume_TextChanged);
            // 
            // checkBoxRelativeOrAbsVoulme
            // 
            this.checkBoxRelativeOrAbsVoulme.AutoSize = true;
            this.checkBoxRelativeOrAbsVoulme.Location = new System.Drawing.Point(812, 511);
            this.checkBoxRelativeOrAbsVoulme.Name = "checkBoxRelativeOrAbsVoulme";
            this.checkBoxRelativeOrAbsVoulme.Size = new System.Drawing.Size(65, 17);
            this.checkBoxRelativeOrAbsVoulme.TabIndex = 23;
            this.checkBoxRelativeOrAbsVoulme.Text = "Relative";
            this.checkBoxRelativeOrAbsVoulme.UseVisualStyleBackColor = true;
            this.checkBoxRelativeOrAbsVoulme.CheckedChanged += new System.EventHandler(this.checkBoxRelativeOrAbsVoulme_CheckedChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Dxx",
            "Vxx",
            "Mean dose",
            "Median dose",
            "Min dose",
            "Max dose"});
            this.comboBoxType.Location = new System.Drawing.Point(703, 438);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 24;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Type:";
            // 
            // radioButtonAbove
            // 
            this.radioButtonAbove.AutoSize = true;
            this.radioButtonAbove.Location = new System.Drawing.Point(3, 35);
            this.radioButtonAbove.Name = "radioButtonAbove";
            this.radioButtonAbove.Size = new System.Drawing.Size(56, 17);
            this.radioButtonAbove.TabIndex = 26;
            this.radioButtonAbove.TabStop = true;
            this.radioButtonAbove.Text = "Above";
            this.radioButtonAbove.UseVisualStyleBackColor = true;
            // 
            // radioButtonBelow
            // 
            this.radioButtonBelow.AutoSize = true;
            this.radioButtonBelow.Checked = true;
            this.radioButtonBelow.Location = new System.Drawing.Point(3, 68);
            this.radioButtonBelow.Name = "radioButtonBelow";
            this.radioButtonBelow.Size = new System.Drawing.Size(54, 17);
            this.radioButtonBelow.TabIndex = 27;
            this.radioButtonBelow.TabStop = true;
            this.radioButtonBelow.Text = "Below";
            this.radioButtonBelow.UseVisualStyleBackColor = true;
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(703, 525);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(103, 20);
            this.textBoxPriority.TabIndex = 28;
            this.textBoxPriority.Text = "1";
            this.textBoxPriority.TextChanged += new System.EventHandler(this.textBoxPriority_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(662, 528);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Priority:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(872, 552);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(77, 34);
            this.buttonSave.TabIndex = 30;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUp.Location = new System.Drawing.Point(571, 194);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(24, 35);
            this.buttonUp.TabIndex = 31;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMoveStrucutreUpInList_Click_1);
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDown.Location = new System.Drawing.Point(571, 235);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(24, 35);
            this.buttonDown.TabIndex = 32;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMoveStrucutreDownInList_Click);
            // 
            // textBoxDosePerFraction
            // 
            this.textBoxDosePerFraction.Location = new System.Drawing.Point(82, 502);
            this.textBoxDosePerFraction.Name = "textBoxDosePerFraction";
            this.textBoxDosePerFraction.Size = new System.Drawing.Size(174, 20);
            this.textBoxDosePerFraction.TabIndex = 33;
            this.textBoxDosePerFraction.TextChanged += new System.EventHandler(this.textBoxDosPerFraction_TextChanged);
            // 
            // textBoxFractions
            // 
            this.textBoxFractions.Location = new System.Drawing.Point(82, 525);
            this.textBoxFractions.Name = "textBoxFractions";
            this.textBoxFractions.Size = new System.Drawing.Size(174, 20);
            this.textBoxFractions.TabIndex = 34;
            this.textBoxFractions.TextChanged += new System.EventHandler(this.textBoxNrOfFractions_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 508);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Dose/fraction:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Nr of fractions:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonAbove);
            this.panel1.Controls.Add(this.radioButtonBelow);
            this.panel1.Location = new System.Drawing.Point(883, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 100);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonPlanSum);
            this.panel2.Controls.Add(this.radioButtonSinglePlan);
            this.panel2.Location = new System.Drawing.Point(14, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 35);
            this.panel2.TabIndex = 38;
            // 
            // radioButtonPlanSum
            // 
            this.radioButtonPlanSum.AutoSize = true;
            this.radioButtonPlanSum.Location = new System.Drawing.Point(139, 10);
            this.radioButtonPlanSum.Name = "radioButtonPlanSum";
            this.radioButtonPlanSum.Size = new System.Drawing.Size(70, 17);
            this.radioButtonPlanSum.TabIndex = 1;
            this.radioButtonPlanSum.Text = "Plan Sum";
            this.radioButtonPlanSum.UseVisualStyleBackColor = true;
            this.radioButtonPlanSum.CheckedChanged += new System.EventHandler(this.radioButtonPlanSum_CheckedChanged);
            // 
            // radioButtonSinglePlan
            // 
            this.radioButtonSinglePlan.AutoSize = true;
            this.radioButtonSinglePlan.Checked = true;
            this.radioButtonSinglePlan.Location = new System.Drawing.Point(22, 10);
            this.radioButtonSinglePlan.Name = "radioButtonSinglePlan";
            this.radioButtonSinglePlan.Size = new System.Drawing.Size(78, 17);
            this.radioButtonSinglePlan.TabIndex = 0;
            this.radioButtonSinglePlan.TabStop = true;
            this.radioButtonSinglePlan.Text = "Single Plan";
            this.radioButtonSinglePlan.UseVisualStyleBackColor = true;
            this.radioButtonSinglePlan.CheckedChanged += new System.EventHandler(this.radioButtonPlanSetup_CheckedChanged);
            // 
            // buttonAddSubProtocol
            // 
            this.buttonAddSubProtocol.Location = new System.Drawing.Point(120, 558);
            this.buttonAddSubProtocol.Name = "buttonAddSubProtocol";
            this.buttonAddSubProtocol.Size = new System.Drawing.Size(93, 34);
            this.buttonAddSubProtocol.TabIndex = 39;
            this.buttonAddSubProtocol.Text = "Add subprotocol";
            this.buttonAddSubProtocol.UseVisualStyleBackColor = true;
            this.buttonAddSubProtocol.Visible = false;
            this.buttonAddSubProtocol.Click += new System.EventHandler(this.buttonAddSubProtocol_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonNotStrict);
            this.panel3.Controls.Add(this.radioButtonStrict);
            this.panel3.Location = new System.Drawing.Point(883, 384);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(66, 87);
            this.panel3.TabIndex = 40;
            // 
            // radioButtonNotStrict
            // 
            this.radioButtonNotStrict.AutoSize = true;
            this.radioButtonNotStrict.Checked = true;
            this.radioButtonNotStrict.Location = new System.Drawing.Point(3, 54);
            this.radioButtonNotStrict.Name = "radioButtonNotStrict";
            this.radioButtonNotStrict.Size = new System.Drawing.Size(67, 17);
            this.radioButtonNotStrict.TabIndex = 1;
            this.radioButtonNotStrict.TabStop = true;
            this.radioButtonNotStrict.Text = "not Strict";
            this.radioButtonNotStrict.UseVisualStyleBackColor = true;
            // 
            // radioButtonStrict
            // 
            this.radioButtonStrict.AutoSize = true;
            this.radioButtonStrict.Location = new System.Drawing.Point(3, 26);
            this.radioButtonStrict.Name = "radioButtonStrict";
            this.radioButtonStrict.Size = new System.Drawing.Size(49, 17);
            this.radioButtonStrict.TabIndex = 0;
            this.radioButtonStrict.Text = "Strict";
            this.radioButtonStrict.UseVisualStyleBackColor = true;
            // 
            // labelHelpPickPlan
            // 
            this.labelHelpPickPlan.AutoSize = true;
            this.labelHelpPickPlan.Location = new System.Drawing.Point(869, 356);
            this.labelHelpPickPlan.Name = "labelHelpPickPlan";
            this.labelHelpPickPlan.Size = new System.Drawing.Size(69, 13);
            this.labelHelpPickPlan.TabIndex = 41;
            this.labelHelpPickPlan.Text = "Type of plan:";
            // 
            // comboBoxPlanSumPart
            // 
            this.comboBoxPlanSumPart.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPlanSumPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanSumPart.FormattingEnabled = true;
            this.comboBoxPlanSumPart.Items.AddRange(new object[] {
            "Normal",
            "Uncertainty"});
            this.comboBoxPlanSumPart.Location = new System.Drawing.Point(872, 372);
            this.comboBoxPlanSumPart.Name = "comboBoxPlanSumPart";
            this.comboBoxPlanSumPart.Size = new System.Drawing.Size(89, 21);
            this.comboBoxPlanSumPart.TabIndex = 41;
            // 
            // labelProtocolCreatedBy
            // 
            this.labelProtocolCreatedBy.AutoSize = true;
            this.labelProtocolCreatedBy.Location = new System.Drawing.Point(68, 24);
            this.labelProtocolCreatedBy.Name = "labelProtocolCreatedBy";
            this.labelProtocolCreatedBy.Size = new System.Drawing.Size(0, 13);
            this.labelProtocolCreatedBy.TabIndex = 42;
            // 
            // labelStrucutreCreatedBy
            // 
            this.labelStrucutreCreatedBy.AutoSize = true;
            this.labelStrucutreCreatedBy.Location = new System.Drawing.Point(390, 24);
            this.labelStrucutreCreatedBy.Name = "labelStrucutreCreatedBy";
            this.labelStrucutreCreatedBy.Size = new System.Drawing.Size(0, 13);
            this.labelStrucutreCreatedBy.TabIndex = 43;
            // 
            // labelCriterionCreatedBy
            // 
            this.labelCriterionCreatedBy.AutoSize = true;
            this.labelCriterionCreatedBy.Location = new System.Drawing.Point(700, 24);
            this.labelCriterionCreatedBy.Name = "labelCriterionCreatedBy";
            this.labelCriterionCreatedBy.Size = new System.Drawing.Size(0, 13);
            this.labelCriterionCreatedBy.TabIndex = 44;
            // 
            // panelSubPlans
            // 
            this.panelSubPlans.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelSubPlans.Controls.Add(this.buttonExitPlanSumCreation);
            this.panelSubPlans.Controls.Add(this.label13);
            this.panelSubPlans.Controls.Add(this.listBoxSubPlansFractions);
            this.panelSubPlans.Controls.Add(this.label12);
            this.panelSubPlans.Controls.Add(this.labelinfo);
            this.panelSubPlans.Controls.Add(this.listBoxSubPlansDosePerFraction);
            this.panelSubPlans.Location = new System.Drawing.Point(14, 318);
            this.panelSubPlans.Name = "panelSubPlans";
            this.panelSubPlans.Size = new System.Drawing.Size(242, 112);
            this.panelSubPlans.TabIndex = 45;
            this.panelSubPlans.Visible = false;
            // 
            // buttonExitPlanSumCreation
            // 
            this.buttonExitPlanSumCreation.Location = new System.Drawing.Point(205, 5);
            this.buttonExitPlanSumCreation.Name = "buttonExitPlanSumCreation";
            this.buttonExitPlanSumCreation.Size = new System.Drawing.Size(22, 23);
            this.buttonExitPlanSumCreation.TabIndex = 5;
            this.buttonExitPlanSumCreation.Text = "X";
            this.buttonExitPlanSumCreation.UseVisualStyleBackColor = true;
            this.buttonExitPlanSumCreation.Click += new System.EventHandler(this.buttonExitPlanSumCreation_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Nr of fractions";
            // 
            // listBoxSubPlansFractions
            // 
            this.listBoxSubPlansFractions.FormattingEnabled = true;
            this.listBoxSubPlansFractions.Location = new System.Drawing.Point(123, 27);
            this.listBoxSubPlansFractions.Name = "listBoxSubPlansFractions";
            this.listBoxSubPlansFractions.Size = new System.Drawing.Size(76, 82);
            this.listBoxSubPlansFractions.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Dose/ fraction";
            // 
            // labelinfo
            // 
            this.labelinfo.AutoSize = true;
            this.labelinfo.Location = new System.Drawing.Point(13, 12);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(0, 13);
            this.labelinfo.TabIndex = 1;
            // 
            // listBoxSubPlansDosePerFraction
            // 
            this.listBoxSubPlansDosePerFraction.FormattingEnabled = true;
            this.listBoxSubPlansDosePerFraction.Location = new System.Drawing.Point(12, 27);
            this.listBoxSubPlansDosePerFraction.Name = "listBoxSubPlansDosePerFraction";
            this.listBoxSubPlansDosePerFraction.Size = new System.Drawing.Size(76, 82);
            this.listBoxSubPlansDosePerFraction.TabIndex = 0;
            // 
            // buttonChangeStrucutreName
            // 
            this.buttonChangeStrucutreName.Location = new System.Drawing.Point(541, 473);
            this.buttonChangeStrucutreName.Name = "buttonChangeStrucutreName";
            this.buttonChangeStrucutreName.Size = new System.Drawing.Size(93, 34);
            this.buttonChangeStrucutreName.TabIndex = 46;
            this.buttonChangeStrucutreName.Text = "Change Name";
            this.buttonChangeStrucutreName.UseVisualStyleBackColor = true;
            this.buttonChangeStrucutreName.Click += new System.EventHandler(this.buttonChangeStrucutreName_Click);
            // 
            // buttonChangeNameProtocol
            // 
            this.buttonChangeNameProtocol.Location = new System.Drawing.Point(219, 558);
            this.buttonChangeNameProtocol.Name = "buttonChangeNameProtocol";
            this.buttonChangeNameProtocol.Size = new System.Drawing.Size(93, 34);
            this.buttonChangeNameProtocol.TabIndex = 47;
            this.buttonChangeNameProtocol.Text = "Change Name";
            this.buttonChangeNameProtocol.UseVisualStyleBackColor = true;
            this.buttonChangeNameProtocol.Click += new System.EventHandler(this.buttonChangeNameProtocol_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.opitionsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(965, 24);
            this.menu.TabIndex = 48;
            this.menu.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.MenuSaveAs,
            this.MenuCreateDB});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(183, 22);
            this.MenuOpen.Text = "Open";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(183, 22);
            this.MenuSave.Text = "Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuSaveAs
            // 
            this.MenuSaveAs.Name = "MenuSaveAs";
            this.MenuSaveAs.Size = new System.Drawing.Size(183, 22);
            this.MenuSaveAs.Text = "Save as";
            this.MenuSaveAs.Click += new System.EventHandler(this.MenuSaveAs_Click);
            // 
            // MenuCreateDB
            // 
            this.MenuCreateDB.Name = "MenuCreateDB";
            this.MenuCreateDB.Size = new System.Drawing.Size(183, 22);
            this.MenuCreateDB.Text = "Create new database";
            this.MenuCreateDB.Click += new System.EventHandler(this.MenuCreateDB_Click);
            // 
            // opitionsToolStripMenuItem
            // 
            this.opitionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptToolStripMenuItem,
            this.databaseConfigToolStripMenuItem,
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem});
            this.opitionsToolStripMenuItem.Name = "opitionsToolStripMenuItem";
            this.opitionsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.opitionsToolStripMenuItem.Text = "Opitions";
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem,
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem,
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem,
            this.setConfigToDefaultToolStripMenuItem});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.scriptToolStripMenuItem.Text = "Script config";
            // 
            // MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem
            // 
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem.Name = "MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem";
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem.Text = "Make this database the default for script";
            this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem.Click += new System.EventHandler(this.MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem_Click);
            // 
            // MenuAllowScriptToEnterAdminsiteToolStripMenuItem
            // 
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem.Name = "MenuAllowScriptToEnterAdminsiteToolStripMenuItem";
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem.Text = "Allow script to enter adminsite";
            this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem.Click += new System.EventHandler(this.MenuAllowScriptToEnterAdminsiteToolStripMenuItem_Click);
            // 
            // MenuDisallowScriptToEnterAdminsiteToolStripMenuItem
            // 
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem.Name = "MenuDisallowScriptToEnterAdminsiteToolStripMenuItem";
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem.Text = "Disallow script to enter adminsite";
            this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem.Click += new System.EventHandler(this.MenuDisallowScriptToEnterAdminsiteToolStripMenuItem_Click);
            // 
            // setConfigToDefaultToolStripMenuItem
            // 
            this.setConfigToDefaultToolStripMenuItem.Name = "setConfigToDefaultToolStripMenuItem";
            this.setConfigToDefaultToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.setConfigToDefaultToolStripMenuItem.Text = "Set config to default";
            this.setConfigToDefaultToolStripMenuItem.Click += new System.EventHandler(this.setConfigToDefaultToolStripMenuItem_Click);
            // 
            // databaseConfigToolStripMenuItem
            // 
            this.databaseConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPrefixLengthToolStripMenuItem1,
            this.editWordToHighlightToolStripMenuItem,
            this.nameMatchningToolStripMenuItem1});
            this.databaseConfigToolStripMenuItem.Name = "databaseConfigToolStripMenuItem";
            this.databaseConfigToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.databaseConfigToolStripMenuItem.Text = "Database config";
            // 
            // setPrefixLengthToolStripMenuItem1
            // 
            this.setPrefixLengthToolStripMenuItem1.Name = "setPrefixLengthToolStripMenuItem1";
            this.setPrefixLengthToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.setPrefixLengthToolStripMenuItem1.Text = "Set prefix length";
            this.setPrefixLengthToolStripMenuItem1.Click += new System.EventHandler(this.setPrefixLengthToolStripMenuItem1_Click);
            // 
            // editWordToHighlightToolStripMenuItem
            // 
            this.editWordToHighlightToolStripMenuItem.Name = "editWordToHighlightToolStripMenuItem";
            this.editWordToHighlightToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.editWordToHighlightToolStripMenuItem.Text = "Edit words to highlight";
            this.editWordToHighlightToolStripMenuItem.Click += new System.EventHandler(this.editWordToHighlightToolStripMenuItem_Click);
            // 
            // nameMatchningToolStripMenuItem1
            // 
            this.nameMatchningToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.letterSimilarityToolStripMenuItem});
            this.nameMatchningToolStripMenuItem1.Name = "nameMatchningToolStripMenuItem1";
            this.nameMatchningToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.nameMatchningToolStripMenuItem1.Text = "Name matchning";
            // 
            // letterSimilarityToolStripMenuItem
            // 
            this.letterSimilarityToolStripMenuItem.Name = "letterSimilarityToolStripMenuItem";
            this.letterSimilarityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.letterSimilarityToolStripMenuItem.Text = "Letter similarity";
            this.letterSimilarityToolStripMenuItem.Click += new System.EventHandler(this.letterSimilarityToolStripMenuItem_Click);
            // 
            // seeWhenDatabaseLastUpdatedToolStripMenuItem
            // 
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastUpdatedToolStripMenuItem,
            this.whatDatabaseAmIOnToolStripMenuItem});
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem.Name = "seeWhenDatabaseLastUpdatedToolStripMenuItem";
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.seeWhenDatabaseLastUpdatedToolStripMenuItem.Text = "Database info";
            // 
            // lastUpdatedToolStripMenuItem
            // 
            this.lastUpdatedToolStripMenuItem.Name = "lastUpdatedToolStripMenuItem";
            this.lastUpdatedToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.lastUpdatedToolStripMenuItem.Text = "Last updated?";
            this.lastUpdatedToolStripMenuItem.Click += new System.EventHandler(this.lastUpdatedToolStripMenuItem_Click);
            // 
            // whatDatabaseAmIOnToolStripMenuItem
            // 
            this.whatDatabaseAmIOnToolStripMenuItem.Name = "whatDatabaseAmIOnToolStripMenuItem";
            this.whatDatabaseAmIOnToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.whatDatabaseAmIOnToolStripMenuItem.Text = "What database am i on?";
            this.whatDatabaseAmIOnToolStripMenuItem.Click += new System.EventHandler(this.whatDatabaseAmIOnToolStripMenuItem_Click);
            // 
            // AdminSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 599);
            this.Controls.Add(this.buttonChangeNameProtocol);
            this.Controls.Add(this.buttonChangeStrucutreName);
            this.Controls.Add(this.panelSubPlans);
            this.Controls.Add(this.labelCriterionCreatedBy);
            this.Controls.Add(this.labelStrucutreCreatedBy);
            this.Controls.Add(this.labelProtocolCreatedBy);
            this.Controls.Add(this.comboBoxPlanSumPart);
            this.Controls.Add(this.labelHelpPickPlan);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonAddSubProtocol);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxFractions);
            this.Controls.Add(this.textBoxDosePerFraction);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxPriority);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.checkBoxRelativeOrAbsVoulme);
            this.Controls.Add(this.textBoxVolume);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNewStruct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxProtocolName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxRelativeOrAbsDose);
            this.Controls.Add(this.buttonAddCriteria);
            this.Controls.Add(this.buttonRemoveCriteria);
            this.Controls.Add(this.listBoxCrit);
            this.Controls.Add(this.buttonRemoveStruct);
            this.Controls.Add(this.buttonAddStruct);
            this.Controls.Add(this.listBoxStruct);
            this.Controls.Add(this.buttonRemoveProtocol);
            this.Controls.Add(this.buttonAddProtocol);
            this.Controls.Add(this.listBoxProtocols);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminSite";
            this.Text = "AdminSite";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelSubPlans.ResumeLayout(false);
            this.panelSubPlans.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProtocols;
        private System.Windows.Forms.Button buttonAddProtocol;
        private System.Windows.Forms.Button buttonRemoveProtocol;
        private System.Windows.Forms.ListBox listBoxStruct;
        private System.Windows.Forms.Button buttonRemoveStruct;
        private System.Windows.Forms.Button buttonAddStruct;
        private System.Windows.Forms.ListBox listBoxCrit;
        private System.Windows.Forms.Button buttonRemoveCriteria;
        private System.Windows.Forms.Button buttonAddCriteria;
        private System.Windows.Forms.CheckBox checkBoxRelativeOrAbsDose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProtocolName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewStruct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.CheckBox checkBoxRelativeOrAbsVoulme;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonAbove;
        private System.Windows.Forms.RadioButton radioButtonBelow;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.TextBox textBoxDosePerFraction;
        private System.Windows.Forms.TextBox textBoxFractions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonPlanSum;
        private System.Windows.Forms.RadioButton radioButtonSinglePlan;
        private System.Windows.Forms.Button buttonAddSubProtocol;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonNotStrict;
        private System.Windows.Forms.RadioButton radioButtonStrict;
        private System.Windows.Forms.Label labelHelpPickPlan;
        private System.Windows.Forms.ComboBox comboBoxPlanSumPart;
        private System.Windows.Forms.Label labelProtocolCreatedBy;
        private System.Windows.Forms.Label labelStrucutreCreatedBy;
        private System.Windows.Forms.Label labelCriterionCreatedBy;
        private System.Windows.Forms.Panel panelSubPlans;
        private System.Windows.Forms.Button buttonExitPlanSumCreation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBoxSubPlansFractions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelinfo;
        private System.Windows.Forms.ListBox listBoxSubPlansDosePerFraction;
        private System.Windows.Forms.Button buttonChangeStrucutreName;
        private System.Windows.Forms.Button buttonChangeNameProtocol;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateDB;
        private System.Windows.Forms.ToolStripMenuItem opitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMakeThisDatabaseTheDefaultForScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAllowScriptToEnterAdminsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDisallowScriptToEnterAdminsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeWhenDatabaseLastUpdatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastUpdatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setConfigToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatDatabaseAmIOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPrefixLengthToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editWordToHighlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameMatchningToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem letterSimilarityToolStripMenuItem;
    }
}