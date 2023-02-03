using OpenQA.Selenium;

namespace SpecFlowSelenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;
        public LoginPage(IWebDriver driver) => Driver = driver;

        #region Fields and Constants

        public const string logPage = "https://staging.app.zaplify.com/login";
        public const string zaplifyMainPage = "https://zaplify.com/";

        #endregion

        #region UI elements
        public IWebElement EmailField => Driver.FindElement(By.CssSelector("input[name='email']"));
        public IWebElement PasswordField => Driver.FindElement(By.CssSelector("input[name='password']"));
        public IWebElement MainPageLogo => Driver.FindElement(By.CssSelector("img[alt='Logo']"));
        public IWebElement LoginButton => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement Logo => Driver.FindElement(By.CssSelector("img[alt = 'Logo']"));

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
            Driver.Navigate().GoToUrl(logPage);
        }
        #endregion

        #region Private ethods

        #endregion


    }
}
