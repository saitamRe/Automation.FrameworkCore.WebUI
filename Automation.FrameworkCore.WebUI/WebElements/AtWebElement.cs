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
        private readonly IWebDriver _driver;
        private By _by;
        private ILogging _logging;

        public AtWebElement(IWebDriver driver, By by)
        {
            _driver = driver;
            _by = by;
            _logging = SpecflowRunner._serviceProvider.GetRequiredService<ILogging>();
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
