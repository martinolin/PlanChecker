namespace PlanChecker
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelPatientId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelPlanid = new System.Windows.Forms.Label();
            this.labelSortMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSortmode = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxPlanPick = new System.Windows.Forms.ComboBox();
            this.ResultatPresentation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultatPresentation)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPatientId
            // 
            resources.ApplyResources(this.labelPatientId, "labelPatientId");
            this.labelPatientId.Name = "labelPatientId";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelUpdate);
            this.panel1.Controls.Add(this.buttonHelp);
            this.panel1.Controls.Add(this.labelPlanid);
            this.panel1.Controls.Add(this.labelSortMode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxSortmode);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.comboBoxPlanPick);
            this.panel1.Controls.Add(this.labelPatientId);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // labelUpdate
            // 
            resources.ApplyResources(this.labelUpdate, "labelUpdate");
            this.labelUpdate.Name = "labelUpdate";
            // 
            // buttonHelp
            // 
            resources.ApplyResources(this.buttonHelp, "buttonHelp");
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelPlanid
            // 
            resources.ApplyResources(this.labelPlanid, "labelPlanid");
            this.labelPlanid.Name = "labelPlanid";
            this.labelPlanid.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelSortMode
            // 
            resources.ApplyResources(this.labelSortMode, "labelSortMode");
            this.labelSortMode.Name = "labelSortMode";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxSortmode
            // 
            this.comboBoxSortmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortmode.DropDownWidth = 112;
            this.comboBoxSortmode.FormattingEnabled = true;
            this.comboBoxSortmode.Items.AddRange(new object[] {
            resources.GetString("comboBoxSortmode.Items"),
            resources.GetString("comboBoxSortmode.Items1"),
            resources.GetString("comboBoxSortmode.Items2")});
            resources.ApplyResources(this.comboBoxSortmode, "comboBoxSortmode");
            this.comboBoxSortmode.Name = "comboBoxSortmode";
            this.comboBoxSortmode.SelectedIndex = 0;
            this.comboBoxSortmode.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownWidth = 63;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1")});
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxPlanPick
            // 
            this.comboBoxPlanPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanPick.DropDownWidth = 277;
            this.comboBoxPlanPick.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxPlanPick, "comboBoxPlanPick");
            this.comboBoxPlanPick.Name = "comboBoxPlanPick";
            // 
            // ResultatPresentation
            // 
            this.ResultatPresentation.AllowUserToAddRows = false;
            this.ResultatPresentation.AllowUserToDeleteRows = false;
            this.ResultatPresentation.AllowUserToResizeColumns = false;
            this.ResultatPresentation.AllowUserToResizeRows = false;
            this.ResultatPresentation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.ResultatPresentation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultatPresentation.ColumnHeadersVisible = false;
            this.ResultatPresentation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N8";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultatPresentation.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.ResultatPresentation, "ResultatPresentation");
            this.ResultatPresentation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ResultatPresentation.GridColor = System.Drawing.Color.Black;
            this.ResultatPresentation.Name = "ResultatPresentation";
            this.ResultatPresentation.RowHeadersVisible = false;
            this.ResultatPresentation.TabStop = false;
            this.ResultatPresentation.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // MainWindow
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResultatPresentation);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultatPresentation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPatientId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPlanPick;
        private System.Windows.Forms.DataGridView ResultatPresentation;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ComboBox comboBoxSortmode;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label labelSortMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPlanid;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelUpdate;
    }
}