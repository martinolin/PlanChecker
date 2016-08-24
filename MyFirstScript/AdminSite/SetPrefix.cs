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
    public partial class SetPrefix : Form
    {
        DataBase dataBase;
        public SetPrefix(DataBase inDataBase)
        {
            dataBase = inDataBase;
            InitializeComponent();
            labelInfo.Text= "Current prefix length is: " + dataBase.PrefixLength.ToString();
        }

        private void SetPrefix_Load(object sender, EventArgs e)
        {

        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (!char.IsDigit(this.Text, this.Text.Length - 1))
                this.Text = this.Text.Substring(0, this.Text.Length - 2);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Input.Text != "")
                dataBase.PrefixLength = Convert.ToInt32(Input.Text);
            this.Close();
        }
    }
}
