using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface ILogging
    {
        void LogLevel(string level);
        void Debug(string message);
        void Fatal(string message);
        void Warning(string message);
        void Information(string message);

    }
}
