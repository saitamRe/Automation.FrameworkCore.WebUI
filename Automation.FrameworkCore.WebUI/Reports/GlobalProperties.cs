using Automation.FrameworkCore.WebUI.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Reports
{
    public class GlobalProperties : IGlobalProperties
    {
        IDefaultVariables _defaultVariables;

        public GlobalProperties(IDefaultVariables defaultVariables)
        {
            _defaultVariables = defaultVariables;
        }
    
        public void Configure()
        {
            var config = new ConfigurationBuilder().AddJsonFile(_defaultVariables.GetFrameworkSettingsJson).Build();
            Console.WriteLine(config["BrowserType"]);
        }
    }
}
