using AngleSharp.Common;
using NUnit.Framework;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class PasswordVisibilityTestSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;
        LoginPage loginPage;

        public PasswordVisibilityTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }

        #endregion

        #region Test Setps

        [Then(@"I should see dots as my Password")]
        public void ThenIShouldSeeDotsAsMyPassowd()
        {
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Type"), "password");
        }


        [Then(@"number of dots shoud be equal to number of characters in Password '(.*)'")]
        public void ThenNumberOfDotsShoudBeEqualToNumberOfCharactersInPassword(string password)
        {
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("value").Count(), password.Length);
        }

        [When(@"I click on toggle password visibility button")]
        public void WhenIClickOnTogglePasswordVisibilityButton()
        {
            loginPage.ClickPwdToggle();
        }

        [Then(@"I should see '(.*)' in Password field")]
        public void ThenIShouldSeeInPasswordField(string password)
        {
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Type"), "text");
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("Value"), password);
        }


        #endregion

    }
}
