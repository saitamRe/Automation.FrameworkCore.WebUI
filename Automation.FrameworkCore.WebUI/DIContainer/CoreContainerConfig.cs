
using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DriverContext;
using Automation.FrameworkCore.WebUI.Params;
using Automation.FrameworkCore.WebUI.Reports;
using Automation.FrameworkCore.WebUI.Selenium.LocalWebDrivers;
using Automation.FrameworkCore.WebUI.WebElements;
using AventStack.ExtentReports;
using Microsoft.Extensions.DependencyInjection;


namespace Automation.FrameworkCore.WebUI.DIConteiner
{
    public class CoreContainerConfig
    {

        public static IServiceCollection ConfiureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            services.AddSingleton<IExtentFeatureReport, ExtentFeatureReport>();
            services.AddTransient<IExtentReport, ExtentReport>();
            //services.AddSingleton<IAtConfig, AtConfig>();
            services.AddScoped<IChromeWebDriver, ChromeWebDriver>();
            services.AddScoped<IAtWebElement, AtWebElement>();
            services.AddScoped<IDrivers, Drivers>();
            

            return services;
        }

        //public  static IObjectContainer SetWebContainer(IObjectContainer container)
        //{
            
        //    return container;

        //}
    }
}
