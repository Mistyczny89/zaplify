using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Cast;
using OpenQA.Selenium.Support.UI;
using SpecFlowSelenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    internal class LogOnPageTestSteps
    {
        #region Fields and Constants

        private DriverHelper _driverHelper;

        LoginPage loginPage;
        HomePage homePage;


        private const string incorrectLoginInfo = "Email or password incorrect";
        private const string incorrectLoginInfo2 = "The password or email you entered is incorrect.";

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
            Assert.AreEqual(info, loginPage.InvalidRequestWindow.Text);
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
            Assert.AreEqual("Hello Pawel", homePage.WelcomeInformationField.Text);
        }

        [When(@"I type wrong password (\d) times")]
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
            Assert.AreEqual(info, loginPage.InvalidRequestWindow.Text);
        }

        [Then(@"'(.*)' field should stay filled")]
        public void ThenFieldShouldStayFilled(string field)
        {
            IWebElement webElement = field switch
            {
                "Email" => loginPage.PasswordField,
                "Password" => loginPage.PasswordField,
                _ => throw new NotImplementedException(),
            };

            Assert.IsNotEmpty(webElement.GetAttribute("value"));
        }



        #endregion
    }
}
