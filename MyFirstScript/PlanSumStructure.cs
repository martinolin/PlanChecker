using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstScript
{
    class PlanSumStructure:Structure
    {
        private VMS.TPS.Common.Model.Types.DVHPoint dvh;
        public void LoadDVH(VMS.TPS.Common.Model.Types.DVHPoint inDVH)
        {
            dvh=inDVH;
        }
    }
}
