using Automation.DemoUI.Pages;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class LoginSteps
    {
        LoginPage _loginPage;
        public LoginSteps()
        {
            _loginPage = new LoginPage();
        }

        [Given(@"Login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _loginPage.LoginWithValidCreds("standard_user", "secret_sauce");
        }


    }
}
