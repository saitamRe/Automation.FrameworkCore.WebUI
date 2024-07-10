using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.Pages;
using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;


namespace Automation.DemoUI.Pages
{
    public class LoginPage : ILoginPage
    {
        private readonly IDrivers _drivers;
        private readonly IAtConfig _config;
        private readonly ILogging _logger;

        // Element locators
        private readonly By UserNameLocator = By.XPath("//input[@id='user-name']");
        private readonly By PasswordLocator = By.XPath("//input[@id='password']");
        private readonly By LoginButtonLocator = By.XPath("//input[@id='login-button']");

        // Elements
        private IAtWebElement UserName => _drivers.FindElement(UserNameLocator);
        private IAtWebElement Password => _drivers.FindElement(PasswordLocator);
        private IAtWebElement LoginButton => _drivers.FindElement(LoginButtonLocator);
        public LoginPage(IAtConfig atConfig, IDrivers idrivers, ILogging logging)
        {
            _logger = logging;
            _config = atConfig;
            _drivers = idrivers;
        }

        public void Login(string username, string password)
        {
            _logger.Information("Navigating to login page");
            _drivers.GoToUrl(_config.GetConfiguration("url"));
            UserName.SendKeys(username);
            Password.SendKeys(password);
            _logger.Information("Submitting the login form");
            LoginButton.Click();
        }
    }


}
