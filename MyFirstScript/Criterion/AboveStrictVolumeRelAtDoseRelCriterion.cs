using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class AboveStrictVolumeRelAtDoseRelCriterion : Criterion
    {
        public AboveStrictVolumeRelAtDoseRelCriterion()
        { }
        public AboveStrictVolumeRelAtDoseRelCriterion(AboveStrictVolumeRelAtDoseRelCriterion c) : base(c) { }

        public AboveStrictVolumeRelAtDoseRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            partPlan = inPartPlan;
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "V(%) >" + volume.ToString() + " at D=" + dose.ToString() + " %";
        }

        public override Criterion Copy()
        { return new AboveStrictVolumeRelAtDoseRelCriterion(this); }

        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent), VMS.TPS.Common.Model.Types.VolumePresentation.Relative);
            passed = (readValue > volume);
            return passed;
        }
    }
}
