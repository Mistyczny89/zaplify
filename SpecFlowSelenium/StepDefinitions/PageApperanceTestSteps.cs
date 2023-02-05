using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSelenium.Pages;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class PageApperanceTestSteps
    {
        #region Fields and Constants

        private readonly DriverHelper _driverHelper;
        readonly LoginPage loginPage;

        public PageApperanceTestSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new(_driverHelper.Driver);
        }         

        #endregion

        #region Test Steps

        [Then(@"zaplify logo shoud be visible")]
        public void ThenZaplifyLogoShoudBeVisible()
        {
            bool isLogoVisible = loginPage.Logo.Displayed;
            Assert.IsTrue(isLogoVisible, "Logo isn't visible.");
        }

        [Then(@"'([^']*)' information should be visible")]
        public void ThenInformationShouldBeVisible(string informaion)
        {
            string selector = informaion switch
            {
                "Welcome back" => "p[class*='root title']",
                "Efficient day" => "p[class*='root description']",
                _ => throw new NotImplementedException("There is no test step definition for \"{informaion}\"."),
            };

            string informationToCheck = GherkinFieldsHelper.GetGherkinObject(informaion);
            string recivedText = _driverHelper.Driver.FindElement(By.CssSelector(selector)).Text;
            Assert.AreEqual(informationToCheck, recivedText, "Error with welcoming text.");
        }

        [Then(@"'([^']*)' field should be visible")]
        public void ThenFieldShouldBeVisible(string field)
        {
            IWebElement fieldToCheck = field switch
            {
                "Email" => loginPage.EmailField,
                "Password" => loginPage.PasswordField,
                "LogIn" => loginPage.LoginButton,
                _ => throw new NotImplementedException($"There is no test definition for \"{field}\" field"),
            };

            Assert.IsTrue(fieldToCheck.Displayed, $"{field} field is not visible.");
        }

        [Then(@"Password toggle button should be visible")]
        public void ThenPasswordToggleButtonShouldBeVisible()
        {
            Assert.IsTrue(loginPage.TogglePsswrdBtn.Displayed, "Password toggle button is not visible.");
        }

        [Then(@"([a-zA-Z]*) placeholder should be visible")]
        public void ThenlaceholderShouldBeVisible(string placeholder)
        {               
            IWebElement placeholderToCheck = placeholder switch
            {
                "Email" => loginPage.EmailField,
                "Password" => loginPage.PasswordField,
                _ => throw new NotImplementedException($"There is no test definition for \"{placeholder}\" placeholder"),
            };            

            Assert.AreEqual(placeholderToCheck.GetAttribute("placeholder"), placeholder, $"{placeholder} placeholder is not visible");
        }

        [When(@"I click on zaplify logo")]
        public void WhenIClickOnZaplifyLogo()
        {
            loginPage.Logo.Click();
        }

        [Then(@"I should be on page '([^']*)'")]
        public void ThenIShouldBeOnPage(string page)
        {
            string pageToCheck = GherkinFieldsHelper.GetGherkinObject(page);
            Assert.That(_driverHelper.Driver.Url, Is.EqualTo(pageToCheck), "URL is not correct");
        }

        #endregion
    }
}