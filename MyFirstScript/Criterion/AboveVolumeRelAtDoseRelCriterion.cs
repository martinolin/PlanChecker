using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
     [Serializable]
    public class AboveVolumeRelAtDoseRelCriterion : Criterion
    {
         public AboveVolumeRelAtDoseRelCriterion()
         { }
         public AboveVolumeRelAtDoseRelCriterion(AboveVolumeRelAtDoseRelCriterion c) : base(c) { }

         public AboveVolumeRelAtDoseRelCriterion(double inDose, double inVolume, int inPriority,int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            partPlan = inPartPlan;
            name = "V(%) ≥" + volume.ToString() + " at D=" + dose.ToString() + " %";
        }
         public override Criterion Copy()
         { return new AboveVolumeRelAtDoseRelCriterion(this); }

       public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent), VMS.TPS.Common.Model.Types.VolumePresentation.Relative);
            passed = (readValue >= volume);
            return passed;
        }
    }
}
