using Automation.DemoUI.Configuration;
using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.DIConteiner;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Container
{
    [Binding]
    public class ContainerConfig
    {

        [BeforeTestRun(Order = 1)]
        //order = 1 because we need to have assiciation between classes and interfaces before a test run
        public static void BeforeTestRun(IObjectContainer container)
        {
            container.RegisterTypeAs<AtConfig, IAtConfig>();
            //adding two more associations to container(chromeWebDriver)
            container = CoreContainerConfig.SetContainer(container);
        }
    }
}
