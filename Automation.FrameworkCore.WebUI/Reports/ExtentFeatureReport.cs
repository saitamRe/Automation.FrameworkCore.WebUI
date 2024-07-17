using Automation.FrameworkCore.WebUI.Abstractions;
using AventStack.ExtentReports.Reporter;


namespace Automation.FrameworkCore.WebUI.Reports
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {
        readonly IDefaultVariables _defaultVariables;
        AventStack.ExtentReports.ExtentReports _extentReports;
        public ExtentFeatureReport(IDefaultVariables defaultVariables)
        {
            _defaultVariables = defaultVariables;
        }

        public void InitializeExtentReport()
        {
            ExtentHtmlReporter extentHtmlReporter = new(_defaultVariables.GetExtentReport);
            _extentReports = new AventStack.ExtentReports.ExtentReports();
            _extentReports.AttachReporter(extentHtmlReporter);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReport()
        {
            return _extentReports;
        }

        public void FlushReport()
        {
            _extentReports.Flush();
        }
    }
}
