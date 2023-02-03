using NUnit.Framework;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class EmptyFieldsTestSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;
        LoginPage loginPage;

        public EmptyFieldsTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }

        #endregion

        #region Test Steps

        [When(@"I click of Email field")]
        public void WhenIClickOfEmailField()
        {
            loginPage.ClickEmail();
        }

        [When(@"I click of Password field")]
        public void WhenIClickOfPasswordField()
        {
            loginPage.ClickPassword();
        }

        [Then(@"I should see '([^']*)' information under Email field")]
        public void ThenIShouldSeeInformationUnderEmailField(string requiredInfo)
        {
            Assert.AreEqual(loginPage.RequiredEmailInfo.Text, requiredInfo);
        }

        [Then(@"I should see '([^']*)' information under Password field")]
        public void ThenIShouldSeeUnderPasswordField(string requiredInfo)
        {
            Assert.AreEqual(loginPage.RequiredPasswordlInfo.Text, requiredInfo);
        }

        #endregion

    }
}
