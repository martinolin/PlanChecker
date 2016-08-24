using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlanChecker;
using VMS.TPS.Common.Model.API;

namespace VMS.TPS
{
    /// <summary>
    /// this is for eclipse
    /// </summary>
    public class Script
    {
        public Script()
        {
        }

        public void Execute(ScriptContext context) //this is where eclipse script will pick up
        {
            MainWindow mainWindow = new MainWindow(context.Patient, context.Course, context.PlanSetup, /*context.PlanSumsInScope,*/ context.CurrentUser);
      
            mainWindow.ShowDialog();
        }               
    }
}