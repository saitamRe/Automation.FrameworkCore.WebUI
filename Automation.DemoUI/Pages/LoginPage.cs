using Automation.DemoUI.WebAbstraction;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;


namespace Automation.DemoUI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly IAtConfig _config;
        private readonly string url;
        ILogging _logger;

        // Element locators
        private static readonly By UserNameLocator = By.XPath("//input[@id='user-name']");
        private static readonly By PasswordLocator = By.XPath("//input[@id='password']");
        private static readonly By LoginButtonLocator = By.XPath("//input[@id='login-button']");

        // Elements
        private IWebElement UserName => _driver.FindElement(UserNameLocator);
        private IWebElement Password => _driver.FindElement(PasswordLocator);
        private IWebElement LoginButton => _driver.FindElement(LoginButtonLocator);
        public LoginPage(IAtConfig atConfig, IWebDriver driver, ILogging logging)
        {
            _logger = logging;
            _config = atConfig;
            _driver = driver;
            _driver.Manage().Window.Maximize();
        }

        public void Login(string username, string password)
        {
            _logger.Information("Navigating to login page");
            _driver.Navigate().GoToUrl(_config.GetConfiguration("url"));
            UserName.SendKeys(username);
            Password.SendKeys(password);
            _logger.Information("Submitting the login form");
            LoginButton.Click();
        }
    }


}
