using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using System.Xml.Serialization;

namespace PlanChecker
{
    /// <summary>
    /// this is for normal PlanSetups / normal plans. Stores information about the specifc protocol/template and what strucutres are in it. Every strucutre can have criteria.
    /// </summary>
    [XmlInclude(typeof(PlanSumProtocol))]
    [XmlInclude(typeof(UnknownProtocol))]
    [Serializable]
    public class Protocol
    {
        protected List<Structure> structures = new List<Structure>();
        protected string name;
        protected double dose;
        public string LastUpdated { get; set; }
        protected int fractions;
        public Protocol()
        {
        }
        public Protocol(string inName, double inDose, int inFractions)
        {
            dose = inDose;
            fractions = inFractions;
            name = inName;
        }
        public void Rename(string newName)
        {
            name = newName;
        }
        public Structure[] Structures { get { return structures.ToArray(); } set { structures = new List<Structure>(value); } }
        public void AddStrucutre(string inName, string user)
        {
            Structure newStrucure = new Structure(inName);
            newStrucure.CreatedBy = user;
            structures.Add(newStrucure);
        }
        public void RemoveStructure(string inName)
        {
            structures.Remove(GetStructure(inName));
        }
        public Structure GetStructure(string search)
        {
            foreach (Structure structure in structures)
            {
                if (String.Compare(structure.Name, search) == 0)
                { return structure; }
            }
            return new Structure();
        }
        public void Swap(int takeThis, int toHere)
        {
            Structure temp = structures[toHere];
            structures[toHere] = structures[takeThis];
            structures[takeThis] = temp;
        }

        public List<String> GetStructureNames()
        {
            List<String> nameList = new List<String>();
            foreach (Structure structure in structures)
                nameList.Add(structure.Name);
            return nameList;
        }
        virtual public string CreatedBy { get; set; }
        virtual public string GetListName()
        {
            return name + " " + String.Format("{0:0.00}", dose) + " | " + fractions.ToString();
        }

        virtual public List<int> GetSubFractions()
        {
            return null;
        }
        virtual public List<double> GetSubDoses()
        {
            return null;
        }
        virtual public int GetPartPlanIndex(int index) { return 0; }
        virtual public bool SetPartPlanIndex(VMS.TPS.Common.Model.API.PlanSum inplanSum) { return false; }
        public string Name { get { return name; } set { name = value; } }
        public double Dose { get { return dose; } set { dose = value; } }
        public int Fractions { get { return fractions; } set { fractions = value; } }

        public int MaxNumberOfCriteras
        {
            get
            {
                int maxNumberOfCriteria = 0;
                foreach (Structure structure in structures)
                {
                    int numberOfCritera = 1;
                    foreach (Criterion criterion in structure.Criteria)
                        numberOfCritera++;
                    if (numberOfCritera > maxNumberOfCriteria)
                        maxNumberOfCriteria = numberOfCritera;
                }
                return maxNumberOfCriteria;
            }
        }
        public int NumberOfStrucutres
        { get { return structures.Count(); } }
    }
}
