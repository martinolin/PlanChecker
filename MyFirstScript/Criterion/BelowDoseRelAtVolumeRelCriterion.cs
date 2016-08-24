using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowDoseRelAtVolumeRelCriterion : Criterion
    {
        public BelowDoseRelAtVolumeRelCriterion()
        {
        }
        public BelowDoseRelAtVolumeRelCriterion(BelowDoseRelAtVolumeRelCriterion c) : base(c) { }

        public BelowDoseRelAtVolumeRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            partPlan = inPartPlan;
            priotity = inPriority;
            name = "D(%) ≤" + dose.ToString() + " at V=" + inVolume.ToString() + " %"; ;
        }
        public override Criterion Copy()
        { return new BelowDoseRelAtVolumeRelCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative).Dose;
            passed = (readValue <= dose);
            return passed;
        }
        //     private double dose;
        //    private double volume;
    }
}
