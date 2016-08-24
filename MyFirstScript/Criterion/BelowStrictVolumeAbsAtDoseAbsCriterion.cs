using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanChecker
{
    [Serializable]
    public class BelowStrictVolumeAbsAtDoseAbsCriterion : Criterion
    {
        public BelowStrictVolumeAbsAtDoseAbsCriterion()
        {
        }
        public BelowStrictVolumeAbsAtDoseAbsCriterion(BelowStrictVolumeAbsAtDoseAbsCriterion c) : base(c) { }

        public BelowStrictVolumeAbsAtDoseAbsCriterion(double inDose, double inVolume, int inPriority, int inPartPlan)
        {
            dose = inDose;
            volume = inVolume;
            priotity = inPriority;
            partPlan = inPartPlan;
            name = "V(cc) <" + volume.ToString() + " at D=" + dose.ToString() + " Gy";
        }
        public override Criterion Copy()
        { return new BelowStrictVolumeAbsAtDoseAbsCriterion(this); }
        /*public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetDoseAtVolume(eclipseStructure, volume, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, VMS.TPS.Common.Model.Types.DoseValuePresentation.Relative).Dose;
            return (readValue < dose);
        }
         * */
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSetup planSetup, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            readValue = planSetup.GetVolumeAtDose(eclipseStructure, new VMS.TPS.Common.Model.Types.DoseValue(dose, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Gy), VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3);
            passed = readValue < volume;
            return (passed);
        }
        // VMS.TPS.Common.Model.Types.DoseValue t = new VMS.TPS.Common.Model.Types.DoseValue(45, VMS.TPS.Common.Model.Types.DoseValue.DoseUnit.Percent);
        public override bool Analyze(VMS.TPS.Common.Model.API.PlanSum inplanSum, VMS.TPS.Common.Model.API.Structure eclipseStructure)
        {
            VMS.TPS.Common.Model.API.DVHData dvh = inplanSum.GetDVHCumulativeData(eclipseStructure, VMS.TPS.Common.Model.Types.DoseValuePresentation.Absolute, VMS.TPS.Common.Model.Types.VolumePresentation.AbsoluteCm3, binWidth);
            if (dvh != null)
            {
                if (dvh.MaxDose.Dose >= dose)
                    readValue = dvh.CurveData.Last(o => o.DoseValue.Dose <= dose).Volume;
                else
                    readValue = 0;
                passed = (readValue < volume);
                //return (dvh.CurveData.First().Volume == dvh.Volume);
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
