using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class HelperTestSteps
    {
        #region Fields and Constants

        private readonly DriverHelper _driverHelper;
        readonly LoginPage loginPage;

        public HelperTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }

        #endregion

        #region Test Steps

        [When(@"I click on Email field")]
        public void WhenIClickOnEmailField()
        {
            loginPage.ClickEmail();
        }

        [When(@"I click on Password field")]
        public void WhenIClickOnPasswordField()
        {
            loginPage.ClickPassword();
        }

        [Then(@"I should see '([^']*)' information under '([^']*)' field")]
        public void ThenIShouldSeeInformationUnderField(string required, string field)
        {
            string reqInfo = GherkinFieldsHelper.GetGherkinObject(required);
            IWebElement fieldToCheck;
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> fieldListToCheck;

            switch (field)
            {
                case "Email":
                    fieldToCheck = loginPage.RequiredEmailInfo;
                    fieldListToCheck = loginPage.RequiredEmailInfoList;
                        break;
                default:
                    fieldToCheck = loginPage.RequiredPasswordlInfo;
                    fieldListToCheck = loginPage.RequiredPasswordlInfoList;
                    break;
            }

            if (fieldListToCheck.Count > 0)
                Assert.AreEqual(reqInfo, fieldToCheck.Text, $"There is wrong information under {field} field.");
            else
                Assert.IsNotEmpty(fieldListToCheck, $"There is no information under {field} Field");
        }
       
        [Then(@"Information under Email field should not exist")]
        public void ThenInformationUnderEmailFieldShouldBeEmpty()
        {
            Assert.IsTrue(loginPage.RequiredEmailInfoList.Count == 0, "Information under Email field should not exist.");
        }

        [When(@"I send backspace in '([^']*)' field (.*) time\(s\)")]
        public void WhenISendBackspaceInFieldTimeS(string field, int backspaces)
        {
            IWebElement workingField = field switch
            {
                "Email" => loginPage.EmailField,
                "Password" => loginPage.PasswordField,
                _ => throw new NotImplementedException($"There is no test definition for \"{field}\" field"),
            };

            for (int i = 0; i < backspaces; i++)
                workingField.SendKeys(Keys.Backspace);

        }

        #endregion

    }
}
