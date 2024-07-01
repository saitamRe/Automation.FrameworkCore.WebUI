using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.CustomException;
using Automation.FrameworkCore.WebUI.Reports;
using Automation.FrameworkCore.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace Automation.FrameworkCore.WebUI.WebElements
{
    public class AtWebElement : IAtWebElement
    {
        private IWebDriver _driver;
        private By _by;
        private ILogging _logging;

        public AtWebElement()
        {
            _logging = SpecflowRunner._serviceProvider.GetRequiredService<ILogging>();
        }

        public void Set(IWebDriver driver, By by)
        {
            if(driver == null || by == null)
            {
                throw new ArgumentNullException("Driver or By parameter cannot be null");
            }
            else
            {
                _by = by;
				_driver = driver;
            }
        }
        public void Click()
        {
            try
            {
                _driver
                .FindElement(_by)
                .Click();
            }
            catch (Exception ex)
            {
                _logging.Error("Error while clicking the element" + ex.Message);
                throw new AutomationException("Error while clicking the element" + ex.Message);
            }
        }

        public void SendKeys(string text)
        {
            try
            {
                _driver
                    .FindElement(_by)
                    .SendKeys(text);
            }
            catch (Exception ex)
            {
                _logging.Error("Error while keys sending" + ex.Message);
                throw new AutomationException("Error while keys sending" + ex.Message);
            }
        }

		
	}
}
