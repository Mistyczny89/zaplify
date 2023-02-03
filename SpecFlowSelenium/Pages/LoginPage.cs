using OpenQA.Selenium;

namespace SpecFlowSelenium.Pages
{
    public class LoginPage
    {
        #region Properties and idexers

        /// <summary>
        /// Gets the Web Driver
        /// </summary>
        public IWebDriver WebDriver { get; }

        public LoginPage(IWebDriver webDriver) => WebDriver = webDriver;

        #endregion

        #region Fields and Constants

        public const string logPage = "https://staging.app.zaplify.com/login";
        public const string zaplifyMainPage = "https://zaplify.com/";

        #endregion

        #region UI elements
        public IWebElement EmailField => WebDriver.FindElement(By.CssSelector("input[name='email']"));
        public IWebElement PasswordField => WebDriver.FindElement(By.CssSelector("input[name='password']"));
        public IWebElement MainPageLogo => WebDriver.FindElement(By.CssSelector("img[alt='Logo']"));
        public IWebElement LoginButton => WebDriver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement Logo => WebDriver.FindElement(By.CssSelector("img[alt = 'Logo']"));

        #endregion

        #region Clicks
        public void ClickEmail() => EmailField.Click();
        public void ClickPassword() => PasswordField.Click();
        public void ClickLogin() => LoginButton.Click();

        #endregion

        #region Public methods
        public void Login(string userName, string passoword)
        {
            EmailField.SendKeys(userName);
            PasswordField.SendKeys(passoword);
        }

        public void GoToPage()
        {
            WebDriver.Navigate().GoToUrl(logPage);
        }
        #endregion

        #region Private ethods

        #endregion


    }
}
