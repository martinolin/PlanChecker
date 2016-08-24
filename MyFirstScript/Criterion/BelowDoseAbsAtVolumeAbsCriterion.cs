using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowDoseAbsAtVolumeAbsCriterion : Criterion
    {
        public BelowDoseAbsAtVolumeAbsCriterion()
        {
        }
        public BelowDoseAbsAtVolumeAbsCriterion(BelowDoseAbsAtVolumeAbsCriterion c) : base(c) { }

        public BelowDoseAbsAtVolumeAbsCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            partPlan = inPartPlan;
            name = "D(Gy) ≤" + dose.ToString() + " at V=" + inVolume.ToString() + " cc";
        }
        public override Criterion Copy()
        { return new BelowDoseAbsAtVolumeAbsCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute).Dose;
            passed = (readValue <= dose);
            return passed;
        }

        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, binWidth);
            if (dvh != null)
            {
                if (volume <= dvh.Volume)
                {
                    if (dvh.CurveData.Last().Volume > volume)
                        readValue = dvh.MaxDose.Dose;
                    else
                        readValue = dvh.CurveData.First(o => o.Volume <= volume).DoseValue.Dose;
                }
                else
                    readValue = 0;
                passed = (readValue <= dose);
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
