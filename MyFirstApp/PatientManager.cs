
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlanChecker;
using VMS.TPS.Common.Model.API;


namespace PlanCheckerGroup
{
    /// <summary>
    /// Will handle several patients and run them through a ProtocolManager and store the result.
    /// </summary>
    class PatientManager
    {
        public List<string> PrintStructures { get { return structures; } }
        public List<string> PrintCriterias { get { return criterias; } }
        public List<string> PrintPersonnrs { get { return personnrs; } }
        public List<string> PrintPlanNames { get { return planNames; } }
        public List<List<double>> Values { get { return values; } }
        public List<List<double>> ValuesWithNaN { get { return valuesWithNaN; } }
        public List<List<bool>> Passed { get { return passed; } }
        public List<List<bool>> PassedWithNaN { get { return passedWithNaN; } }
        List<string> structures = new List<string>();
        List<string> criterias = new List<string>();
        List<string> personnrs = new List<string>();
        List<string> planNames = new List<string>();
        List<List<double>> values = new List<List<double>>();
        List<List<double>> valuesWithNaN = new List<List<double>>();
        List<List<bool>> passed = new List<List<bool>>();
        List<List<bool>> passedWithNaN = new List<List<bool>>();
        ProtocolManager protocolManager = new ProtocolManager();
        int listLength = 0;
        int investigationNumber = 0;
        bool invalidateUncertaintyPlanEvaluations = false; // will be set to true if found out that some plan have another amount of these uncertainty plans.
        int expectedNumberOfUncertaintyPlans;
        bool firstPatient = true;
        public ProtocolManager ProtocolManager { get { return protocolManager; } }
        public void SetProtocol(int index)
        {
            protocolManager.SetProtocol(index);
        }

        public void InvestigatePatientWithFixedProtocol(Patient patient)
        {
            if (protocolManager.Protocol.Dose == -1)
            {
                foreach (Course course in patient.Courses)
                {
                    foreach (PlanSum planSum in course.PlanSums)
                        if (protocolManager.PlanValidForThisProtcol(planSum))
                        {
                            Filtering.AddAHit();
                            personnrs.Add(patient.Id);
                            planNames.Add(planSum.Id);
                            protocolManager.MatchInternalsInPlanSum(planSum);
                            protocolManager.MatchStrucutres(planSum);
                            protocolManager.AnalyzeProtocol(planSum);
                            GatherInfo();
                        }
                }
            }
            else
            {
                foreach (Course course in patient.Courses)
                {

                    for (int i = 0; i < course.PlanSetups.Count(); i++)
                        if (protocolManager.PlanValidForThisProtcol(course.PlanSetups.ElementAt(i)))
                        {
                            protocolManager.ResetAllButProtocolPick();
                            Filtering.AddAHit();
                            personnrs.Add(patient.Id);
                            planNames.Add(course.PlanSetups.ElementAt(i).Id);
                            protocolManager.MatchStrucutres(course.PlanSetups.ElementAt(i));
                            protocolManager.AnalyzeProtocol(course.PlanSetups.ElementAt(i));
                            GatherInfo();
                        }
                }
            }
        }
        private void InvestigatePatientsUnkownPlan(Patient patient, PlanSetup planSetup)
        {
            if (!invalidateUncertaintyPlanEvaluations)
            {
                personnrs.Add(patient.Id);
                planNames.Add(planSetup.Id);
                try
                {
                    protocolManager.ResetAllButProtocolPick();
                    protocolManager.BestProtocolGuess(planSetup.Id.ToString(), planSetup.UniqueFractionation.NumberOfFractions.Value, Math.Round(planSetup.UniqueFractionation.PrescribedDosePerFraction.Dose, 4));
                    protocolManager.MatchStrucutres(planSetup);
                    protocolManager.AnalyzeProtocol(planSetup);
                    if (firstPatient) //make sure we print out result the same way to the same number of criteras..
                    {
                        firstPatient = false;
                        expectedNumberOfUncertaintyPlans = protocolManager.UncertaintyPlansCount();
                    }
                    if (expectedNumberOfUncertaintyPlans == protocolManager.UncertaintyPlansCount())
                        GatherInfo();
                    else
                        invalidateUncertaintyPlanEvaluations = true;
                }
                catch
                {
                    GatherInfoFromInvalidPlan();
                }
            }
            else
                GatherInfoFromInvalidPlan();

        }
        private void InvestigatePatientsUnkownPlanSum(Patient patient, PlanSum planSum)
        {
            personnrs.Add(patient.Id);
            planNames.Add(planSum.Id);
            List<int> fractions = new List<int>();
            List<double> doses = new List<double>();
            string[] localplanNames = new string[planSum.PlanSetups.Count()];
            int nameCounter = 0;
            try
            {
                foreach (PlanSetup ps in planSum.PlanSetups)
                {
                    fractions.Add(ps.UniqueFractionation.NumberOfFractions.Value);
                    doses.Add(Math.Round(ps.UniqueFractionation.PrescribedDosePerFraction.Dose, 4));
                    localplanNames[nameCounter++] = ps.Id;
                }
                protocolManager.BestPlanSumProtocolGuess(localplanNames, fractions, doses);
                protocolManager.MatchInternalsInPlanSum(planSum);
                protocolManager.MatchStrucutres(planSum);
                protocolManager.AnalyzeProtocol(planSum);
                Filtering.AddAHit();
                GatherInfo();
            }
            catch
            {
                GatherInfoFromInvalidPlan();
            }
        }
        public void GatherStrucutresAndCriteraInfo()
        {
            int i = 0;
            if (protocolManager.Protocol.Dose == -1) //Flags for PlanSum
                foreach (var s in protocolManager.Protocol.Structures)
                    foreach (var c in s.Criteria)
                    {
                        structures.Add(s.Name);
                        if (c.PartPlan != 0) // part plan
                            criterias.Add(c.Priority.ToString() + ": P" + c.PartPlan + c.Name);
                        else
                            criterias.Add(c.Priority.ToString() + ": " + c.Name);

                        i++;
                    }
            else
                foreach (var s in protocolManager.Protocol.Structures)
                    foreach (var c in s.Criteria)
                    {
                        structures.Add(s.Name);
                        if (c.PartPlan != 0) // uncertainty plan
                            criterias.Add(c.Priority.ToString() + ": U " + c.Name);
                        else
                            criterias.Add(c.Priority.ToString() + ": " + c.Name);
                        i++;
                    }
            listLength = i;
        }
        private void GatherInfo()
        {
            List<double> valuesForThisPlan = new List<double>(listLength);
            List<bool> passesForThisPlan = new List<bool>(listLength);
            foreach (var s in protocolManager.Protocol.Structures)
                if (s.NameCertainty > protocolManager.NameCertaintyThreashold)
                    foreach (var c in s.Criteria)
                    {
                        valuesForThisPlan.Add(c.ReadValue);
                        passesForThisPlan.Add(c.Passed);
                    }
                else
                    foreach (var c in s.Criteria)
                    {
                        valuesForThisPlan.Add(double.NaN);
                        passesForThisPlan.Add(false);
                    }
            values.Add(valuesForThisPlan);
            passed.Add(passesForThisPlan);
            investigationNumber++;
        }
        private void GatherInfoFromInvalidPlan()
        {

            List<double> valuesForThisPlan = new List<double>();
            valuesForThisPlan.Add(double.NaN);
            List<bool> passesForThisPlan = new List<bool>();
            passesForThisPlan.Add(false);
            values.Add(valuesForThisPlan);
            passed.Add(passesForThisPlan);
            investigationNumber++;
        }
        public void Reset()
        {
            firstPatient = true;
            invalidateUncertaintyPlanEvaluations = false;
            listLength = 0;
            investigationNumber = 0;
            invalidateUncertaintyPlanEvaluations = false; // will be set to true if found out that some plan have another amount of these uncertainty plans.
            firstPatient = true;
            structures = new List<string>();
            criterias = new List<string>();
            personnrs = new List<string>();
            planNames = new List<string>();
            values = new List<List<double>>();
            valuesWithNaN = new List<List<double>>();
            passed = new List<List<bool>>();
            passedWithNaN = new List<List<bool>>();

        }
        public bool EnsureNoUncertaintyPlanEvalutionForDataBaseFiltering()
        {
            bool ans = true;
            if (protocolManager.Protocol.Dose == -1)
            {
            }
            else
            {
                foreach (var structure in protocolManager.Protocol.Structures)
                    foreach (var criterion in structure.Criteria)
                        if (criterion.PartPlan != 0)
                            ans = false;
            }
            return ans;
        }
        public List<List<double>> ExtractStatisticalData()
        {
            int t = 0;
            List<double> NoNaN = new List<double>();
            List<int> NoNaNpasses = new List<int>();
            List<double> Mean = new List<double>();
            List<double> Median = new List<double>();
            List<double> STD = new List<double>();
            List<double> passprecentage = new List<double>();
            List<List<double>> ansValues = new List<List<double>>();
            List<List<double>> ansStatistical = new List<List<double>>();
            List<List<int>> ansPass = new List<List<int>>();
            if (values.Count > 0)
                for (int y = 0; y < values.First().Count; y++)
                {
                    t = 0;
                    List<double> v = new List<double>();
                    List<int> p = new List<int>();
                    foreach (var value in values)
                    {
                        if (!double.IsNaN(value.ElementAt(y)))
                        {
                            v.Add(value.ElementAt(y));
                            if (passed.ElementAt(t).ElementAt(y))
                                p.Add(1);
                            else
                                p.Add(0);
                        } ++t;
                    }
                    ansValues.Add(v);
                    ansPass.Add(p);
                }
            t = 0;
            int length;
            double mean;
            double std;
            foreach (var valueInAns in ansValues)
            {
                length = valueInAns.Count;
                if (length > 0)
                {
                    mean = valueInAns.Sum() / length;
                    Mean.Add(mean);
                    valueInAns.Sort();
                    if (length % 2 == 0)
                    {
                        Median.Add((valueInAns.ElementAt(Convert.ToInt32(length / 2 - 1)) + valueInAns.ElementAt(length / 2)) / 2);
                    }
                    else

                        Median.Add(valueInAns.ElementAt(Convert.ToInt32(length / 2 - 0.5)));
                    std = 0;
                    foreach (var value in valueInAns)
                        std += (value - mean) * (value - mean);
                    STD.Add(Math.Sqrt(std * 1 / length));
                    passprecentage.Add(Convert.ToDouble(ansPass.ElementAt(t++).Sum()) / length);
                }
                else
                {
                    Mean.Add(double.NaN);
                    Median.Add(double.NaN);
                    STD.Add(double.NaN);
                    passprecentage.Add(double.NaN);
                }
            }
            ansStatistical.Add(Mean);
            ansStatistical.Add(Median);
            ansStatistical.Add(STD);
            ansStatistical.Add(passprecentage);
            return ansStatistical;
        }
    }
}
