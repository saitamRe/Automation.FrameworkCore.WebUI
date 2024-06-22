using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.Reports;
using Automation.FrameworkCore.WebUI.Selenium.LocalWebDrivers;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DIConteiner
{
    public class CoreContainerConfig
    {

        public static IServiceProvider ConfiureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            return services.BuildServiceProvider();
        }

        public static IObjectContainer SetContainer(IObjectContainer container)
        {
            container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            
            return container;
        }
    }
}
