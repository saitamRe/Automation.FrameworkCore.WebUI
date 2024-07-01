using Automation.DemoUI.Configuration;
using Automation.DemoUI.Tests.Params;
using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DriverContext;
using Automation.FrameworkCore.WebUI.Reports;
using Automation.FrameworkCore.WebUI.Selenium.LocalWebDrivers;
using Automation.FrameworkCore.WebUI.WebElements;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DIConteiner
{
    public class CoreContainerConfig
    {

        public static IServiceCollection ConfiureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            services.AddSingleton<IAtConfig, AtConfig>();
            services.AddScoped<IChromeWebDriver, ChromeWebDriver>();
            services.AddScoped<IAtWebElement, AtWebElement>();
            services.AddScoped<IDrivers, Drivers>();

            return services;
        }
    }
}
