
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PlanChecker
{
    [Serializable]
    public class BelowStrictMaxDoseRel : Criterion
    {
        public BelowStrictMaxDoseRel()
        {
        }
        public BelowStrictMaxDoseRel(BelowStrictMaxDoseRel c) : base(c) { }

        public BelowStrictMaxDoseRel(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            partPlan = inPartPlan;
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            name = "Max D(%) <" + dose.ToString();
        }
        public override Criterion Copy()
        { return new BelowStrictMaxDoseRel(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            VMS.TPS.Common.Model.API.DVHData dvh = planSetup.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, 10000);
            if (dvh != null)
            {
                readValue = dvh.MaxDose.Dose;
                passed = (readValue < dose);
            }
            else
            {
                readValue = double.NaN;
                passed = false;
            }
            return passed;
        }
        /*//for PlanSums
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, binWidth).MaxDose.Dose;
            return (readValue < dose);
        }
         */
    }
}

