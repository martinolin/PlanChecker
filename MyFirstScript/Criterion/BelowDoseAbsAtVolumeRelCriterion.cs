using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowDoseAbsAtVolumeRelCriterion : Criterion
    {
        public BelowDoseAbsAtVolumeRelCriterion()
        {
        }
        public BelowDoseAbsAtVolumeRelCriterion(BelowDoseAbsAtVolumeRelCriterion c) : base(c) { }

        public BelowDoseAbsAtVolumeRelCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            partPlan = inPartPlan;
            volume = inVolume;
            priotity = inPriority;
            name = "D(Gy) ≤" + dose.ToString() + " at V=" + inVolume.ToString() + " %";
        }
        public override Criterion Copy()
        { return new BelowDoseAbsAtVolumeRelCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute).Dose;
            passed = (readValue <= dose);
            return passed;
        }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            //   VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, .01);
            //   VMS.TPS.Common.Model.Types.DVHPoint[] hist = dvh.CurveData;
            //  dvh.CurveData.First(o => o.Volume <= volume);
            //double ff=dvh.Coverage;
            /*  int index = (int)(dose * hist.Last().DoseValue.Dose / .01);
              if (index < 0 || index > hist.Length)
              {
                  //throw{}
                  return false;//Double.NaN;
              }
                  else
              readValue = hist[index].DoseValue.Dose;
             */
            VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.Relative, binWidth);
            if (dvh != null)
            {
                if (volume <= 100)
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
