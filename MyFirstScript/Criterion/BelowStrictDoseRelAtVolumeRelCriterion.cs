using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowStrictDoseRelAtVolumeRelCriterion : Criterion
    {
        public BelowStrictDoseRelAtVolumeRelCriterion()
        {
        }
        public BelowStrictDoseRelAtVolumeRelCriterion(BelowStrictDoseRelAtVolumeRelCriterion c) : base(c) { }

        public BelowStrictDoseRelAtVolumeRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            partPlan = inPartPlan;
            name = "D(%) <" + dose.ToString() + " at V=" + inVolume.ToString() + " %"; ;
        }
        public override Criterion Copy()
        { return new BelowStrictDoseRelAtVolumeRelCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative).Dose;
            passed = (readValue < dose);
            return passed;
        }
        //     private double dose;
        //    private double volume;
    }
}
