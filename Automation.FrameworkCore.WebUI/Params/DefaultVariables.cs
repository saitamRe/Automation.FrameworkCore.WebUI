using Automation.FrameworkCore.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Tests.Params
{
    public class DefaultVariables : IDefaultVariables
    {
        public string GetReport
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\Result\\Report" + DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
        }

        public string GetLog
        {
            get
            {
                return GetReport + "\\log.txt";
            }
        }

        public string GetFrameworkSettingsJson()
        {
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .FullName + "\\Resources\\frameworkSettings.json";
        }
    }
}
