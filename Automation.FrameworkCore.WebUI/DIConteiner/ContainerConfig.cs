using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DIConteiner
{
    public class ContainerConfig
    {

        public static IServiceProvider ConfiureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            return services.BuildServiceProvider();
        }
    }
}
