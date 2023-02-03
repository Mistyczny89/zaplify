using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowSelenium.Hooks;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class PageApperanceStepDefinitions
    {
        #region Fields and Constants

        /// <summary>
        /// Gets the Web Driver
        /// </summary>
        public IWebDriver WebDriver { get; }

        private readonly IWebDriver webDriver = new ChromeDriver();

        LoginPage loginPage;

        private readonly string welcomingText = "Welcome back";
        private readonly string efficientDayText = "Let’s have an efficient day. Log in to keep up with new opportunties.";  
        
        #endregion

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage = new(webDriver);
            loginPage.GoToPage();
        }

        [Then(@"zaplify logo shoud be visible")]
        public void ThenZaplifyLogoShoudBeVisible()
        {
            bool isLogoVisible = webDriver.FindElement(By.CssSelector("img[alt = 'Logo']")).Displayed;
            Assert.IsTrue(isLogoVisible, "Logo isn't visible.");
        }

        [Then(@"Welcome back information should be visible")]
        public void ThenWelcomeBackInformationShouldBeVisible()
        {
            string recivedWelcomingText = webDriver.FindElement(By.CssSelector("p[class*='root title']")).Text;
            Assert.AreEqual(welcomingText, recivedWelcomingText, "Error with welcoming text.");
        }

        [Then(@"Let’s have an efficient day\. Log in to keep up with new opportunties\.' information should be visible")]
        public void ThenLetSHaveAnEfficientDay_LogInToKeepUpWithNewOpportunties_InformationShouldBeVisible()
        {
            string recivedWelcomingText = webDriver.FindElement(By.CssSelector("p[class*='root description']")).Text;
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
            Assert.That(webDriver.Url, Is.EqualTo(page), "URL is not correct");
        }

    }
}