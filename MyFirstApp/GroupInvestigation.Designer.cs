namespace PlanCheckerGroup
{
    partial class GroupInvestigation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupInvestigation));
            this.ResultPresentation = new System.Windows.Forms.DataGridView();
            this.comboBoxPlanPick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Go = new System.Windows.Forms.Button();
            this.Summary = new System.Windows.Forms.DataGridView();
            this.Mean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Median = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precentagePass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStatistiaclSummary = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelpassed = new System.Windows.Forms.Label();
            this.labelSTD1 = new System.Windows.Forms.Label();
            this.labelprecentagePass = new System.Windows.Forms.Label();
            this.labelSTD = new System.Windows.Forms.Label();
            this.labelMedian = new System.Windows.Forms.Label();
            this.labelMean = new System.Windows.Forms.Label();
            this.menuOpen = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllFilterifSerachingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonUseFilter = new System.Windows.Forms.RadioButton();
            this.radioButtonImportList = new System.Windows.Forms.RadioButton();
            this.listBoxPatient = new System.Windows.Forms.ListBox();
            this.buttonImportPatients = new System.Windows.Forms.Button();
            this.panelListPatients = new System.Windows.Forms.Panel();
            this.buttonRemovePatientFromList = new System.Windows.Forms.Button();
            this.textBoxPatient = new System.Windows.Forms.TextBox();
            this.buttonAddSinglePatient = new System.Windows.Forms.Button();
            this.buttonPickDataBase = new System.Windows.Forms.Button();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.labelPlanPicked = new System.Windows.Forms.Label();
            this.dataBaseReminder = new System.Windows.Forms.ToolTip(this.components);
            this.panelFilter = new System.Windows.Forms.Panel();
            this.textBoxNumberOfPatients = new System.Windows.Forms.TextBox();
            this.checkBoxNumberOfPatients = new System.Windows.Forms.CheckBox();
            this.panelCreationTime = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSsnr = new System.Windows.Forms.Panel();
            this.textBoxSsnr = new System.Windows.Forms.TextBox();
            this.labelSSNR = new System.Windows.Forms.Label();
            this.panelAge = new System.Windows.Forms.Panel();
            this.textBoxAgeTo = new System.Windows.Forms.TextBox();
            this.textBoxAgeFrom = new System.Windows.Forms.TextBox();
            this.labelAgeTo = new System.Windows.Forms.Label();
            this.labelAgeFrom = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSex = new System.Windows.Forms.Panel();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.checkBoxPlanCreation = new System.Windows.Forms.CheckBox();
            this.checkBoxSsnr = new System.Windows.Forms.CheckBox();
            this.checkBoxAge = new System.Windows.Forms.CheckBox();
            this.checkBoxSex = new System.Windows.Forms.CheckBox();
            this.labelSex = new System.Windows.Forms.Label();
            this.buttonClearResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPresentation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Summary)).BeginInit();
            this.panelStatistiaclSummary.SuspendLayout();
            this.menuOpen.SuspendLayout();
            this.panelListPatients.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelCreationTime.SuspendLayout();
            this.panelSsnr.SuspendLayout();
            this.panelAge.SuspendLayout();
            this.panelSex.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultPresentation
            // 
            this.ResultPresentation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultPresentation.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultPresentation.DefaultCellStyle = dataGridViewCellStyle1;
            this.ResultPresentation.Location = new System.Drawing.Point(31, 211);
            this.ResultPresentation.Name = "ResultPresentation";
            this.ResultPresentation.RowHeadersVisible = false;
            this.ResultPresentation.Size = new System.Drawing.Size(725, 458);
            this.ResultPresentation.TabIndex = 0;
            this.ResultPresentation.Visible = false;
            // 
            // comboBoxPlanPick
            // 
            this.comboBoxPlanPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanPick.FormattingEnabled = true;
            this.comboBoxPlanPick.Location = new System.Drawing.Point(134, 32);
            this.comboBoxPlanPick.Name = "comboBoxPlanPick";
            this.comboBoxPlanPick.Size = new System.Drawing.Size(298, 21);
            this.comboBoxPlanPick.TabIndex = 1;
            this.comboBoxPlanPick.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlanPick_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Protocol for evaluation:";
            // 
            // Go
            // 
            this.Go.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Go.Location = new System.Drawing.Point(331, 100);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(132, 54);
            this.Go.TabIndex = 4;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = false;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Summary
            // 
            this.Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Summary.ColumnHeadersVisible = false;
            this.Summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mean,
            this.Median,
            this.STD,
            this.precentagePass});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Summary.DefaultCellStyle = dataGridViewCellStyle2;
            this.Summary.Location = new System.Drawing.Point(7, 86);
            this.Summary.Name = "Summary";
            this.Summary.RowHeadersVisible = false;
            this.Summary.Size = new System.Drawing.Size(399, 416);
            this.Summary.TabIndex = 5;
            // 
            // Mean
            // 
            this.Mean.Frozen = true;
            this.Mean.HeaderText = "Mean";
            this.Mean.Name = "Mean";
            // 
            // Median
            // 
            this.Median.Frozen = true;
            this.Median.HeaderText = "Median";
            this.Median.Name = "Median";
            // 
            // STD
            // 
            this.STD.Frozen = true;
            this.STD.HeaderText = "Standard deviation";
            this.STD.Name = "STD";
            // 
            // precentagePass
            // 
            this.precentagePass.Frozen = true;
            this.precentagePass.HeaderText = "precentage that passed";
            this.precentagePass.Name = "precentagePass";
            // 
            // panelStatistiaclSummary
            // 
            this.panelStatistiaclSummary.Controls.Add(this.label2);
            this.panelStatistiaclSummary.Controls.Add(this.labelpassed);
            this.panelStatistiaclSummary.Controls.Add(this.Summary);
            this.panelStatistiaclSummary.Controls.Add(this.labelSTD1);
            this.panelStatistiaclSummary.Controls.Add(this.labelprecentagePass);
            this.panelStatistiaclSummary.Controls.Add(this.labelSTD);
            this.panelStatistiaclSummary.Controls.Add(this.labelMedian);
            this.panelStatistiaclSummary.Controls.Add(this.labelMean);
            this.panelStatistiaclSummary.Location = new System.Drawing.Point(762, 167);
            this.panelStatistiaclSummary.Name = "panelStatistiaclSummary";
            this.panelStatistiaclSummary.Size = new System.Drawing.Size(435, 502);
            this.panelStatistiaclSummary.TabIndex = 6;
            this.panelStatistiaclSummary.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "In this statistical summary all values that were unavaialble will be ignored";
            // 
            // labelpassed
            // 
            this.labelpassed.AutoSize = true;
            this.labelpassed.Location = new System.Drawing.Point(303, 70);
            this.labelpassed.Name = "labelpassed";
            this.labelpassed.Size = new System.Drawing.Size(79, 13);
            this.labelpassed.TabIndex = 5;
            this.labelpassed.Text = "that passed (%)";
            // 
            // labelSTD1
            // 
            this.labelSTD1.AutoSize = true;
            this.labelSTD1.Location = new System.Drawing.Point(203, 57);
            this.labelSTD1.Name = "labelSTD1";
            this.labelSTD1.Size = new System.Drawing.Size(50, 13);
            this.labelSTD1.TabIndex = 4;
            this.labelSTD1.Text = "Standard";
            // 
            // labelprecentagePass
            // 
            this.labelprecentagePass.AutoSize = true;
            this.labelprecentagePass.Location = new System.Drawing.Point(303, 57);
            this.labelprecentagePass.Name = "labelprecentagePass";
            this.labelprecentagePass.Size = new System.Drawing.Size(62, 13);
            this.labelprecentagePass.TabIndex = 3;
            this.labelprecentagePass.Text = "Percentage";
            // 
            // labelSTD
            // 
            this.labelSTD.AutoSize = true;
            this.labelSTD.Location = new System.Drawing.Point(203, 70);
            this.labelSTD.Name = "labelSTD";
            this.labelSTD.Size = new System.Drawing.Size(50, 13);
            this.labelSTD.TabIndex = 2;
            this.labelSTD.Text = "deviation";
            // 
            // labelMedian
            // 
            this.labelMedian.AutoSize = true;
            this.labelMedian.Location = new System.Drawing.Point(106, 70);
            this.labelMedian.Name = "labelMedian";
            this.labelMedian.Size = new System.Drawing.Size(42, 13);
            this.labelMedian.TabIndex = 1;
            this.labelMedian.Text = "Median";
            // 
            // labelMean
            // 
            this.labelMean.AutoSize = true;
            this.labelMean.Location = new System.Drawing.Point(4, 70);
            this.labelMean.Name = "labelMean";
            this.labelMean.Size = new System.Drawing.Size(34, 13);
            this.labelMean.TabIndex = 0;
            this.labelMean.Text = "Mean";
            // 
            // menuOpen
            // 
            this.menuOpen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuOpen.Location = new System.Drawing.Point(0, 0);
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(1197, 24);
            this.menuOpen.TabIndex = 7;
            this.menuOpen.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDatabasesToolStripMenuItem,
            this.controllFilterifSerachingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editDatabasesToolStripMenuItem
            // 
            this.editDatabasesToolStripMenuItem.Name = "editDatabasesToolStripMenuItem";
            this.editDatabasesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editDatabasesToolStripMenuItem.Text = "databases and script";
            this.editDatabasesToolStripMenuItem.Click += new System.EventHandler(this.editDatabasesToolStripMenuItem_Click);
            // 
            // controllFilterifSerachingToolStripMenuItem
            // 
            this.controllFilterifSerachingToolStripMenuItem.Name = "controllFilterifSerachingToolStripMenuItem";
            this.controllFilterifSerachingToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.controllFilterifSerachingToolStripMenuItem.Text = "controll filter (if seraching)";
            this.controllFilterifSerachingToolStripMenuItem.Click += new System.EventHandler(this.controllFilterifSerachingToolStripMenuItem_Click);
            // 
            // radioButtonUseFilter
            // 
            this.radioButtonUseFilter.AutoSize = true;
            this.radioButtonUseFilter.Location = new System.Drawing.Point(711, 48);
            this.radioButtonUseFilter.Name = "radioButtonUseFilter";
            this.radioButtonUseFilter.Size = new System.Drawing.Size(66, 17);
            this.radioButtonUseFilter.TabIndex = 8;
            this.radioButtonUseFilter.Text = "Use filter";
            this.radioButtonUseFilter.UseVisualStyleBackColor = true;
            this.radioButtonUseFilter.CheckedChanged += new System.EventHandler(this.radioButtonUseFilter_CheckedChanged);
            // 
            // radioButtonImportList
            // 
            this.radioButtonImportList.AutoSize = true;
            this.radioButtonImportList.Checked = true;
            this.radioButtonImportList.Location = new System.Drawing.Point(711, 78);
            this.radioButtonImportList.Name = "radioButtonImportList";
            this.radioButtonImportList.Size = new System.Drawing.Size(69, 17);
            this.radioButtonImportList.TabIndex = 9;
            this.radioButtonImportList.TabStop = true;
            this.radioButtonImportList.Text = "Import list";
            this.radioButtonImportList.UseVisualStyleBackColor = true;
            this.radioButtonImportList.CheckedChanged += new System.EventHandler(this.radioButtonImportList_CheckedChanged);
            // 
            // listBoxPatient
            // 
            this.listBoxPatient.FormattingEnabled = true;
            this.listBoxPatient.Location = new System.Drawing.Point(27, 39);
            this.listBoxPatient.Name = "listBoxPatient";
            this.listBoxPatient.Size = new System.Drawing.Size(195, 108);
            this.listBoxPatient.TabIndex = 10;
            // 
            // buttonImportPatients
            // 
            this.buttonImportPatients.Location = new System.Drawing.Point(27, 14);
            this.buttonImportPatients.Name = "buttonImportPatients";
            this.buttonImportPatients.Size = new System.Drawing.Size(195, 29);
            this.buttonImportPatients.TabIndex = 11;
            this.buttonImportPatients.Text = "Import List Of Patients";
            this.buttonImportPatients.UseVisualStyleBackColor = true;
            this.buttonImportPatients.Click += new System.EventHandler(this.buttonImportPatients_Click);
            // 
            // panelListPatients
            // 
            this.panelListPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListPatients.Controls.Add(this.buttonRemovePatientFromList);
            this.panelListPatients.Controls.Add(this.textBoxPatient);
            this.panelListPatients.Controls.Add(this.buttonAddSinglePatient);
            this.panelListPatients.Controls.Add(this.listBoxPatient);
            this.panelListPatients.Controls.Add(this.buttonImportPatients);
            this.panelListPatients.Location = new System.Drawing.Point(786, 27);
            this.panelListPatients.Name = "panelListPatients";
            this.panelListPatients.Size = new System.Drawing.Size(411, 165);
            this.panelListPatients.TabIndex = 12;
            // 
            // buttonRemovePatientFromList
            // 
            this.buttonRemovePatientFromList.Location = new System.Drawing.Point(245, 108);
            this.buttonRemovePatientFromList.Name = "buttonRemovePatientFromList";
            this.buttonRemovePatientFromList.Size = new System.Drawing.Size(151, 29);
            this.buttonRemovePatientFromList.TabIndex = 14;
            this.buttonRemovePatientFromList.Text = "Remove selected patient from list";
            this.buttonRemovePatientFromList.UseVisualStyleBackColor = true;
            this.buttonRemovePatientFromList.Click += new System.EventHandler(this.buttonRemovePatientFromList_Click);
            // 
            // textBoxPatient
            // 
            this.textBoxPatient.Location = new System.Drawing.Point(245, 23);
            this.textBoxPatient.Name = "textBoxPatient";
            this.textBoxPatient.Size = new System.Drawing.Size(151, 20);
            this.textBoxPatient.TabIndex = 13;
            // 
            // buttonAddSinglePatient
            // 
            this.buttonAddSinglePatient.Location = new System.Drawing.Point(245, 60);
            this.buttonAddSinglePatient.Name = "buttonAddSinglePatient";
            this.buttonAddSinglePatient.Size = new System.Drawing.Size(151, 29);
            this.buttonAddSinglePatient.TabIndex = 12;
            this.buttonAddSinglePatient.Text = "Add patient to list of patients";
            this.buttonAddSinglePatient.UseVisualStyleBackColor = true;
            this.buttonAddSinglePatient.Click += new System.EventHandler(this.buttonAddSinglePatient_Click);
            // 
            // buttonPickDataBase
            // 
            this.buttonPickDataBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonPickDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPickDataBase.Location = new System.Drawing.Point(482, 100);
            this.buttonPickDataBase.Name = "buttonPickDataBase";
            this.buttonPickDataBase.Size = new System.Drawing.Size(140, 54);
            this.buttonPickDataBase.TabIndex = 13;
            this.buttonPickDataBase.Text = "Open";
            this.buttonPickDataBase.UseVisualStyleBackColor = false;
            this.buttonPickDataBase.Click += new System.EventHandler(this.buttonPickDataBase_Click);
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelDataBase.Location = new System.Drawing.Point(31, 67);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(133, 13);
            this.labelDataBase.TabIndex = 14;
            this.labelDataBase.Text = "Template database loaded";
            // 
            // labelPlanPicked
            // 
            this.labelPlanPicked.AutoSize = true;
            this.labelPlanPicked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelPlanPicked.Location = new System.Drawing.Point(31, 88);
            this.labelPlanPicked.Name = "labelPlanPicked";
            this.labelPlanPicked.Size = new System.Drawing.Size(127, 13);
            this.labelPlanPicked.TabIndex = 15;
            this.labelPlanPicked.Text = "Template protocol loaded";
            // 
            // panelFilter
            // 
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.textBoxNumberOfPatients);
            this.panelFilter.Controls.Add(this.checkBoxNumberOfPatients);
            this.panelFilter.Controls.Add(this.panelCreationTime);
            this.panelFilter.Controls.Add(this.panelSsnr);
            this.panelFilter.Controls.Add(this.panelAge);
            this.panelFilter.Controls.Add(this.panelSex);
            this.panelFilter.Controls.Add(this.checkBoxPlanCreation);
            this.panelFilter.Controls.Add(this.checkBoxSsnr);
            this.panelFilter.Controls.Add(this.checkBoxAge);
            this.panelFilter.Controls.Add(this.checkBoxSex);
            this.panelFilter.Controls.Add(this.labelSex);
            this.panelFilter.Location = new System.Drawing.Point(786, 27);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(411, 165);
            this.panelFilter.TabIndex = 16;
            this.panelFilter.Visible = false;
            // 
            // textBoxNumberOfPatients
            // 
            this.textBoxNumberOfPatients.Location = new System.Drawing.Point(184, 18);
            this.textBoxNumberOfPatients.Name = "textBoxNumberOfPatients";
            this.textBoxNumberOfPatients.Size = new System.Drawing.Size(45, 20);
            this.textBoxNumberOfPatients.TabIndex = 12;
            this.textBoxNumberOfPatients.Text = "0";
            this.textBoxNumberOfPatients.Visible = false;
            this.textBoxNumberOfPatients.TextChanged += new System.EventHandler(this.textBoxNumberOfPatients_TextChanged);
            // 
            // checkBoxNumberOfPatients
            // 
            this.checkBoxNumberOfPatients.AutoSize = true;
            this.checkBoxNumberOfPatients.Location = new System.Drawing.Point(21, 20);
            this.checkBoxNumberOfPatients.Name = "checkBoxNumberOfPatients";
            this.checkBoxNumberOfPatients.Size = new System.Drawing.Size(156, 17);
            this.checkBoxNumberOfPatients.TabIndex = 11;
            this.checkBoxNumberOfPatients.Text = "Number of wanted patients:";
            this.checkBoxNumberOfPatients.UseVisualStyleBackColor = true;
            this.checkBoxNumberOfPatients.CheckedChanged += new System.EventHandler(this.checkBoxNumberOfPatients_CheckedChanged);
            // 
            // panelCreationTime
            // 
            this.panelCreationTime.BackColor = System.Drawing.SystemColors.Control;
            this.panelCreationTime.Controls.Add(this.label4);
            this.panelCreationTime.Controls.Add(this.dateTimePickerTo);
            this.panelCreationTime.Controls.Add(this.dateTimePickerFrom);
            this.panelCreationTime.Controls.Add(this.label3);
            this.panelCreationTime.Location = new System.Drawing.Point(142, 113);
            this.panelCreationTime.Name = "panelCreationTime";
            this.panelCreationTime.Size = new System.Drawing.Size(260, 53);
            this.panelCreationTime.TabIndex = 9;
            this.panelCreationTime.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "To:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(39, 22);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(187, 20);
            this.dateTimePickerTo.TabIndex = 11;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(39, 2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(187, 20);
            this.dateTimePickerFrom.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "From:";
            // 
            // panelSsnr
            // 
            this.panelSsnr.Controls.Add(this.textBoxSsnr);
            this.panelSsnr.Controls.Add(this.labelSSNR);
            this.panelSsnr.Location = new System.Drawing.Point(132, 88);
            this.panelSsnr.Name = "panelSsnr";
            this.panelSsnr.Size = new System.Drawing.Size(200, 30);
            this.panelSsnr.TabIndex = 8;
            this.panelSsnr.Visible = false;
            // 
            // textBoxSsnr
            // 
            this.textBoxSsnr.Location = new System.Drawing.Point(29, 6);
            this.textBoxSsnr.Name = "textBoxSsnr";
            this.textBoxSsnr.Size = new System.Drawing.Size(171, 20);
            this.textBoxSsnr.TabIndex = 11;
            this.textBoxSsnr.TextChanged += new System.EventHandler(this.textBoxSsnr_TextChanged);
            // 
            // labelSSNR
            // 
            this.labelSSNR.AutoSize = true;
            this.labelSSNR.Location = new System.Drawing.Point(10, 9);
            this.labelSSNR.Name = "labelSSNR";
            this.labelSSNR.Size = new System.Drawing.Size(13, 13);
            this.labelSSNR.TabIndex = 9;
            this.labelSSNR.Text = "=";
            // 
            // panelAge
            // 
            this.panelAge.Controls.Add(this.textBoxAgeTo);
            this.panelAge.Controls.Add(this.textBoxAgeFrom);
            this.panelAge.Controls.Add(this.labelAgeTo);
            this.panelAge.Controls.Add(this.labelAgeFrom);
            this.panelAge.Controls.Add(this.panel2);
            this.panelAge.Location = new System.Drawing.Point(132, 64);
            this.panelAge.Name = "panelAge";
            this.panelAge.Size = new System.Drawing.Size(200, 30);
            this.panelAge.TabIndex = 6;
            this.panelAge.Visible = false;
            // 
            // textBoxAgeTo
            // 
            this.textBoxAgeTo.Location = new System.Drawing.Point(129, 3);
            this.textBoxAgeTo.Name = "textBoxAgeTo";
            this.textBoxAgeTo.Size = new System.Drawing.Size(48, 20);
            this.textBoxAgeTo.TabIndex = 11;
            this.textBoxAgeTo.Text = "120";
            this.textBoxAgeTo.TextChanged += new System.EventHandler(this.textBoxAgeTo_TextChanged);
            // 
            // textBoxAgeFrom
            // 
            this.textBoxAgeFrom.Location = new System.Drawing.Point(49, 3);
            this.textBoxAgeFrom.Name = "textBoxAgeFrom";
            this.textBoxAgeFrom.Size = new System.Drawing.Size(48, 20);
            this.textBoxAgeFrom.TabIndex = 10;
            this.textBoxAgeFrom.Text = "0";
            this.textBoxAgeFrom.TextChanged += new System.EventHandler(this.textBoxAgeFrom_TextChanged);
            // 
            // labelAgeTo
            // 
            this.labelAgeTo.AutoSize = true;
            this.labelAgeTo.Location = new System.Drawing.Point(103, 7);
            this.labelAgeTo.Name = "labelAgeTo";
            this.labelAgeTo.Size = new System.Drawing.Size(23, 13);
            this.labelAgeTo.TabIndex = 9;
            this.labelAgeTo.Text = "To:";
            // 
            // labelAgeFrom
            // 
            this.labelAgeFrom.AutoSize = true;
            this.labelAgeFrom.Location = new System.Drawing.Point(13, 6);
            this.labelAgeFrom.Name = "labelAgeFrom";
            this.labelAgeFrom.Size = new System.Drawing.Size(33, 13);
            this.labelAgeFrom.TabIndex = 8;
            this.labelAgeFrom.Text = "From:";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 33);
            this.panel2.TabIndex = 7;
            // 
            // panelSex
            // 
            this.panelSex.Controls.Add(this.radioButtonFemale);
            this.panelSex.Controls.Add(this.radioButtonMale);
            this.panelSex.Location = new System.Drawing.Point(132, 39);
            this.panelSex.Name = "panelSex";
            this.panelSex.Size = new System.Drawing.Size(140, 23);
            this.panelSex.TabIndex = 5;
            this.panelSex.Visible = false;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(74, 3);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 1;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            this.radioButtonFemale.CheckedChanged += new System.EventHandler(this.radioButtonFemale_CheckedChanged);
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(10, 3);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 0;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // checkBoxPlanCreation
            // 
            this.checkBoxPlanCreation.AutoSize = true;
            this.checkBoxPlanCreation.Location = new System.Drawing.Point(21, 118);
            this.checkBoxPlanCreation.Name = "checkBoxPlanCreation";
            this.checkBoxPlanCreation.Size = new System.Drawing.Size(124, 17);
            this.checkBoxPlanCreation.TabIndex = 4;
            this.checkBoxPlanCreation.Text = "Patient creation date";
            this.checkBoxPlanCreation.UseVisualStyleBackColor = true;
            this.checkBoxPlanCreation.CheckedChanged += new System.EventHandler(this.checkBoxPlanCreation_CheckedChanged);
            // 
            // checkBoxSsnr
            // 
            this.checkBoxSsnr.AutoSize = true;
            this.checkBoxSsnr.Location = new System.Drawing.Point(20, 93);
            this.checkBoxSsnr.Name = "checkBoxSsnr";
            this.checkBoxSsnr.Size = new System.Drawing.Size(108, 17);
            this.checkBoxSsnr.TabIndex = 3;
            this.checkBoxSsnr.Text = "Social Security nr";
            this.checkBoxSsnr.UseVisualStyleBackColor = true;
            this.checkBoxSsnr.CheckedChanged += new System.EventHandler(this.checkBoxSsnr_CheckedChanged);
            // 
            // checkBoxAge
            // 
            this.checkBoxAge.AutoSize = true;
            this.checkBoxAge.Location = new System.Drawing.Point(20, 69);
            this.checkBoxAge.Name = "checkBoxAge";
            this.checkBoxAge.Size = new System.Drawing.Size(45, 17);
            this.checkBoxAge.TabIndex = 2;
            this.checkBoxAge.Text = "Age";
            this.checkBoxAge.UseVisualStyleBackColor = true;
            this.checkBoxAge.CheckedChanged += new System.EventHandler(this.checkBoxAge_CheckedChanged);
            // 
            // checkBoxSex
            // 
            this.checkBoxSex.AutoSize = true;
            this.checkBoxSex.Location = new System.Drawing.Point(20, 43);
            this.checkBoxSex.Name = "checkBoxSex";
            this.checkBoxSex.Size = new System.Drawing.Size(44, 17);
            this.checkBoxSex.TabIndex = 1;
            this.checkBoxSex.Text = "Sex";
            this.checkBoxSex.UseVisualStyleBackColor = true;
            this.checkBoxSex.CheckedChanged += new System.EventHandler(this.checkBoxSex_CheckedChanged);
            // 
            // labelSex
            // 
            this.labelSex.AutoSize = true;
            this.labelSex.Location = new System.Drawing.Point(17, 4);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(99, 13);
            this.labelSex.TabIndex = 0;
            this.labelSex.Text = "Match on following:";
            // 
            // buttonClearResult
            // 
            this.buttonClearResult.Location = new System.Drawing.Point(1093, 675);
            this.buttonClearResult.Name = "buttonClearResult";
            this.buttonClearResult.Size = new System.Drawing.Size(75, 23);
            this.buttonClearResult.TabIndex = 17;
            this.buttonClearResult.Text = "Clear result";
            this.buttonClearResult.UseVisualStyleBackColor = true;
            this.buttonClearResult.Visible = false;
            this.buttonClearResult.Click += new System.EventHandler(this.buttonClearResult_Click);
            // 
            // GroupInvestigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 707);
            this.Controls.Add(this.buttonClearResult);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.labelPlanPicked);
            this.Controls.Add(this.labelDataBase);
            this.Controls.Add(this.buttonPickDataBase);
            this.Controls.Add(this.panelListPatients);
            this.Controls.Add(this.radioButtonImportList);
            this.Controls.Add(this.radioButtonUseFilter);
            this.Controls.Add(this.panelStatistiaclSummary);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPlanPick);
            this.Controls.Add(this.ResultPresentation);
            this.Controls.Add(this.menuOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuOpen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupInvestigation";
            this.Text = "Investigate group of patients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupInvestigation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ResultPresentation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Summary)).EndInit();
            this.panelStatistiaclSummary.ResumeLayout(false);
            this.panelStatistiaclSummary.PerformLayout();
            this.menuOpen.ResumeLayout(false);
            this.menuOpen.PerformLayout();
            this.panelListPatients.ResumeLayout(false);
            this.panelListPatients.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelCreationTime.ResumeLayout(false);
            this.panelCreationTime.PerformLayout();
            this.panelSsnr.ResumeLayout(false);
            this.panelSsnr.PerformLayout();
            this.panelAge.ResumeLayout(false);
            this.panelAge.PerformLayout();
            this.panelSex.ResumeLayout(false);
            this.panelSex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultPresentation;
        private System.Windows.Forms.ComboBox comboBoxPlanPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.DataGridView Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mean;
        private System.Windows.Forms.DataGridViewTextBoxColumn Median;
        private System.Windows.Forms.DataGridViewTextBoxColumn STD;
        private System.Windows.Forms.DataGridViewTextBoxColumn precentagePass;
        private System.Windows.Forms.Panel panelStatistiaclSummary;
        private System.Windows.Forms.Label labelpassed;
        private System.Windows.Forms.Label labelSTD1;
        private System.Windows.Forms.Label labelprecentagePass;
        private System.Windows.Forms.Label labelSTD;
        private System.Windows.Forms.Label labelMedian;
        private System.Windows.Forms.Label labelMean;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuOpen;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controllFilterifSerachingToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonUseFilter;
        private System.Windows.Forms.RadioButton radioButtonImportList;
        private System.Windows.Forms.ListBox listBoxPatient;
        private System.Windows.Forms.Button buttonImportPatients;
        private System.Windows.Forms.Panel panelListPatients;
        private System.Windows.Forms.TextBox textBoxPatient;
        private System.Windows.Forms.Button buttonAddSinglePatient;
        private System.Windows.Forms.Button buttonRemovePatientFromList;
        private System.Windows.Forms.Button buttonPickDataBase;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Label labelPlanPicked;
        private System.Windows.Forms.ToolTip dataBaseReminder;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Panel panelCreationTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSsnr;
        private System.Windows.Forms.TextBox textBoxSsnr;
        private System.Windows.Forms.Label labelSSNR;
        private System.Windows.Forms.Panel panelAge;
        private System.Windows.Forms.TextBox textBoxAgeTo;
        private System.Windows.Forms.TextBox textBoxAgeFrom;
        private System.Windows.Forms.Label labelAgeTo;
        private System.Windows.Forms.Label labelAgeFrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSex;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.CheckBox checkBoxPlanCreation;
        private System.Windows.Forms.CheckBox checkBoxSsnr;
        private System.Windows.Forms.CheckBox checkBoxAge;
        private System.Windows.Forms.CheckBox checkBoxSex;
        private System.Windows.Forms.TextBox textBoxNumberOfPatients;
        private System.Windows.Forms.CheckBox checkBoxNumberOfPatients;
        private System.Windows.Forms.Button buttonClearResult;
    }
}

