using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class AboveMaxDoseRel : Criterion
    {
        public AboveMaxDoseRel()
        {
        }
        public AboveMaxDoseRel(AboveMaxDoseRel c) : base(c) { }

        public AboveMaxDoseRel(double inDose, double inVolume, int inPriority,int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            partPlan = inPartPlan;
            priotity = inPriority;
            name = "Max D(%) ≥" + dose.ToString();
        }
        public override Criterion Copy()
        { return new AboveMaxDoseRel(this); }
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            VMS.TPS.Common.Model.API.DVHData dvh = planSetup.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, 10000);
            if (dvh != null)
            {
                readValue = dvh.MaxDose.Dose;
                passed = (readValue >= dose);
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
            return (readValue > dose);
        }
         */
    }
}
