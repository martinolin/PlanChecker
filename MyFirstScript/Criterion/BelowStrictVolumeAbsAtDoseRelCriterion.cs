using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowStrictVolumeAbsAtDoseRelCriterion : Criterion
    {
        public BelowStrictVolumeAbsAtDoseRelCriterion()
        { }
        public BelowStrictVolumeAbsAtDoseRelCriterion(BelowStrictVolumeAbsAtDoseRelCriterion c) : base(c) { }

        public BelowStrictVolumeAbsAtDoseRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            partPlan = inPartPlan;
            name = "V(cc) <" + volume.ToString() + " at D=" + dose.ToString() + " %";
        }
        public override Criterion Copy()
        { return new BelowStrictVolumeAbsAtDoseRelCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent), VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3);
            passed = readValue < volume;
            return (passed);
        }
    }

}
