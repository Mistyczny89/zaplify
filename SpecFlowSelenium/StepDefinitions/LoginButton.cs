using NUnit.Framework;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class LoginButton
    {
        #region Fields and Constants
                
        private DriverHelper _driverHelper; 
        LoginPage loginPage;

        public LoginButton(DriverHelper driverHelper) 
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }
        
        #endregion

        #region Test Setps
        [Given(@"I am on login page")]
        public void GivenIGoToHttpsStaging_App_Zaplify_ComLogin()
        {
            loginPage.GoToPage();
        }

        [When(@"the field email is empty")]
        public void WhenTheFieldEmailIsEmpty()
        {
            Assert.IsTrue(string.IsNullOrEmpty(loginPage.EmailField.GetAttribute("value")));
        }

        [When(@"the field password is empty")]
        public void WhenTheFieldPasswordIsEmpty()
        {
            Assert.IsTrue(string.IsNullOrEmpty(loginPage.PasswordField.GetAttribute("value")));
        }

        [Then(@"Log in button should be unactivve")]
        public void ThenLogInButtonShouldBeUnactivve()
        {
            Assert.IsTrue(loginPage.LoginButton.GetAttribute("class").Contains("button disabled"));
        }

        [When(@"I type '([^']*)' in Email Field")]
        public void WhenITypeInEmailField(string testEmail)
        {
            throw new PendingStepException();
        }

        #endregion

    }
}
