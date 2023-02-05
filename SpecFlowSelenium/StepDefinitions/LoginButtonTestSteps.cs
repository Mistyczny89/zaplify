using NUnit.Framework;
using OpenQA.Selenium;
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

        [When(@"The '([^']*)' field is empty")]
        public void WhenTheFieldIsEmpty(string field)
        {
            IWebElement webElement = field switch
            {
                "Email" => loginPage.PasswordField,
                "Password" => loginPage.PasswordField,
                _ => throw new NotImplementedException($"There is no test definition for \"{field}\" field"),
            };

            string valueToCheck = webElement.GetAttribute("value");
            Assert.IsTrue(string.IsNullOrEmpty(valueToCheck), $"{field} field is not empty!");
        }

        [Then(@"Log in button should be in (\w+) state")]
        public void ThenLogInButtonShouldBeUnactivve(string buttonState)
        {
            Assert.IsTrue(loginPage.LoginButton.GetAttribute("class").Contains($"button {buttonState}"), "Log in Button should be active, but isn't");
        }

        #endregion

    }
}