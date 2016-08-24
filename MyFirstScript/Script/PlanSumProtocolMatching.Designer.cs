namespace PlanChecker
{
    partial class PlanSumProtocolMatching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanSumProtocolMatching));
            this.labelPlanName = new System.Windows.Forms.Label();
            this.nothing = new System.Windows.Forms.Label();
            this.listBoxViewPlans = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelPlanName
            // 
            this.labelPlanName.AutoSize = true;
            this.labelPlanName.Location = new System.Drawing.Point(12, 22);
            this.labelPlanName.Name = "labelPlanName";
            this.labelPlanName.Size = new System.Drawing.Size(56, 13);
            this.labelPlanName.TabIndex = 1;
            this.labelPlanName.Text = "plan name";
            // 
            // nothing
            // 
            this.nothing.AutoSize = true;
            this.nothing.Location = new System.Drawing.Point(30, 45);
            this.nothing.Name = "nothing";
            this.nothing.Size = new System.Drawing.Size(18, 13);
            this.nothing.TabIndex = 2;
            this.nothing.Text = "as";
            // 
            // listBoxViewPlans
            // 
            this.listBoxViewPlans.FormattingEnabled = true;
            this.listBoxViewPlans.Location = new System.Drawing.Point(74, 12);
            this.listBoxViewPlans.Name = "listBoxViewPlans";
            this.listBoxViewPlans.Size = new System.Drawing.Size(199, 95);
            this.listBoxViewPlans.TabIndex = 3;
            this.listBoxViewPlans.SelectedIndexChanged += new System.EventHandler(this.listBoxViewPlans_SelectedIndexChanged);
            // 
            // PlanSumProtocolMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 115);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxViewPlans);
            this.Controls.Add(this.nothing);
            this.Controls.Add(this.labelPlanName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlanSumProtocolMatching";
            this.Text = "PlanSumProtocolMatching";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlanName;
        private System.Windows.Forms.Label nothing;
        private System.Windows.Forms.ListBox listBoxViewPlans;

    }
}