using NUnit.Framework;
using OpenQA.Selenium;
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

        [Then(@"I should see Email or password incorrect")]
        public void ThenIShouldSeeEmailOrPasswordIncorrect()
        {
            Assert.AreEqual(incorrectLoginInfo2, _driverHelper.Driver.FindElement(By.ClassName("error")).Text);
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
            var x = homePage.WelcomeInformationField.Text;
        }


        #endregion
    }
}
