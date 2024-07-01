using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DIConteiner;
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
        public IChromeWebDriver _driver;
        

        public SpecflowBase(IChromeWebDriver iDriver)
        {
            _driver = iDriver;
            
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
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IAtConfig>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IAtWebElement>());
            container.RegisterInstanceAs(serviceProvider.GetRequiredService<IDrivers>());
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer container)
        {
            IWebDriver driver = _driver.GetChromeWebDriver();
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario(IObjectContainer container)
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
