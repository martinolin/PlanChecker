using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PlanChecker
{
    public partial class HighlighterEditor : Form
    {
        DataBase dataBase;
        List<Highlight> colorList = new List<Highlight>();
        public HighlighterEditor(DataBase inDataBase)
        {
            dataBase = inDataBase;
            colorList = dataBase.HighLight;
            InitializeComponent();
        }
        private void PrintList()
        {
            DisplayExamples.Rows.Clear();
            DisplayExamples.RowCount = colorList.Count;
            Font font = new System.Drawing.Font("Arial", 10);
            for (int i = 0; i < colorList.Count; i++)
            {
                DataGridViewCellStyle color= new DataGridViewCellStyle() { ForeColor =colorList.ElementAt(i).Color, Font=font, SelectionBackColor=Color.Transparent};
                DisplayExamples[0,i].Value=colorList.ElementAt(i).Name;
                DisplayExamples.Rows[i].Cells[0].Style = color;
            }
            DisplayExamples.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNew.Text != "")
            {
                colorList.Add(new Highlight(textBoxNew.Text, Color.Black));
                PrintList();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
               colorList = colorList.Where(x => x.Name != textBoxNew.Text).ToList();
            PrintList();
        }

        private void DisplayExamples_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            if (DisplayExamples.HitTest(e.X, e.Y).ColumnIndex == 0)
                if (colorPick.ShowDialog() == DialogResult.OK)
                { colorList.ElementAt(DisplayExamples.HitTest(e.X, e.Y).RowIndex).A = colorPick.Color.A;
                colorList.ElementAt(DisplayExamples.HitTest(e.X, e.Y).RowIndex).R = colorPick.Color.R;
                colorList.ElementAt(DisplayExamples.HitTest(e.X, e.Y).RowIndex).G = colorPick.Color.G;
                colorList.ElementAt(DisplayExamples.HitTest(e.X, e.Y).RowIndex).B = colorPick.Color.B;
                PrintList();
                }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            panelInfo.Visible = false;
            buttonLoad.Visible = false;
            buttonAdd.Visible = true;
            buttonRemove.Visible = true;
            textBoxNew.Visible = true;
            PrintList();
        }

        private void HighlighterEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataBase.HighLight = colorList;
        }
    }
}
