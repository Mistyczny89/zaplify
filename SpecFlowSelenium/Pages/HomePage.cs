using OpenQA.Selenium;

namespace SpecFlowSelenium.Pages
{
    internal class HomePage
    {
        private readonly IWebDriver Driver;
        public HomePage(IWebDriver driver) => Driver = driver;

        #region Fields and Constants

        public const string zaplifyMainPage = "https://zaplify.com/";

        #endregion

        #region UI elements
        public IWebElement WelcomeInformationField => Driver.FindElement(By.CssSelector("[class='MuiTypography-root MuiTypography-h5']"));
        
        #endregion
    }
}
