using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    public class IncreaseListOfCriteria : EventArgs
    {
        public string Structure { get; set; }
        public string Criteria { get; set; }
        public IncreaseListOfCriteria(string structure, string ciritera)
        {
            Structure = structure;
            Criteria = ciritera;
        }
    }
}
