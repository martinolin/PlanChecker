using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class AboveVolumeAbsAtDoseRelCriterion : Criterion
    {
        public AboveVolumeAbsAtDoseRelCriterion(AboveVolumeAbsAtDoseRelCriterion c) : base(c) { }

        public AboveVolumeAbsAtDoseRelCriterion()
        { }

        public AboveVolumeAbsAtDoseRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            partPlan = inPartPlan;
            volume = inVolume;
            priotity = inPriority;
            name = "V(cc) ≥" + volume.ToString() + " at D=" + dose.ToString() + " %";
        }
        public override Criterion Copy()
        { return new AboveVolumeAbsAtDoseRelCriterion(this); }

        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent), VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3);
            passed = (readValue >= volume);
            return passed;
        }
    }
}
