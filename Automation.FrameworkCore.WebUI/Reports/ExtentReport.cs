

using Automation.FrameworkCore.WebUI.Abstractions;

namespace Automation.FrameworkCore.WebUI.Reports
{
    public class ExtentReport : IExtentReport
    {
        IExtentFeatureReport _extentFeatureReport;
        AventStack.ExtentReports.ExtentTest _feature, _scenario;
        public ExtentReport(IExtentFeatureReport extentFeatureReport)
        {
            _extentFeatureReport = extentFeatureReport;
        }

        public void CreateFeature(string featureName)
        {
            _feature = _extentFeatureReport.GetExtentReport().CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode(scenarioName);
        }

        public void Pass(string stepName)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Pass, stepName);
        }

        public void Fail(string stepName)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fail, stepName);
        }

        public void Warning(string stepName)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Warning, stepName);
        }

        public void Error(string stepName)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Error, stepName);
        }
    }
}
