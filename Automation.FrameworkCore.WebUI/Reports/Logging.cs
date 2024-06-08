using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Serilog;
using Serilog.Core;

namespace Automation.FrameworkCore.WebUI.Reports
{
    public class Logging : ILogging
    {
        LoggingLevelSwitch _loggingLevelSwitch;
        IDefaultVariables _defaultVariables;
        public Logging(IDefaultVariables defaultVariables)
        {
            _defaultVariables = defaultVariables;
            _loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.File(_defaultVariables.GetLog, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .Enrich.WithThreadName().CreateLogger();
        }

        public void LogLevel(string level)
        {
            switch (level.ToLower())
            {
                case "fatal":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Fatal;
                    break;
                case "information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;
                case "warning":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Warning;
                    break;
                case "debug":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
            }
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Fatal(string message)
        {
            Log.Fatal(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
