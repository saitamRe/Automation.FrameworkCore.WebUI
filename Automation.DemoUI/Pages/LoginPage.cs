using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;


namespace Automation.DemoUI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "Latest");
            
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        public void LoginWithValidCreds(string username, string password)
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            IWebElement userName = _driver.FindElement(By.XPath("//input[@id='user-name']"));
            IWebElement passwd = _driver.FindElement(By.XPath("//input[@id='password']"));
            IWebElement loginBtn = _driver.FindElement(By.XPath("//input[@id='login-button']"));

            userName.SendKeys(username);
            passwd.SendKeys(password);
            loginBtn.Click();
        }
    }


}
