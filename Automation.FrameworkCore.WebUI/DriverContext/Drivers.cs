using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DriverContext
{
    //It is just wrapper around webdriver. It will be more helpfull when we will need to add different browsers support
    public class Drivers :IDrivers
    {
        IChromeWebDriver _iChromeDriver;
        IWebDriver? _webDriver;
        IGlobalProperties _globalProperties;
        ILogging _logging;


        public Drivers(IChromeWebDriver chromeWebDriver, IGlobalProperties globalProperties, ILogging logging)
        {
            _iChromeDriver = chromeWebDriver;
            _globalProperties = globalProperties;
            _logging = logging;
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

        public IWebElement FindElement(By by)
        {
            if(by == null)
            {
                _logging.Error("To find an element the By param should be provided");
            }
            try
            {
				return _webDriver.FindElement(by);
			}
            catch(NoSuchElementException ex)
            {
				_logging.Error($"Element not found: {by}" + ex);
				throw;
			}
            catch(Exception ex)
            {
                _logging.Error($"Error occurs while trying to find the element {by}" + ex.Message);
                throw;
            }
        }

		public void Dispose()
		{
			if (_webDriver != null)
			{
				_logging.Information("Disposing WebDriver instance");
				_webDriver.Quit();
				_webDriver.Dispose();
				_webDriver = null;
			}
		}
	}
}
