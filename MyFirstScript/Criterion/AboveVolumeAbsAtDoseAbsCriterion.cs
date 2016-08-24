

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
   public class AboveVolumeAbsAtDoseAbsCriterion: Criterion
    {
        public AboveVolumeAbsAtDoseAbsCriterion()
        {
        }
        public AboveVolumeAbsAtDoseAbsCriterion(AboveVolumeAbsAtDoseAbsCriterion c) : base(c) { }

        public AboveVolumeAbsAtDoseAbsCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "V(cc) ≥" + volume.ToString() + " at D=" + dose.ToString() + " Gy";
            partPlan = inPartPlan;
        }
             public override Criterion Copy()
        { return new AboveVolumeAbsAtDoseAbsCriterion(this); }
       public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
           readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Gy), VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3);
           passed = (readValue >= volume);
           return passed;
        }
       // VMS.TPS.Common.Model.Types.DoseValue t = new VMS.TPS.Common.Model.Types.DoseValue(45, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent);
       public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
       {
           VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, binWidth);
           if (dvh != null)
           {
               if (dvh.MaxDose.Dose >= dose) // no need to check if dose is less then zero cuz it never is.
               {
                   readValue = dvh.CurveData.First(o => o.DoseValue.Dose >= dose).Volume;
               }
               else
               {
                   readValue = 0;
               }
               passed = (readValue >= volume);
           }
           else
           {
               readValue = double.NaN;
               passed = false;
           }
           return passed;
       }
    }
}
