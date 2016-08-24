using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.TPS.Common.Model.API;
using System.Windows.Forms;
using System.Reflection;
namespace PlanChecker
{
    /// <summary>
    /// this class handles protocols(templates) and can evaluates them.
    /// </summary>
    public class ProtocolManager 
    {
        private double nameCertaintyThreashold; // letter similiarty in structures for acceptance can be set from adminsite
        public double NameCertaintyThreashold { get { return nameCertaintyThreashold; } }
        private bool calculatePlanSumProtocol = true; // we can turn this off and then we can no longer calcualte planSums
        private List<string> normalOrder = new List<string>();
        List<PlanSetup> uncertaintyPlans = new List<PlanSetup>();
        private DataBase dataBase;
        public string DataBasePath { get; set; }
        int prefixLength;
        bool doSinglePlanCritera = true;
        bool foundUncertaintyPlans = false;
        public bool FoundUncertaintyPlans { get { return foundUncertaintyPlans; } set { foundUncertaintyPlans = value; } }
        Protocol protocol;
        public ProtocolManager() 
        {
        }
        public void UseScriptDataBase()
        {
            try
            {
                if (SettingsScript.Default.CustomScriptDataBase)
                {
                    dataBase = Serialization.XMLFileDeserialize<DataBase>(SettingsScript.Default.CustomScriptDataBasePath);
                    DataBasePath = SettingsScript.Default.CustomScriptDataBasePath;
                }
                else
                {
                    string path4 = Assembly.GetExecutingAssembly().Location;
                    string midpath4 = path4.Substring(0, path4.LastIndexOf("\\")) + "\\Scriptdatabase.xml";
                    midpath4.Replace("/", "\\");
                    dataBase = Serialization.XMLFileDeserialize<DataBase>(midpath4);
                    DataBasePath = midpath4;
                }
                prefixLength = dataBase.PrefixLength;
                nameCertaintyThreashold = dataBase.NameSimilarity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public int UncertaintyPlansCount()
        {
            return uncertaintyPlans.Count();
        }
        public void SetDataBase(string path)
        {
            try
            {
                dataBase = Serialization.XMLFileDeserialize<DataBase>(path);
                DataBasePath = path;
                prefixLength = dataBase.PrefixLength;
                nameCertaintyThreashold = dataBase.NameSimilarity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Protocol Protocol { get { return protocol; } }
        public DataBase DataBase { get { return dataBase; } set { dataBase = value; } }
        private bool SameSubPlans(List<int> fractions, List<double> dosePerFraction, Protocol protocolToCheckAgainst)
        {
            List<int> tempFractions = new List<int>(fractions);
            List<double> TempDosePerFraction = new List<double>(dosePerFraction);
            List<int> subsfr = new List<int>(protocolToCheckAgainst.GetSubFractions());
            List<double> subsdo = new List<double>(protocolToCheckAgainst.GetSubDoses());
            bool notFound = true;
            int t;

            for (int i = protocolToCheckAgainst.GetSubFractions().Count() - 1; i >= 0; i--) // can we find a match for all dose and fractions in all plans?
            {
                t = tempFractions.Count - 1;
                notFound = true;
                do
                {
                    if (tempFractions.ElementAt(t) == subsfr.ElementAt(i) && TempDosePerFraction.ElementAt(t) == subsdo.ElementAt(i))
                    {
                        notFound = false;
                        tempFractions.RemoveAt(t);
                        TempDosePerFraction.RemoveAt(t);
                        subsdo.RemoveAt(i);
                        subsfr.RemoveAt(i);
                    }
                    t--;
                } while (notFound && t >= 0);
            }
            return (tempFractions.Count == 0 && subsdo.Count == 0);
        }
        public void BestPlanSumProtocolGuess(string[] planNames, List<int> fractions, List<double> dosePerFraction)
        {
            string currentplan;
            Protocol bestGuess = new Protocol();
            double bestScore = 0;
            double similarityScore = 0;
            string tryMatchWithThisPlan = "";
            int numberOfSubPlans = fractions.Count();
            int protocolIndex = 0;
            string prefix = "";
            foreach (Protocol prots in dataBase.Protocols)
            {

                if (prots.Fractions == -1 && prots.Dose == -1) // Flags for PlanSum
                {
                    //same amount of subplans?
                    if (prots.GetSubFractions().Count() == numberOfSubPlans)
                    {

                        if (SameSubPlans(fractions, dosePerFraction, prots)) //was matched.
                        {
                            for (int i = numberOfSubPlans - 1; i > -1; i--)
                            {
                                tryMatchWithThisPlan = prots.Name;

                                currentplan = planNames[i];
                                if (currentplan.Length > prefixLength) //remove Px_x in name
                                {
                                    prefix = currentplan.Substring(0, prefixLength);
                                    currentplan = currentplan.Substring(prefixLength, currentplan.Length - prefixLength);
                                    if (currentplan[0] == ' ')
                                    {
                                        prefix = prefix + " ";
                                        if (currentplan.Length > 1)
                                            currentplan = currentplan.Substring(1, currentplan.Length - 1);
                                        else
                                            prefix = prefix.Substring(0, prefixLength);
                                    }
                                }
                                similarityScore = NameSimilairty(tryMatchWithThisPlan, currentplan);
                                if (similarityScore > bestScore)
                                {
                                    bestScore = similarityScore;
                                    bestGuess = dataBase.Protocols[protocolIndex];
                                }

                            }
                        }
                    }
                }
                protocolIndex++;
            }

            if (bestScore > nameCertaintyThreashold) //testThisParameter...
            {
                if (bestScore != 1)
                    MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "Your PlanSum was estimated as " + bestGuess.Name, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SetProtocolToUnkown();
                //  MessageBox.Show("unknown plan", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            protocol = bestGuess;
        }
        public bool PlanValidForThisProtcol(PlanSetup planSetup)
        {
            if (protocol.Dose == planSetup.UniqueFractionation.PrescribedDosePerFraction.Dose && protocol.Fractions == planSetup.UniqueFractionation.NumberOfFractions.Value)
            {
                string planName = RemovePrefix(planSetup.Id);
                if (NameSimilairty(protocol.Name, planName) > nameCertaintyThreashold)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool PlanValidForThisProtcol(PlanSum planSum)
        {
            int count = planSum.PlanSetups.Count();
            int nameCounter = 0;
            List<int> fractions = new List<int>(count);
            List<double> doses = new List<double>(count);
            string[] planNames = new string[count];
            foreach (PlanSetup ps in planSum.PlanSetups)
            {
                fractions.Add(ps.UniqueFractionation.NumberOfFractions.Value);
                doses.Add(ps.UniqueFractionation.PrescribedDosePerFraction.Dose);
                planNames[nameCounter++] = ps.Id;
            }

            /////
            if (protocol.GetSubFractions().Count() == fractions.Count())
            {
                if (SameSubPlans(fractions, doses, protocol))
                {
                    string tryMatchWithThisPlan = protocol.Name;
                    string currentplan;
                    double similarityScore;
                    double bestScore = 0;
                    for (int i = fractions.Count - 1; i > 0; i--)
                    {
                        currentplan = RemovePrefix(planNames[i]);

                        similarityScore = NameSimilairty(tryMatchWithThisPlan, currentplan);
                        if (similarityScore > bestScore)
                        {
                            bestScore = similarityScore;
                        }

                    }
                    if (bestScore > nameCertaintyThreashold)
                        return true;
                    else return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        private string RemovePrefix(string nameYourPlan)
        {
            if (nameYourPlan.Length > prefixLength) //remove Px_x in name
            {
                nameYourPlan = nameYourPlan.Substring(prefixLength, nameYourPlan.Length - prefixLength);
                if (nameYourPlan[0] == ' ')
                {
                    if (nameYourPlan.Length > 1)
                        nameYourPlan = nameYourPlan.Substring(1, nameYourPlan.Length - 1);
                }
            }
            return nameYourPlan;
        }
        public Protocol BestProtocolGuess(string searchForPlan, int fractions, double dosePerFraction)
        {
            string currentplan = "";
            string currentplanOrginal = currentplan;
            currentplan = currentplan.ToLower();
            string search = currentplan; //will be mannipulated in function and reseted.
            Protocol bestGuess = new Protocol();
            double bestScore = 0;
            double similarityScore = 0;
            string prefix = "";
            string tryMatchWithThisPlan = "";
            int protocolIndex = 0;
            foreach (Protocol prots in dataBase.Protocols)
            {
                if (prots.Fractions == fractions && prots.Dose == dosePerFraction)
                {
                    currentplan = searchForPlan;
                    tryMatchWithThisPlan = prots.Name;
                    //////remove prefix
                    if (currentplan.Length > prefixLength) //remove Px_x in name
                    {
                        prefix = currentplan.Substring(0, prefixLength);
                        currentplan = currentplan.Substring(prefixLength, currentplan.Length - prefixLength);
                        if (currentplan[0] == ' ')
                        {
                            prefix = prefix + " ";
                            if (currentplan.Length > 1)
                                currentplan = currentplan.Substring(1, currentplan.Length - 1);
                            else
                                prefix = prefix.Substring(0, prefixLength);
                        }
                    }
                    //////////
                    similarityScore = NameSimilairty(tryMatchWithThisPlan, currentplan);
                    if (similarityScore > bestScore)
                    {
                        bestScore = similarityScore;
                        bestGuess = dataBase.Protocols[protocolIndex];
                    }

                }
                protocolIndex++;
            }

            if (bestScore > nameCertaintyThreashold) //testThisParameter...
            {
                if (bestScore != 1)
                    MessageBox.Show(searchForPlan + " was estimated as " + bestGuess.Name, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "unknown plan", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bestGuess = dataBase.GetProtocol("unknown");
            }
            return bestGuess;
        }
        private void SetUnkownProtocol()
        {
            protocol = dataBase.GetProtocol("unknown");
        }
        public void SetProtocol(int index)
        {
            protocol = dataBase.GetProtocol(index);
        }
        public void GetUncertaintyPlans(PlanSetup planSetup)
        {
            int test;
            if (!foundUncertaintyPlans)
            {
                AboveDoseAbsAtVolumeAbsCriterion c = new AboveDoseAbsAtVolumeAbsCriterion(100, 1, 1, 1);
                  c.Analyze(planSetup, planSetup.StructureSet.Structures.First());

                  foreach (var p in planSetup.Course.PlanSetups)
                  {
                      if (p.Id[0] == 'U')
                          if (int.TryParse(p.Id.Substring(1),out test))
                              uncertaintyPlans.Add(p);
                  }
                  foundUncertaintyPlans = true;
            }
        }
        public void ChangeProtocol(PlanSetup planSetup)
        {
            try
            {
                protocol = BestProtocolGuess(planSetup.Id.ToString(), planSetup.UniqueFractionation.NumberOfFractions.Value, Math.Round(planSetup.UniqueFractionation.PrescribedDosePerFraction.Dose, 4));
            }
            catch (Exception)
            {
                SetProtocolToUnkown();
            }
            MatchStrucutres(planSetup);
        }
        public string ChangeProtocol(PlanSum planSum)
        {
            List<int> fractions = new List<int>();
            List<double> doses = new List<double>();
            string[] planNames = new string[planSum.PlanSetups.Count()];
            int nameCounter = 0;
            string labelName = "";
            try
            {
                foreach (PlanSetup ps in planSum.PlanSetups)
                {
                    fractions.Add(ps.UniqueFractionation.NumberOfFractions.Value);
                    doses.Add(Math.Round(ps.UniqueFractionation.PrescribedDosePerFraction.Dose, 4));
                    planNames[nameCounter++] = ps.Id;
                }
                foreach (PlanSetup p in planSum.PlanSetups)
                    labelName += p.Id.ToString() + " + ";
                if (labelName.Length > 0)
                    labelName = labelName.Substring(0, labelName.Length - 2);
                else
                    labelName = "empty Plan Sum";
                BestPlanSumProtocolGuess(planNames, fractions, doses);
                if (protocol.Fractions == -1 && protocol.Dose == -1)
                {
                    MatchInternalsInPlanSum(planSum);
                }
                MatchStrucutres(planSum);
            }
            catch (Exception)
            {
                SetProtocolToUnkown();
            }
            return labelName;
        }
        public void SetProtocolToUnkown()
        {
            protocol = dataBase.GetProtocol("unknown");
        }
        public string BestProtocolGuess(string currentplan)// converts to and compares lowercases only. handle spaces infront?
        {
            List<String> namePool = dataBase.GetProtocolNames();
            // namePool = namePool.Select(x => x.ToLower()).ToList();
            string prefix = "";
            if (currentplan.Length > prefixLength) //remove Px_x in name
            {
                prefix = currentplan.Substring(0, prefixLength);
                currentplan = currentplan.Substring(prefixLength, currentplan.Length - prefixLength);
                if (currentplan[0] == ' ')
                {
                    prefix = prefix + " ";
                    if (currentplan.Length > 1)
                        currentplan = currentplan.Substring(1, currentplan.Length - 1);
                    else
                        prefix = prefix.Substring(0, prefixLength);
                }
            }
            string currentplanOrginal = currentplan;
            currentplan = currentplan.ToLower();
            string search = currentplan; //will be mannipulated in function and reseted.
            string bestGuess = "unknown";
            double bestScore = 0;
            double similarityScore = 0;
            int index = 0;
            bool exactNameFound = false;

            foreach (String tryMatchWithThis in namePool)
            {
                index = search.IndexOf(tryMatchWithThis.ToLower());
                if (index != -1)
                {
                    bestGuess = tryMatchWithThis;
                    exactNameFound = true;
                }
            }

            if (!exactNameFound) // find best Guess.
            {
                foreach (String tryMatchWithThis in namePool)
                {
                    similarityScore = NameSimilairty(tryMatchWithThis, currentplan);
                    if (similarityScore > bestScore)
                    {
                        bestScore = similarityScore;
                        bestGuess = tryMatchWithThis;
                    }
                }
            }
            if (bestScore > nameCertaintyThreashold) //testThisParameter...
            {
                if (bestScore != 1)
                    MessageBox.Show(prefix + currentplanOrginal + " was estimated as " + bestGuess, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "unknown plan", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bestGuess = "unknown";
            }
            //System.Threading.Thread.Sleep(500);
            //SendKeys.Send("~");

            return bestGuess;
        }
        public void SortStructureNormalOrder()
        {
            int t = 0;
            int i = 0;
            foreach (string name in normalOrder)
            {
                i = 0;
                while (name != protocol.GetStructureNames()[i])//and not over the length but maybe overally defensive? // arrays send by ref in c#= else this is stupid as hell
                {
                    i++;
                }
                protocol.Swap(i, t);
                t++;
            }
        }
        public void SortStructureNameCertainty()
        {
            protocol.Structures = protocol.Structures.OrderBy(o => o.NameCertainty).ToArray();
        }
        public void SortStrucutreHealthStatus()
        {
            protocol.Structures = protocol.Structures.OrderBy(o => o.HealthStatus).ToArray();
        }
        private double NameSimilairty(string tryMatchWithThis, string currentplan)
        {
            double hits = 0;
            int index = 0;

            string search = currentplan;
            search = search.ToLower();
            tryMatchWithThis = tryMatchWithThis.ToLower();
            double trueMatchFactor = 1;
            if (search != tryMatchWithThis)
                trueMatchFactor = 0.95;

            for (int i = 0; i < tryMatchWithThis.Length; i++)
            {
                index = search.IndexOf(tryMatchWithThis[i]);
                if (index != -1)
                {

                    hits++;
                    search = search.Remove(index, 1);
                }

            }
            return (double)hits * 2 / (currentplan.Length + tryMatchWithThis.Length) * trueMatchFactor; //similiartyScore 
        }
        public void MatchInternalsInPlanSum(PlanSum planSum)
        {
            if (!protocol.SetPartPlanIndex(planSum))
                if (MessageBox.Show("failed to match individual plan order, do you want to do this mannualy otherwise any critera for an individual plan will be calculated on the sum instead", "minior inconvenience", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PlanSumProtocolMatching p = new PlanSumProtocolMatching(planSum, (PlanSumProtocol)protocol);
                    p.ShowDialog();
                }
                else
                    doSinglePlanCritera = false;
        }
        public void MatchStrucutres(PlanSetup planSetup)
        {
            normalOrder.Clear();
            foreach (Structure structure in protocol.Structures)
            {
                structure.HealthStatus = 1000;
                string bestGuess = "";
                double bestSimilarityScore = 0;
                double similariyScore = 0;
                foreach (VMS.TPS.Common.Model.API.Structure eclipseStructureName in planSetup.StructureSet.Structures)
                {
                    similariyScore = NameSimilairty(eclipseStructureName.Id.ToString(), structure.Name);
                    if (similariyScore > bestSimilarityScore)
                    {
                        bestGuess = eclipseStructureName.Id.ToString();
                        bestSimilarityScore = similariyScore;
                    }
                }
                normalOrder.Add(structure.Name);
                if (bestSimilarityScore > nameCertaintyThreashold)
                {
                    structure.NameCertainty = bestSimilarityScore;
                    structure.EclipsStrucureName = bestGuess;
                }
                else
                {
                    structure.HealthStatus = 999;
                    structure.NameCertainty = 0;
                    structure.ListName = "?";
                }
            }
        }
        public void MatchStrucutres(PlanSum planSum)
        {
            normalOrder.Clear();
            foreach (Structure structure in protocol.Structures)
            {
                structure.HealthStatus = 1000;
                string bestGuess = "";
                double bestSimilarityScore = 0;
                double similariyScore = 0;
                foreach (VMS.TPS.Common.Model.API.Structure eclipseStructureName in planSum.StructureSet.Structures)
                {
                    similariyScore = NameSimilairty(eclipseStructureName.Id.ToString(), structure.Name);
                    if (similariyScore > bestSimilarityScore)
                    {
                        bestGuess = eclipseStructureName.Id.ToString();
                        bestSimilarityScore = similariyScore;
                    }
                }
                normalOrder.Add(structure.Name);
                if (bestSimilarityScore > nameCertaintyThreashold)
                {
                    structure.NameCertainty = bestSimilarityScore;
                    structure.EclipsStrucureName = bestGuess;
                }
                else
                {
                    structure.HealthStatus = 999;
                    structure.NameCertainty = 0;
                    structure.ListName = "?";
                }
            }
        }
        public void AnalyzeProtocol(PlanSum planSum)
        {
            //assumes structures have been matched
            VMS.TPS.Common.Model.API.Structure eclipseStructure = null;
            foreach (Structure structure in protocol.Structures)
            {
                if (structure.NameCertainty > nameCertaintyThreashold && calculatePlanSumProtocol) //we will evaluate else not
                {
                    eclipseStructure = GetEclipseStructure(planSum.StructureSet, structure.EclipsStrucureName);
                    EvaluatePlanSumCriterion(planSum, structure, eclipseStructure);
                }
            }
        }
        public void AnalyzeProtocol(PlanSetup planSetup)
        {
            //assumes structures have been matched
            if (protocol.Structures.Length > 0)
            {
                VMS.TPS.Common.Model.API.Structure eclipseStructure = null;
                foreach (Structure structure in protocol.Structures)
                    if (structure.NameCertainty > nameCertaintyThreashold)
                    {
                        eclipseStructure = GetEclipseStructure(planSetup.StructureSet, structure.EclipsStrucureName);
                        EvaluateProtocolStrucutre(planSetup, structure, eclipseStructure);
                    }
            }
        }
        public VMS.TPS.Common.Model.API.Structure GetEclipseStructure(StructureSet structureSet, String named)
        {
            foreach (VMS.TPS.Common.Model.API.Structure eclipseStructure in structureSet.Structures)
                if (named.ToLower() == eclipseStructure.Id.ToLower())
                    return eclipseStructure;
            return null;
        } //should in a planManager.
        public void EvaluateProtocolStrucutre(PlanSetup planSetup, Structure structure, VMS.TPS.Common.Model.API.Structure eclipseStructure) // no template cuz no extra parameter!
        {
            foreach (Criterion criterion in structure.Criteria)
            {
                if (criterion.PartPlan != 0)//uncertainty plan
                {
                    if (!foundUncertaintyPlans)
                        GetUncertaintyPlans(planSetup);
                    if (uncertaintyPlans.Count > 0)
                    {
                        if (criterion.Evaluated)
                        {
                            criterion.Analyze(uncertaintyPlans.ElementAt(Convert.ToInt32(criterion.ListName.Substring(criterion.ListName.IndexOf("U")+1, criterion.ListName.IndexOf("/") - criterion.ListName.IndexOf("U")-1)) - 1), eclipseStructure);
                        }
                        else
                        {
                            for (int i = 1; i < uncertaintyPlans.Count; i++)
                            {
                                criterion.Analyze(uncertaintyPlans.ElementAt(i), eclipseStructure);
                                criterion.ListName =criterion.Priority +": U" + (i+1).ToString() + "/ " + criterion.Name;
                                criterion.Evaluated = true;
                                structure.AddCriterion(criterion.Copy());
                            }
                            criterion.Analyze(uncertaintyPlans.ElementAt(0), eclipseStructure);
                            criterion.ListName = criterion.Priority+": U1" + "/ " + criterion.Name;
                            criterion.Evaluated = true;
                        }
                    }
                    else
                    {
                        criterion.Passed = false;
                        criterion.ReadValue = double.NaN;
                        criterion.ListName = criterion.Priority +": U " + criterion.Name;
                    }
                }
                else
                {
                    criterion.Analyze(planSetup, eclipseStructure);
                    criterion.ListName = criterion.Priority + ": " + criterion.Name;
                }
            }
        }
        public void ResetAllButProtocolPick()
        {
            uncertaintyPlans = new List<PlanSetup>();
            foundUncertaintyPlans = false;
        }
        public void EvaluatePlanSumCriterion(PlanSum planSum, Structure structure, VMS.TPS.Common.Model.API.Structure eclipseStructure) // no template cuz no extra parameter!
        {
            foreach (Criterion criterion in structure.Criteria)
            {
                if (criterion.PartPlan != 0 && doSinglePlanCritera) // its from a part of a plansum or not?
                {
                    criterion.ListName = "P" + criterion.PartPlan + " " + criterion.Priority + ": " + criterion.Name;
                    criterion.Analyze(planSum.PlanSetups.ElementAt(protocol.GetPartPlanIndex(criterion.PartPlan)), eclipseStructure);
                }
                else //full plan sum
                {
                    criterion.ListName = criterion.Priority + ": " + criterion.Name;
                    criterion.Analyze(planSum, eclipseStructure);
                }
            }
        }
    }
}
