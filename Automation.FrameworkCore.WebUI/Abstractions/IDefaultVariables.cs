using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface IDefaultVariables
    {
        string GetReport {  get; }
        string GetLog {  get; }
        string GetFrameworkSettingsJson { get; }
        string DataSetLocation { get; }
        string GridHubUrl { get; }
        string GetApplicationConfigJson { get; }
    }
}
