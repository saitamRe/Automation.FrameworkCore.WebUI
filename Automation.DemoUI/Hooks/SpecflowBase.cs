using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.DriverContext;
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
        public IDrivers _drivers;

        public SpecflowBase(IDrivers drivers)
        {
            _drivers = drivers;
            
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
        public void BeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario(IObjectContainer container)
        {
            IDrivers driver = container.Resolve<IDrivers>();
            driver?.Dispose();
        }
    }
}
