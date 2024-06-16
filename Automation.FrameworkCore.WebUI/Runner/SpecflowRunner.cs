using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.FrameworkCore.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        static IServiceProvider _serviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _serviceProvider = ContainerConfig.ConfiureServices();
            GlobalProperties globalProperties = _serviceProvider.GetRequiredService<GlobalProperties>();
            globalProperties.Configure();
        }
    }
}
