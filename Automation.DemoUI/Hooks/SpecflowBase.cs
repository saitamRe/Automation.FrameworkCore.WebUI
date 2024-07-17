using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.Pages;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.DriverContext;
using Automation.FrameworkCore.WebUI.Reports;
using Automation.FrameworkCore.WebUI.Runner;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        ILoginPage _loginPage;
        IAtConfig _config;

        public SpecflowBase(ILoginPage loginPage, IAtConfig atConfig)
        {
            _loginPage = loginPage;
            _config = atConfig;
        }
        
        [BeforeTestRun(Order = 2)]
        //order = 1 because we need to have assiciation between classes and interfaces before a test run
        public static void BeforeTestRun(IObjectContainer container)
        {

            var serviceProvider = SpecflowRunner._serviceProvider;
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IDefaultVariables>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<ILogging>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IGlobalProperties>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IChromeWebDriver>());
            //container.RegisterInstanceAs(serviceProvider.GetRequiredService<IAtConfig>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IAtWebElement>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IDrivers>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IExtentFeatureReport>());
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer container, ScenarioContext scenarioContext, FeatureContext fc)
        {
            IExtentReport extentReport =(IExtentReport) fc["extentReport"];
            ScenarioContext sc = scenarioContext;
            extentReport.CreateScenario(sc.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext sc, FeatureContext fc)
        {
            IExtentReport extentReport = (IExtentReport)fc["extentReport"];
            if(sc.TestError != null)
            {
                extentReport.Fail(sc.StepContext.StepInfo.Text);
            }
            else
            {
                extentReport.Pass(sc.StepContext.StepInfo.Text);
            }
        }

        [AfterScenario]
        public void AfterScenario(IObjectContainer container, IExtentFeatureReport extentFeatureReport)
        {
            extentFeatureReport.FlushReport();
            IDrivers driver = container.Resolve<IDrivers>();
            driver?.Dispose();
        }

        [BeforeScenario("@LoginToApp")]
        public void LoginAsUser()
        {
            _loginPage.Login(_config.GetConfiguration("username"), _config.GetConfiguration("password"));
        }
    }
}
