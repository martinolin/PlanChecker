using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class AboveStrictDoseAbsAtVolumeAbsCriterion : Criterion
    {
        public AboveStrictDoseAbsAtVolumeAbsCriterion()
        {
        }
        public AboveStrictDoseAbsAtVolumeAbsCriterion(AboveStrictDoseAbsAtVolumeAbsCriterion c) : base(c) { }

        public AboveStrictDoseAbsAtVolumeAbsCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "D(Gy) >" + dose.ToString() + " at V=" + inVolume.ToString() + " cc";
            partPlan = inPartPlan;
        }
        public override Criterion Copy()
        { return new AboveStrictDoseAbsAtVolumeAbsCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute).Dose;
            passed = (readValue > dose);
            return passed;
        }
        //for PlanSums
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, binWidth);
            if (dvh != null)
            {
                if (dvh.Volume >= volume)
                {
                    if (dvh.CurveData.Last().Volume > volume)
                        readValue = dvh.MaxDose.Dose;
                    else
                    readValue = dvh.CurveData.Last(o => o.Volume >= volume).DoseValue.Dose;
                }
                else
                {
                    readValue = 0; //should be zero cuz is so in getDoseAtVolume
                }
                passed = (readValue >dose);
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
