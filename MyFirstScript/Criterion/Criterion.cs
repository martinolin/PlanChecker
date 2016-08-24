using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PlanChecker
{
    //[XmlInclude(typeof(AboveDoseRelAtVolumeRelCriterion, AboveDoseRelAtVolumeAbsCriterion, AboveDoseAbsAtVolumeRelCriterion,AboveDoseAbsAtVolumeAbsCriterion,BelowDoseRelAtVolumeRelCriterion, BelowDoseRelAtVolumeAbsCriterion, BelowDoseAbsAtVolumeRelCriterion,BelowDoseAbsAtVolumeAbsCriterion ))]
    // [XmlInclude(typeof(AboveDoseRelAtVolumeRelCriterion), typeof(AboveDoseRelAtVolumeAbsCriterion), typeof(AboveDoseAbsAtVolumeRelCriterion), typeof(AboveDoseAbsAtVolumeAbsCriterion), typeof(BelowDoseRelAtVolumeRelCriterion), typeof(BelowDoseAbsAtVolumeRelCriterion), typeof(BelowDoseRelAtVolumeAbsCriterion),typeof(BelowDoseAbsAtVolumeAbsCriterion ))]

    [XmlInclude(typeof(AboveDoseRelAtVolumeRelCriterion))]
    [XmlInclude(typeof(AboveDoseRelAtVolumeAbsCriterion))]
    [XmlInclude(typeof(AboveDoseAbsAtVolumeRelCriterion))]
    [XmlInclude(typeof(AboveDoseAbsAtVolumeAbsCriterion))]
    [XmlInclude(typeof(BelowDoseRelAtVolumeRelCriterion))]
    [XmlInclude(typeof(BelowDoseRelAtVolumeAbsCriterion))]
    [XmlInclude(typeof(BelowDoseAbsAtVolumeRelCriterion))]
    [XmlInclude(typeof(BelowDoseAbsAtVolumeAbsCriterion))]
    [XmlInclude(typeof(AboveVolumeAbsAtDoseAbsCriterion))]
    [XmlInclude(typeof(AboveVolumeRelAtDoseAbsCriterion))]
    [XmlInclude(typeof(AboveVolumeAbsAtDoseRelCriterion))]
    [XmlInclude(typeof(AboveVolumeRelAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowVolumeAbsAtDoseAbsCriterion))]
    [XmlInclude(typeof(BelowVolumeRelAtDoseAbsCriterion))]
    [XmlInclude(typeof(BelowVolumeAbsAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowVolumeRelAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowMeanDoseRel))]
    [XmlInclude(typeof(BelowMeanDoseAbs))]
    [XmlInclude(typeof(AboveMeanDoseAbs))]
    [XmlInclude(typeof(AboveMeanDoseRel))]
    [XmlInclude(typeof(BelowMedianDoseRel))]
    [XmlInclude(typeof(BelowMedianDoseAbs))]
    [XmlInclude(typeof(AboveMedianDoseAbs))]
    [XmlInclude(typeof(AboveMedianDoseRel))]
    [XmlInclude(typeof(BelowMaxDoseRel))]
    [XmlInclude(typeof(BelowMaxDoseAbs))]
    [XmlInclude(typeof(AboveMaxDoseAbs))]
    [XmlInclude(typeof(AboveMaxDoseRel))]
    [XmlInclude(typeof(BelowMinDoseRel))]
    [XmlInclude(typeof(BelowMinDoseAbs))]
    [XmlInclude(typeof(AboveMinDoseAbs))]
    [XmlInclude(typeof(AboveMinDoseRel))] //
    [XmlInclude(typeof(AboveStrictDoseRelAtVolumeRelCriterion))]
    [XmlInclude(typeof(AboveStrictDoseRelAtVolumeAbsCriterion))]
    [XmlInclude(typeof(AboveStrictDoseAbsAtVolumeRelCriterion))]
    [XmlInclude(typeof(AboveStrictDoseAbsAtVolumeAbsCriterion))]
    [XmlInclude(typeof(BelowStrictDoseRelAtVolumeRelCriterion))]
    [XmlInclude(typeof(BelowStrictDoseRelAtVolumeAbsCriterion))]
    [XmlInclude(typeof(BelowStrictDoseAbsAtVolumeRelCriterion))]
    [XmlInclude(typeof(BelowStrictDoseAbsAtVolumeAbsCriterion))]
    [XmlInclude(typeof(AboveStrictVolumeAbsAtDoseAbsCriterion))]
    [XmlInclude(typeof(AboveStrictVolumeRelAtDoseAbsCriterion))]
    [XmlInclude(typeof(AboveStrictVolumeAbsAtDoseRelCriterion))]
    [XmlInclude(typeof(AboveStrictVolumeRelAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowStrictVolumeAbsAtDoseAbsCriterion))]
    [XmlInclude(typeof(BelowStrictVolumeRelAtDoseAbsCriterion))]
    [XmlInclude(typeof(BelowStrictVolumeAbsAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowStrictVolumeRelAtDoseRelCriterion))]
    [XmlInclude(typeof(BelowStrictMeanDoseRel))]
    [XmlInclude(typeof(BelowStrictMeanDoseAbs))]
    [XmlInclude(typeof(AboveStrictMeanDoseAbs))]
    [XmlInclude(typeof(AboveStrictMeanDoseRel))]
    [XmlInclude(typeof(BelowStrictMedianDoseRel))]
    [XmlInclude(typeof(BelowStrictMedianDoseAbs))]
    [XmlInclude(typeof(AboveStrictMedianDoseAbs))]
    [XmlInclude(typeof(AboveStrictMedianDoseRel))]
    [XmlInclude(typeof(BelowStrictMaxDoseRel))]
    [XmlInclude(typeof(BelowStrictMaxDoseAbs))]
    [XmlInclude(typeof(AboveStrictMaxDoseAbs))]
    [XmlInclude(typeof(AboveStrictMaxDoseRel))]
    [XmlInclude(typeof(BelowStrictMinDoseRel))]
    [XmlInclude(typeof(BelowStrictMinDoseAbs))]
    [XmlInclude(typeof(AboveStrictMinDoseAbs))]
    [XmlInclude(typeof(AboveStrictMinDoseRel))]
    [Serializable]
    public abstract class Criterion
    {
        public Criterion() { }
        public Criterion(Criterion criterion)
            : this()
        {
            this.Name = criterion.Name;
            this.Dose= criterion.Dose;
            this.ListName = criterion.ListName;
            this.PartPlan= criterion.PartPlan;
            this.Volume= criterion.Volume;
            this.Name = criterion.Name;
            this.Priority = criterion.Priority;
            this.ReadValue = criterion.ReadValue;
            this.Evaluated = criterion.Evaluated;
        }
    
        abstract public bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure);
        public abstract Criterion Copy();
        virtual public bool Analyze(VMS.TPS.Common.Model.API.PlanSum planSum, VMS.TPS.Common.Model.API.Structure eclipseStructure) { return false; }
        public string Name { get { return name; } set { name = value; } }
        public int Priority { get { return priotity; } set { priotity = value; } }
        public int PartPlan { get { return partPlan; } set { partPlan = value; } }
        public double ReadValue { get { return readValue; } set { readValue = value; } }
        public double Dose { get { return dose; } set { dose = value; } }
        public double Volume { get { return volume; } set { volume = value; } }
        [XmlIgnore]
        public bool Passed { get { return passed; } set { passed = value; } }
        [XmlIgnore]
        public bool Evaluated { get { return evaluated; } set { evaluated = value; } }
        [XmlIgnore]
        public string ListName { get; set; }
        virtual public string CreatedBy { get; set; }
        protected bool passed = false;
        protected bool evaluated = false;
        protected double binWidth = 0.0001;
        protected int priotity; //=0;
        protected string name = "unNamed";
        [XmlIgnore]
        [NonSerialized]
        protected double readValue = 0;
        protected double dose;
        protected double volume;
        protected int partPlan = 0;
    }
}
