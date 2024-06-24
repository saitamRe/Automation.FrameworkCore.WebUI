using Automation.DemoUI.WebAbstraction;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;


namespace Automation.DemoUI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly IAtConfig _config;
        IWebElement userName => _driver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement passwd =>_driver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement loginBtn => _driver.FindElement(By.XPath("//input[@id='login-button']"));
        public LoginPage(IAtConfig atConfig, IWebDriver driver)
        {
            _config = atConfig;
            _driver = driver;
            _driver.Manage().Window.Maximize();
        }

        public void LoginWithValidCreds(string username, string password)
        {
            _driver.Navigate().GoToUrl(_config.GetConfiguration("url"));
            userName.SendKeys(username);
            passwd.SendKeys(password);
            loginBtn.Click();
        }

        public void LoginWithInvalidCreds(string username, string password)
        {
            _driver.Navigate().GoToUrl(_config.GetConfiguration("url"));
            userName.SendKeys(username);
            passwd.SendKeys(password);
            loginBtn.Click();
        }
    }


}
