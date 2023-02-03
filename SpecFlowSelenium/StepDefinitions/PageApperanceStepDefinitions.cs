using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class PageApperanceStepDefinitions
    {
        #region Fields and Constants

        private readonly DriverHelper _driverHelper;
        readonly LoginPage loginPage;

        public PageApperanceStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }         

        private readonly string welcomingText = "Welcome back";
        private readonly string efficientDayText = "Let’s have an efficient day. Log in to keep up with new opportunties.";

        #endregion

        #region Test Steps

        [Then(@"zaplify logo shoud be visible")]
        public void ThenZaplifyLogoShoudBeVisible()
        {
            bool isLogoVisible = _driverHelper.Driver.FindElement(By.CssSelector("img[alt = 'Logo']")).Displayed;
            Assert.IsTrue(isLogoVisible, "Logo isn't visible.");
        }

        [Then(@"Welcome back information should be visible")]
        public void ThenWelcomeBackInformationShouldBeVisible()
        {
            string recivedWelcomingText = _driverHelper.Driver.FindElement(By.CssSelector("p[class*='root title']")).Text;
            Assert.AreEqual(welcomingText, recivedWelcomingText, "Error with welcoming text.");
        }

        [Then(@"Let’s have an efficient day\. Log in to keep up with new opportunties\.' information should be visible")]
        public void ThenLetSHaveAnEfficientDay_LogInToKeepUpWithNewOpportunties_InformationShouldBeVisible()
        {
            string recivedWelcomingText = _driverHelper.Driver.FindElement(By.CssSelector("p[class*='root description']")).Text;
            Assert.AreEqual(efficientDayText, recivedWelcomingText, "Error with \"Have An Efficient Day\" text.");
        }

        [Then(@"Email field should be visible")]
        public void ThenEmailFieldShouldBeVisible()
        {
            Assert.IsTrue(loginPage.EmailField.Displayed, "Email field is not visible.");
        }

        [Then(@"Password field should be visible")]
        public void ThenPasswordFieldShouldBeVisible()
        {
            Assert.IsTrue(loginPage.PasswordField.Displayed, "Password field is not visible.");
        }

        [Then(@"LogIn filed should be visible")]
        public void ThenLogInFiledShouldBeVisible()
        {
            Assert.IsTrue(loginPage.LoginButton.Displayed, "Log in field is not visible.");
        }

        [Then(@"([a-zA-Z]*) placeholder should be visible")]
        public void ThenlaceholderShouldBeVisible(string placeholder)
        {

            string placeholderVal = placeholder switch
            {
                "Email" => loginPage.EmailField.GetAttribute("placeholder"),
                "Password" => loginPage.PasswordField.GetAttribute("placeholder"),
                _ => throw new NotImplementedException(),
            };
               
            Assert.AreEqual(placeholderVal, placeholder, $"{placeholder} placeholder is not visible");
        }

        [When(@"I click on zaplify logo")]
        public void WhenIClickOnZaplifyLogo()
        {
            loginPage.Logo.Click();
        }

        [Then(@"I should be on page (https:\/\/.+\..{2,3}\/)")]
        public void ThenIShouldBeOnMainPageHttpsZaplify_Com(string page)
        {
            Assert.That(_driverHelper.Driver.Url, Is.EqualTo(page), "URL is not correct");
        }

        #endregion
    }
}