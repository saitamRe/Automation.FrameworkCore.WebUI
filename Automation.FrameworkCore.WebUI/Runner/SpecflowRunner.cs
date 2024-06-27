using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Automation.FrameworkCore.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _serviceProvider;

        [BeforeTestRun(Order = 1)]
        public static void BeforeTestRun()
        {
            var services = new ServiceCollection();
            CoreContainerConfig.ConfiureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            IGlobalProperties globalProperties = _serviceProvider.GetRequiredService<IGlobalProperties>();
            globalProperties.Configure();
        }
    }
}
