using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
namespace PlanChecker
{
    /// <summary>
    /// This class only highlight surten Strucutres, you can do the actual work without them.
    /// </summary>
    [Serializable]
    public class Highlight
    {
        public string Name { get; set; }
        public int A { get; set; }
        public int R{get; set;}
        public int G{get; set;}
        public int B{get; set;}
        public Color Color { get { return Color.FromArgb(A, R, G, B); }}
        public Highlight() { }
        public Highlight(string name, Color color)
        {
            Name = name;
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }
}
