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
    public partial class SetNameSimilarity : Form
    {
        DataBase dataBase;
        public SetNameSimilarity(DataBase inDataBase)
        {
            dataBase = inDataBase;
            InitializeComponent();
            labelInfo.Text = "Your value is: " + dataBase.NameSimilarity.ToString();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (!char.IsDigit(this.Text, this.Text.Length - 1))
                this.Text = this.Text.Substring(0, this.Text.Length - 2);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Input.Text != "")
                dataBase.NameSimilarity = Convert.ToDouble(Input.Text);
            this.Close();
        }
    }
}
