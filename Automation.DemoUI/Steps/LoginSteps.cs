using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class LoginSteps
    {
        LoginPage _loginPage;
        IAtConfig _config;
        
        public LoginSteps(IAtConfig atConfig)
        {
            _loginPage = new LoginPage(atConfig);
            _config = atConfig;
        }

        [Given(@"Login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _loginPage.LoginWithValidCreds(_config.GetConfiguration("username"), _config.GetConfiguration("password"));
        }

        [Given(@"Login with invalid credentials")]
        public void GivenLoginWithInvalidCredentials()
        {
            _loginPage.LoginWithValidCreds(_config.GetConfiguration("invalid_username"), _config.GetConfiguration("invalid_password"));
        }



    }
}
