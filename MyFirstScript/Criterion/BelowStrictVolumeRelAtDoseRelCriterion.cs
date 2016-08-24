using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowStrictVolumeRelAtDoseRelCriterion : Criterion
    {
        public BelowStrictVolumeRelAtDoseRelCriterion()
        { }
        public BelowStrictVolumeRelAtDoseRelCriterion(BelowStrictVolumeRelAtDoseRelCriterion c) : base(c) { }

        public BelowStrictVolumeRelAtDoseRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            partPlan = inPartPlan;
            volume = inVolume;
            priotity = inPriority;
            name = "V(%) <" + volume.ToString() + " at D=" + dose.ToString() + " %";
        }
        public override Criterion Copy()
        { return new BelowStrictVolumeRelAtDoseRelCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent), VMS.TPS.Common.Model.Types.VolumePresentation.Relative);
            passed = readValue < volume;
            return passed;
        }
    }
}
