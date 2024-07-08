using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.DriverContext
{
    //It is just wrapper around webdriver. It will be more helpfull when we will need to add different browsers support
    public class Drivers : IDrivers
    {
        private IChromeWebDriver _iChromeDriver;
        private IWebDriver? _webDriver;
        private IGlobalProperties _globalProperties;
        private ILogging _logging;
        private static readonly object _lock = new();


        public Drivers(IChromeWebDriver chromeWebDriver, IGlobalProperties globalProperties, ILogging logging)
        {
            _iChromeDriver = chromeWebDriver;
            _globalProperties = globalProperties;
            _logging = logging;
        }

        public IWebDriver GetWebDriver()
        {
            lock (_lock)
            {
                if (_webDriver == null)
                {
                    InitializeWebDriver();
                }
            }
            return _webDriver;
        }

        private void InitializeWebDriver()
        {
            switch (_globalProperties.BrowserType.ToLower())
            {
                case "chrome":
                    _webDriver = _iChromeDriver.GetChromeWebDriver();
                    break;
                //here will be a case for another browser
                default:
                    _webDriver = _iChromeDriver.GetChromeWebDriver();
                    break;
            }
            _webDriver.Manage().Window.Maximize();
        }

        public IAtWebElement FindElement(By by)
        {
            IAtWebElement atWebElement = SpecflowRunner._serviceProvider.GetRequiredService<IAtWebElement>();
            if (by == null)
            {
                _logging.Error("To find an element the By param should be provided");
            }
            try
            {
                atWebElement.Set(GetWebDriver(), by);
                _logging.Information("Element is found");
                return atWebElement;
            }
            catch (NoSuchElementException ex)
            {
                _logging.Error($"Element not found: {by}" + ex);
                throw;
            }
            catch (Exception ex)
            {
                _logging.Error($"Error occurs while trying to find the element {by}" + ex.Message);
                throw;
            }
        }

        public void GoToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                _logging.Error("Url param is required");
                throw new ArgumentNullException("Url param is required");
            }
            else
            {
                GetWebDriver().Navigate().GoToUrl(url);
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

        public string GetPageTitle()
        {
            return GetWebDriver().Title;
        }

        public void GetNewTab()
        {
            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }

        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }

        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }

        public void SwitchToWindowWithTitle(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                _logging.Error("Parameter title cannot be null");
                throw new ArgumentNullException("Parameter title cannot be null");
            }

            IList<string> tabs = new List<string>();

            foreach(string tab in tabs)
            {
                if(tabs.Contains(title))
                {
                    GetWebDriver().SwitchTo().Window(title);
                    break;
                }
            }
        }

        //SwitchToFrame()
        //Maximize()
        //ExecuteScript()
        //ScrollTo()
    }
}
