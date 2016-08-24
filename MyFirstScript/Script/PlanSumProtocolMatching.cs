using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlanChecker
{
    public partial class PlanSumProtocolMatching : Form
    {
        int planCounter = 1;
        int lastPlanNr = 0;
        List<int> plans = new List<int>();
        PlanSumProtocol protocol;
        public PlanSumProtocolMatching(VMS.TPS.Common.Model.API.PlanSum inplanSum, PlanSumProtocol inProtocol)
        {
            InitializeComponent();
            foreach (var plan in inplanSum.PlanSetups)
                listBoxViewPlans.Items.Add(plan.Id);
            labelPlanName.Text = "plan " + planCounter.ToString();
            lastPlanNr = inplanSum.PlanSetups.Count();
            protocol = inProtocol;

        }
        private void listBoxViewPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxViewPlans.SelectedIndex != -1)
            {
                plans.Add(listBoxViewPlans.SelectedIndex);
                if (planCounter == lastPlanNr)
                {
                    protocol.PartPlanList = plans.ToArray();
                    this.Close();
                }
                labelPlanName.Text = "plan " + (++planCounter).ToString();
            }
        }
    }
}
