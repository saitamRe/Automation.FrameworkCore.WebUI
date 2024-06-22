using Automation.DemoUI.Configuration;
using Automation.DemoUI.WebAbstraction;
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
        public static void BeforeTestRun(IObjectContainer container)
        {
            container.RegisterTypeAs<AtConfig, IAtConfig>();
        }
    }
}
