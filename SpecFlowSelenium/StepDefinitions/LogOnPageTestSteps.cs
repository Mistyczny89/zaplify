using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    internal class LogOnPageTestSteps
    {
        #region Fields and Constants

        private readonly DriverHelper _driverHelper;
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        private const string incorrectLoginShort = "Email or password incorrect";
        private const string incorrectLoginLong = "The password or email you entered is incorrect.";

        public LogOnPageTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
            homePage = new(_driverHelper.Driver);
        }

        #endregion

        #region Test Steps

        [When(@"I click on Log in button")]
        public void WhenIClickOnLogInButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should see \'(.*)\' information")]
        public void ThenIShouldSeeEmailOrPasswordIncorrect(string info)
        {
            Assert.AreEqual(info, loginPage.InvalidRequestWindow.Text, $"\"{info}\" information is incorrect");
        }

        [Then(@"I should see one of incorrect password informations")]
        public void ThenIShouldSeeOneOfIncorrectPasswordInformations()
        {
            Assert.That(loginPage.InvalidRequestWindow.Text, Is.AnyOf(incorrectLoginShort, incorrectLoginLong), "Wrong information about incorrect password");
        }

        [When(@"I log on the site")]
        public void WhenILogOnTheSite()
        {
            loginPage.LogIntoPage();
            WebDriverWait wait = new(_driverHelper.Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => homePage.WelcomeInformationField.Displayed);
        }

        [Then(@"I see welcoming info")]
        public void ThenISeeWelcomingInfo()
        {
            Assert.AreEqual("Hello Pawel", homePage.WelcomeInformationField.Text, "There is wrong information on home page after log in");
        }

        [When(@"I type wrong password (\d*) times")]
        public void WhenITypeWrongPasswordTimes(int p)
        {
            string wrongPassword = "abcd";
            WebDriverWait wait = new(_driverHelper.Driver, TimeSpan.FromSeconds(10));

            for (int i = 0; i < p; i++)
            {
                loginPage.PasswordField.SendKeys(wrongPassword);
                loginPage.ClickLogin();
                Thread.Sleep(3000); // I hate this - If you see this: this is not finished.
                wait.Until(d => loginPage.InvalidRequestWindow.Displayed);
            }
        }

        [Then(@"I should see \'(.*)\'")]
        public void ThenIShouldSee(string info)
        {
            string informationToCheck = GherkinFieldsHelper.GetGherkinObject(info);
            Assert.AreEqual(informationToCheck, loginPage.InvalidRequestWindow.Text, $"\"{info}\" information is incorrect");
        }

        [Then(@"'(.*)' field should stay filled")]
        public void ThenFieldShouldStayFilled(string field)
        {
            IWebElement webElement = field switch
            {
                "Email" => loginPage.PasswordField,
                "Password" => loginPage.PasswordField,
                _ => throw new NotImplementedException($"There is no test definition for \"{field}\" field"),
            };

            Assert.IsNotEmpty(webElement.GetAttribute("value"), $"{field} field is empty");
        }

        #endregion
    }
}
