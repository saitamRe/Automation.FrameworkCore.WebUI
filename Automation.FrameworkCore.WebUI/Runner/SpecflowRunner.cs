using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace Automation.FrameworkCore.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _serviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _serviceProvider = CoreContainerConfig.ConfiureServices();
            //GlobalProperties globalProperties = _serviceProvider.GetRequiredService<GlobalProperties>();
            //globalProperties.Configure();
        }
    }
}
