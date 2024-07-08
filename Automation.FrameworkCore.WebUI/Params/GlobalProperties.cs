using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;


namespace Automation.FrameworkCore.WebUI.Params
{
    public class GlobalProperties : IGlobalProperties
    {
        private readonly IDefaultVariables _defaultVariables;
        private readonly ILogging _logging;
        private readonly IExtentFeatureReport _extentFeatureReport;


        public string BrowserType { get; set; }
        public string GridHubUrl { get; set; }
        public bool StepScreenshot { get; set; }
        public string ExtentReportPortalUrl { get; set; }
        public bool ExtentReportPortal { get; set; }
        public string LogLevel { get; set; }
        public string DataSetLocation { get; set; }
        public string DownloadedLocation { get; set; }


        public GlobalProperties(IDefaultVariables defaultVariables, ILogging logging, IExtentFeatureReport extentFeatureReport)
        {
            _defaultVariables = defaultVariables;
            _logging = logging;
            _extentFeatureReport = extentFeatureReport;
        }

        public void Configure()
        {
            var builder = (dynamic)null;
            try
            {
                builder = new ConfigurationBuilder().AddJsonFile(_defaultVariables.GetFrameworkSettingsJson).Build();
            }
            catch (Exception e)
            {
                _logging.Error("JSON config file doesn't exist" + e.Message);
                Environment.Exit(0);
            }

            BrowserType = string.IsNullOrEmpty(builder["BrowserType"]) ? BrowserType = "chrome" : builder["BrowserType"];
            GridHubUrl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? _defaultVariables.GridHubUrl : builder["GridHubUrl"];
            StepScreenshot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            ExtentReportPortal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            LogLevel = builder["LogLevel"];
            DataSetLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _defaultVariables.DataSetLocation : builder["DataSetLocation"];
            DownloadedLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _defaultVariables.DataSetLocation : builder["DownloadedLocation"];//probably here is a mistake
            _extentFeatureReport.InitializeExtentReport();

            _logging.LogLevel(LogLevel);


            _logging.Debug("********************************************************************************");
            _logging.Information("********************************************************************************");
            _logging.Information("Configuration |RUN PARAMETERS");
            _logging.Information("********************************************************************************");
            _logging.Information("Configuration|BROWSER TYPE: " + BrowserType);
            _logging.Information("Configuration|GRID HUB URL: " + GridHubUrl);
            _logging.Information("Configuration|STEP SCREENSHOT: " + StepScreenshot);
            _logging.Information("Configuration|EXTENT REPORT PORTAL URL: " + ExtentReportPortal);
            _logging.Information("Configuration|EXTENT REPORT LOCALLY: " + LogLevel);
            _logging.Information("Configuration|LOG LEVEL: " + DataSetLocation);
            _logging.Information("Configuration|DATA SET LOCATION: " + DataSetLocation);
            _logging.Information("Configuration|DOWNLOADED LOCATION: " + DataSetLocation);
            _logging.Information("********************************************************************************");
            _logging.Information("********************************************************************************");
        }
    }
}
