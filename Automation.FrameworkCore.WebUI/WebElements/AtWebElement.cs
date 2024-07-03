using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.CustomException;
using Automation.FrameworkCore.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Automation.FrameworkCore.WebUI.WebElements
{
    public class AtWebElement : IAtWebElement
    {
        private IWebDriver _driver;
        private By _by;
        private readonly ILogging _logging;

        public AtWebElement()
        {
            _logging = SpecflowRunner._serviceProvider.GetRequiredService<ILogging>();

        }

        public void Set(IWebDriver driver, By by)
        {
            if (driver == null || by == null)
            {
                throw new ArgumentNullException("Driver or By parameter cannot be null");
            }
            else
            {
                _by = by;
                _driver = driver;
            }
        }
        public void Click(int timeOut)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement element = GetElementWithExplicitWait(timeOut);
                    element.Click();
                    break;
                }
                catch(StaleElementReferenceException ex) { }
                catch (Exception ex)
                {
                    _logging.Error("Error while clicking the element " + ex.Message);
                    throw new AutomationException("Error while clicking the element " + ex.Message);
                }
            }
             
        }

        public void SendKeys(string text, int timeOut)
        {
            for(int i  = 0; i < 5; i++)
            {
                try
                {
                    IWebElement element = GetElementWithExplicitWait(timeOut);
                    element.SendKeys(text);
                    break;
                }
                catch(StaleElementReferenceException e) { }

                catch (Exception ex)
                {
                    _logging.Error("Error while keys sending " + ex.Message);
                    throw new AutomationException("Error while keys sending " + ex.Message);
                }
            }
            
        }

        public void ClearText(int timeOut)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement element = GetElementWithExplicitWait(timeOut);
                    element.SendKeys(Keys.Control + "a");
                    element.SendKeys(Keys.Delete);
                    break;
                }
                catch (StaleElementReferenceException e) { }

                catch (Exception ex)
                {
                    _logging.Error("Error while keys sending " + ex.Message);
                    throw new AutomationException("Error while keys sending " + ex.Message);
                }
            }
        }

        public string GetText(int timeOut)
        {
            string text = String.Empty;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement element = GetElementWithExplicitWait(timeOut);
                    text = element.Text;
                    break;
                }
                catch (StaleElementReferenceException e) { }

                catch (Exception ex)
                {
                    _logging.Error("Error while keys sending " + ex.Message);
                    throw new AutomationException("Error while keys sending " + ex.Message);
                }
            }
            return text;
        }

        public string GetAttribute(string attributeName, int timeOut)
        {
            return string.Empty;
        }

        private IWebElement GetElementWithExplicitWait(int timeoutInSeconds = 3)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException),
                    typeof(ElementNotVisibleException), typeof(ElementNotInteractableException));
                return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(_by));
            }
            catch (Exception ex)
            {
                _logging.Error(("Element is not interractable " + ex.Message));
                throw new AutomationException(("Element is not interractable ") + ex.Message);
            }
        }

    }
}
