using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    /// <summary>
    /// This is the default Protocol choosen when we fail to find a protocol for a plan.
    /// </summary>
    [Serializable]
    public class UnknownProtocol:Protocol
    {
        public UnknownProtocol()
        {
            Name = "unknown";
            Dose = 1;
            Fractions = 1;
            this.CreatedBy = "Martin Olin";
            this.LastUpdated = "never";
        }
        override public string GetListName()
        {
            return "unknown";
        }
    }
}
