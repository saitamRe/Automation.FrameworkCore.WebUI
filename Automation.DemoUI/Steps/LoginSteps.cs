using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.ISteps;
using Automation.DemoUI.WebAbstractions.Pages;
using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class LoginSteps : ILoginSteps
    {
        ILoginPage _loginPage;
        IAtConfig _config;
        
        public LoginSteps(IAtConfig atConfig, IDrivers driver, ILogging logging, ILoginPage loginPage)
        {
            _loginPage = loginPage;
            _config = atConfig;
        }

        [Given(@"Login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _loginPage.Login(_config.GetConfiguration("username"), _config.GetConfiguration("password"));
        }

        [Given(@"Login with invalid credentials")]
        public void GivenLoginWithInvalidCredentials()
        {
            _loginPage.Login(_config.GetConfiguration("invalid_username"), _config.GetConfiguration("invalid_password"));
        }



    }
}
