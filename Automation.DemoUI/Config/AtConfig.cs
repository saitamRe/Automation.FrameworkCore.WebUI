
using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Configuration
{
    public class AtConfig : IAtConfig
    {
        IConfiguration _configuration;

        public AtConfig()
        {
            if(SpecflowRunner._serviceProvider == null)
            {
                throw new InvalidOperationException("service provider is not initialized");
            }
            IDefaultVariables defaultVariables = SpecflowRunner._serviceProvider.GetRequiredService<IDefaultVariables>();
            _configuration = new ConfigurationBuilder().AddJsonFile(defaultVariables.GetApplicationConfigJson).Build();
        }

        public string GetConfiguration(string key)
        {
            return _configuration[key];
        }
    }
}
