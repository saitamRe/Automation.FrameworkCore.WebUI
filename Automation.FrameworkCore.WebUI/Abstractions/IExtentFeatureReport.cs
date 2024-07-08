using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface IExtentFeatureReport
    {
        void InitializeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void FlushReport();
    }
}
