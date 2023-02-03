using NUnit.Framework;
using OpenQA.Selenium;
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

        private const string incorrectLoginInfo = "Email or password incorrect";
        private const string incorrectLoginInfo2 = "The password or email you entered is incorrect.";

        public LogOnPageTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
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
            Assert.AreEqual(_driverHelper.Driver.FindElement(By.ClassName("error")).Text, incorrectLoginInfo);
        }


        [When(@"I log on the site")]
        public void WhenILogOnTheSite()
        {
            loginPage.LogIntoPage();
        }

        [Then(@"I see welcoming info")]
        public void ThenISeeWelcomingInfo()
        {
            throw new PendingStepException();
        }


        #endregion
    }
}
