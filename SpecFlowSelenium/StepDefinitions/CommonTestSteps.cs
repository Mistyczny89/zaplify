using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;
        private readonly LoginPage loginPage;

        public CommonSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }

        #endregion

        #region Common Test Steps

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.GoToPage();
        }

        [When(@"I type '(.*)' in Email Field")]
        public void WhenITypeInEmailField(string testEmail)
        {
            string email = GherkinFieldsHelper.GetGherkinObject(testEmail);
            loginPage.EmailField.SendKeys(email);
        }

        [When(@"I type '(.*)' in Passowrd Field")]
        public void WhenITypeInPassowrdField(string testPassword)
        {
            string password = GherkinFieldsHelper.GetGherkinObject(testPassword);
            loginPage.PasswordField.SendKeys(password);
        }

        #endregion

    }
}