using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface IGlobalProperties
    {
        string BrowserType { get; set; }
        string GridHubUrl { get; set; }
        bool StepScreenshot { get; set; }
        string ExtentReportPortalUrl { get; set; }
        bool ExtentReportPortal { get; set; }
        string LogLevel { get; set; }
        string DataSetLocation { get; set; }
        string DownloadedLocation { get; set; }
        void Configure();
    }
}
