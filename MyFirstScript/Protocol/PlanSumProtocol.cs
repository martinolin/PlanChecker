using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace PlanChecker
{
    /// <summary>
    /// This is for sums of plans. 
    /// </summary>
    [Serializable]
    public class PlanSumProtocol : Protocol
    {

        private List<int> allSubFractions = new List<int>();
        private List<double> allSubDoses = new List<double>();
        private List<int> partPlanList = new List<int>();
        public PlanSumProtocol()
        { }
        public PlanSumProtocol(String inName, List<int> inFractions, List<double> inDose)
        {
            name = inName;
            dose = -1;
            fractions = -1;
            allSubDoses = new List<double>(inDose);
            allSubFractions = new List<int>(inFractions);
        }
        public int[] AllSubFractions { get { return allSubFractions.ToArray(); } set { allSubFractions = new List<int>(value); } }
        public double[] AllSubDoses { get { return allSubDoses.ToArray(); } set { allSubDoses = new List<double>(value); } }
        public int[] PartPlanList { get { return partPlanList.ToArray(); } set { partPlanList = new List<int>(value); } }

        override public bool SetPartPlanIndex(VMS.TPS.Common.Model.API.PlanSum inplanSum)
        {
            //look for unique subdoses and fractions otherwise match on names, but will give a warning then. If forced matching happens we may not even have the same number of plans
            //or have the correct matches, in these cases subplan evaluation can be done and the user must use a protocol for a single plan.
            bool found = false;
            int hits = 0;
            int addedOn = 0;
            for (int plan = 0; plan < allSubDoses.Count; plan++)
            {
                found = false;
                hits = 0;
                for (int otherplan = 0; otherplan < inplanSum.PlanSetups.Count(); otherplan++)
                {
                    if (inplanSum.PlanSetups.ElementAt(otherplan).UniqueFractionation.NumberOfFractions == allSubFractions.ElementAt(plan) && inplanSum.PlanSetups.ElementAt(otherplan).UniqueFractionation.PrescribedDosePerFraction.Dose == allSubDoses.ElementAt(plan))
                    {
                        if (found)
                            hits++;
                        else
                        {
                            found = true;
                            try
                            {
                                partPlanList.Insert(otherplan, plan);
                                addedOn = otherplan;
                                hits++;
                            }
                            catch { return false; };
                        }
                    }
                }
                if (hits != 1) //problems
                {
                    return false;
                }
            }
            return true;
        }
        override public int GetPartPlanIndex(int thePlanNumberWeWant)
        {
            int index = 0;
            while (PartPlanList[index] != thePlanNumberWeWant - 1)
                index++;
            return index;
        }
        public void AddSubProtocol(double subDose, int subFraction)
        {
            allSubDoses.Add(subDose);
            allSubFractions.Add(subFraction);
        }
        override public List<int> GetSubFractions()
        {
            return allSubFractions;
        }
        override public List<double> GetSubDoses()
        {
            return allSubDoses;
        }

        override public string GetListName()
        {
            string DF = "";
            for (int i = 0; i < allSubDoses.Count(); i++)
            {
                DF = DF + " " + allSubDoses[i].ToString() + "|" + allSubFractions[i].ToString();
            }
            return "PlanSum: " + name + DF;
        }
    }
}
