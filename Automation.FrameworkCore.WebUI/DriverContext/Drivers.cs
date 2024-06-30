using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DriverContext
{
    public class Drivers
    {
        IChromeWebDriver _iChromeDriver;
        IWebDriver _webDriver;
        IGlobalProperties _globalProperties;


        public Drivers(IChromeWebDriver chromeWebDriver, IGlobalProperties globalProperties)
        {
            _iChromeDriver = chromeWebDriver;
            _globalProperties = globalProperties;
        }

        public IWebDriver GetWebDriver()
        {
            if(_webDriver == null )
            {
                GetNewWebDriver();
                return _webDriver;
            }
            else
            {
                return _webDriver;
            }
        }

        private void GetNewWebDriver()
        {
            switch(_globalProperties.BrowserType.ToLower())
            {
                case "chrome":
                    _webDriver = _iChromeDriver.GetChromeWebDriver();
                    break;
                //here will be a case for another browser
                default:
                    _webDriver = _iChromeDriver.GetChromeWebDriver();
                    break;
            }
        }
    }
}
