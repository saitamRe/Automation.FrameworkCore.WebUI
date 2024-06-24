using Automation.FrameworkCore.WebUI.Abstractions;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        IChromeWebDriver _driver;

        public SpecflowBase(IChromeWebDriver iDriver)
        {
            _driver = iDriver;
        }

        [BeforeScenario(Order = 2)]
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
