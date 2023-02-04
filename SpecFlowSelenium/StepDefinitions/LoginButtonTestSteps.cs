using NUnit.Framework;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class LoginButtonTestSteps
    {
        #region Fields and Constants
                
        private DriverHelper _driverHelper; 
        LoginPage loginPage;

        public LoginButtonTestSteps(DriverHelper driverHelper) 
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }
        
        #endregion

        #region Test Setps

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

        [Then(@"Log in button should be in (\w+) state")]
        public void ThenLogInButtonShouldBeUnactivve(string buttonState)
        {
            Assert.IsTrue(loginPage.LoginButton.GetAttribute("class").Contains($"button {buttonState}"), "Log in Button should be active, but isn't");
        }

        #endregion

    }
}
