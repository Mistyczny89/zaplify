using NUnit.Framework;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class PasswordVisibilityTestSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;
        readonly LoginPage loginPage;

        public PasswordVisibilityTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }

        #endregion

        #region Test Setps

        [Then(@"number of dots shoud be equal to number of characters in Password '(.*)'")]
        public void ThenNumberOfDotsShoudBeEqualToNumberOfCharactersInPassword(string password)
        {
            string pwd = GherkinFieldsHelper.GetGherkinObject(password);
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("value").Length, pwd.Length, "Length of the hidden password is incorrect.");
        }

        [When(@"I click on toggle password visibility button")]
        public void WhenIClickOnTogglePasswordVisibilityButton()
        {
            loginPage.ClickPwdToggle();
        }

        [Then(@"I should see dots as my Password")]
        public void ThenIShouldSeeDotsAsMyPassowd()
        {
            string expectedType = "password";
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Type"), expectedType, $"Password field Type should be \"{expectedType}\", but isn't.");
        }

        [Then(@"I should see '(.*)' in Password field")]
        public void ThenIShouldSeeInPasswordField(string password)
        {
            string pwd = GherkinFieldsHelper.GetGherkinObject(password);
            string expectedType = "text";
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Type"), expectedType, $"Password field Type should be \"{expectedType}\", but isn't.");
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Value"), pwd, "Password isn't visible.");
        }


        #endregion

    }
}
