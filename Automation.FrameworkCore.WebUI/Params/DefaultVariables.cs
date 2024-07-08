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

        public string GetExtentReport
        {
            get
            {
                return GetReport + "\\index.html";
            }
        }


        public string GetFrameworkSettingsJson
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .FullName + "\\Resources\\frameworkSettings.json";
            }
        }

        public string GetApplicationConfigJson
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                    .FullName + "\\Resources\\applicationConfig.json";
            }
        }

        public string DataSetLocation
        {
            get
            {
                return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\DataSet";
            }
        }

        public string GridHubUrl
        {
            get
            {
                return "https://localhost:4444/";
            }
        }

    }
}
