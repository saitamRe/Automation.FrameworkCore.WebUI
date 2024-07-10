using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.DemoUI.Steps;
using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.ISteps;
using Automation.DemoUI.WebAbstractions.Pages;
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
    public class WebContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer container)
        {
            container.RegisterTypeAs<AtConfig, IAtConfig>();
            container.RegisterTypeAs<LoginPage, ILoginPage>();
            container.RegisterTypeAs<LoginSteps, ILoginSteps>();
            container.RegisterTypeAs<ProductPage, IProductPage>();
            //container = CoreContainerConfig.SetWebContainer(container);
        }
    }
}
