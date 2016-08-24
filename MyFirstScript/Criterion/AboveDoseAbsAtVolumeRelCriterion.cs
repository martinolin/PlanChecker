using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class AboveDoseAbsAtVolumeRelCriterion : Criterion
    {
        public AboveDoseAbsAtVolumeRelCriterion()
        {
        }
        public AboveDoseAbsAtVolumeRelCriterion(AboveDoseAbsAtVolumeRelCriterion c) : base(c) { }

        public AboveDoseAbsAtVolumeRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "D(Gy) ≥" + dose.ToString() + " at V=" + inVolume.ToString() + " %";
            partPlan = inPartPlan;
        }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute).Dose;
            passed= (readValue >= dose);
            return passed;
        }
        public override Criterion Copy()
        { return new AboveDoseAbsAtVolumeRelCriterion(this); }

        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            
            VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, binWidth);
            if (dvh != null)
            {
                if (volume <= 100)
                {
                    readValue = dvh.CurveData.Last(o => o.Volume >= volume).DoseValue.Dose;
                }
                else
                {
                    readValue = 0;
                }
                passed = (readValue >= dose);
            }
            else
            {
                readValue= double.NaN;
                passed = false;
            }
            return passed;
        }
    }
}
