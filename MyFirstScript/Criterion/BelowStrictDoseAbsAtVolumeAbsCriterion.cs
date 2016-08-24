using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowStrictDoseAbsAtVolumeAbsCriterion : Criterion
    {
        public BelowStrictDoseAbsAtVolumeAbsCriterion()
        {
        }
        public BelowStrictDoseAbsAtVolumeAbsCriterion(BelowStrictDoseAbsAtVolumeAbsCriterion c) : base(c) { }

        public BelowStrictDoseAbsAtVolumeAbsCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "D(Gy) <" + dose.ToString() + " at V=" + inVolume.ToString() + " cc";
            partPlan = inPartPlan;
        }
        public override Criterion Copy()
        { return new BelowStrictDoseAbsAtVolumeAbsCriterion(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute).Dose;
            passed = (readValue < dose);
            return passed;
        }
      /*  public override bool Analyze(VMS.TPS.Common.Model.Types.DVHPoint[] hist, double absDoseVolymBinWidth)
        {
            double max = hist.Last().DoseValue.Dose;
            double points = max / absDoseVolymBinWidth; //use ceil här.. och det är för långtsamt med att get dvh i varje kriterie, istället för varje strukt utanför nu när vi har separata metoder.
            int s=(int)points;
            int index = (int)(hist.Last().DoseValue.Dose / absDoseVolymBinWidth);
            if (index < 0 || index > hist.Length)
            {
                //throw{}
                return false;//Double.NaN;
            }
                else
            readValue = hist[index].DoseValue.Dose;
            return (readValue < dose);
        }
       */
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
        //    VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, .001);
         //   VMS.TPS.Common.Model.Types.DVHPoint[] hist = dvh.CurveData;
        //    int index = (int)(dose * hist.Last().DoseValue.Dose / .00001);
         
     //       double max = dvh.MaxDose.Dose;
    /*        double fg = (max );
            double fgfg = Math.Ceiling(max);
            double werer =  2000 *(fg/fgfg);
            double wererwe = (2000 *(fg/fgfg)+2001 * (fg / fgfg))/2*0.001;
            double ddfdf = max / (fg) * (2000);
            double r332 = hist.ElementAt(0).DoseValue.Dose;
            double r3323 = hist.ElementAt(1).DoseValue.Dose;
            double wre35533 = hist.ElementAt(500).DoseValue.Dose;
            double wre5533 = hist.ElementAt(1000).DoseValue.Dose;

            double wre553 = hist.ElementAt(2000).DoseValue.Dose;
            double wre5er53 = hist.ElementAt(1999).DoseValue.Dose;
            double wre5ew53 = hist.ElementAt(2001).DoseValue.Dose;


            double wre3 = hist.ElementAt(4000).DoseValue.Dose;
            double wre = hist.ElementAt(8000).DoseValue.Dose;
        
            double r33 = hist.ElementAt(hist.Count() - 4).DoseValue.Dose;
            double r44 = hist.ElementAt(hist.Count() - 3).DoseValue.Dose;
            double r=hist.ElementAt(hist.Count() - 2).DoseValue.Dose;
            double rr= hist.ElementAt(hist.Count()-1).DoseValue.Dose;
            //double rerr = hist.ElementAt(hist.Count() ).DoseValue.Dose;
            double dsg = 3;
     * */
       /*     if (index < 0 || index > hist.Length)
            {
                //throw{}
                return false;//Double.NaN;
            }
            else
                readValue = hist[index].DoseValue.Dose;
            return (readValue < dose);
        */
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
                passed = (readValue < dose);
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
