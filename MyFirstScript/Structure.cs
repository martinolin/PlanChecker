using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    /// <summary>
    /// This is the Structure in Protocol and it is used to compare with strucutres in eclipse. This can hold critera.
    /// </summary>
    [Serializable]
    public class Structure
    {
        private string eclipseStructureName;
        private List<Criterion> criteria = new List<Criterion>();
        private string name = "unamed";
        private double nameCertainty = 0;
        private int healthStatus = 1000; //this is considered healthy, otherwise we put first criterion prioirty break here.
        public int HealthStatus { get { return healthStatus; } set { healthStatus = value; } }
        public string EclipsStrucureName { get { return eclipseStructureName; } set { eclipseStructureName = value; } }
        public double NameCertainty { get { return nameCertainty; } set { nameCertainty = value; } }
        public string CreatedBy { get; set; }
        public string ListName { get; set; }
        public Structure()
        {
            //name = "unamed";
        }
        public Structure(string inName)
        {
            name = inName;
        }
        public void Rename(string newName)
        { name = newName; }
        public List<String> GetCriterionNames()
        {
            List<String> nameList = new List<String>();
            foreach (Criterion criterion in criteria)
                nameList.Add(criterion.Name);
            return nameList;
        }
        public List<String> GetCriterionPrioritiesAndNames() // remove
        {
            List<String> nameList = new List<String>();
            foreach (Criterion criterion in criteria)
                nameList.Add(criterion.Priority + ": " + criterion.Name);
            return nameList;
        }
        public List<String> GetListOfCriterionCreatedBy()
        {
            List<String> createdBy = new List<String>();
            foreach (Criterion criterion in criteria)
                createdBy.Add(criterion.CreatedBy);
            return createdBy;
        }
        private void SortCritera()
        {
            criteria = criteria.OrderBy(o => o.Priority).ToList();
        }
        public void AddCriterion(Criterion newCriterion) 
        {
            criteria.Add(newCriterion);
            SortCritera();
        }
        public void RemoveCriterion(int index)
        {
            criteria.RemoveAt(index);
        }
        public Criterion[] Criteria { get { return criteria.ToArray(); } set { criteria = new List<Criterion>(value); } }
        public string Name { get { return name; } set { name = value; } }
    }
}
