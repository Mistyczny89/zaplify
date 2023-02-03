using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class HelperTestSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;
        LoginPage loginPage;

        public HelperTestSteps(DriverHelper driverHelper)
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
            if (loginPage.RequiredEmailInfoList.Count > 0)
                Assert.AreEqual(requiredInfo, loginPage.RequiredEmailInfo.Text);
            else
                Assert.IsNotEmpty(loginPage.RequiredEmailInfoList, "There is no information under Email Field");           
        }

        [Then(@"I should see '([^']*)' information under Password field")]
        public void ThenIShouldSeeUnderPasswordField(string requiredInfo)
        {
            if (loginPage.RequiredPasswordlInfoList.Count > 0)            
                Assert.AreEqual(requiredInfo, loginPage.RequiredPasswordlInfo.Text);            
            else            
                Assert.IsNotEmpty(loginPage.RequiredPasswordlInfoList, "There is no information under Password Field");
                      
        }

        [Then(@"Information under Email field should not exist")]
        public void ThenInformationUnderEmailFieldShouldBeEmpty()
        {
            Assert.IsTrue(loginPage.RequiredEmailInfoList.Count == 0);
        }

        [When(@"I send backspace in Email field (\d) time\(s\)")]
        public void WhenISendBackspaceInEmailTimes(int backspaces)
        {
            for (int i = 0; i < backspaces; i++)
                loginPage.EmailField.SendKeys(Keys.Backspace);            
        }

        [When(@"I send backspace in Password field (\d) time\(s\)")]
        public void WhenISendBackspaceInPasswordFieldTimes(int backspaces)
        {
            for (int i = 0; i < backspaces; i++)
                loginPage.PasswordField.SendKeys(Keys.Backspace);
        }



        #endregion

    }
}
