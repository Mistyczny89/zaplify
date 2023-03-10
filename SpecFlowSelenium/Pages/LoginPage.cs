using OpenQA.Selenium;

namespace SpecFlowSelenium.Pages
{
    public class LoginPage : GherkinFieldsHelper
    {
        private readonly IWebDriver Driver;
        public LoginPage(IWebDriver driver) => Driver = driver;

        #region UI elements
        public IWebElement EmailField => Driver.FindElement(By.CssSelector("input[name='email']"));
        public IWebElement PasswordField => Driver.FindElement(By.CssSelector("input[name='password']"));
        public IWebElement TogglePsswrdBtn => Driver.FindElement(By.CssSelector("[aria-label='toggle password visibility']"));
        public IWebElement LoginButton => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement Logo => Driver.FindElement(By.CssSelector("img[alt = 'Logo']"));
        public IWebElement RequiredEmailInfo => Driver.FindElement(By.CssSelector(@"div[class*=jss14] > p[class*='MuiFormHelperText-contained']"));
        public IWebElement RequiredPasswordlInfo => Driver.FindElement(By.CssSelector(@"div[class*=jss15] > p[class*='MuiFormHelperText-contained']"));
        public IWebElement InvalidRequestWindow => Driver.FindElement(By.ClassName("error"));
        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> RequiredEmailInfoList => Driver.FindElements(By.CssSelector(@"div[class*=jss14] > p[class*='MuiFormHelperText-contained']"));
        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> RequiredPasswordlInfoList => Driver.FindElements(By.CssSelector(@"div[class*=jss15] > p[class*='MuiFormHelperText-contained']"));

        #endregion

        #region Clicks

        public void ClickEmail() => EmailField.Click();
        public void ClickPassword() => PasswordField.Click();
        public void ClickLogin() => LoginButton.Click();
        public void ClickPwdToggle() => TogglePsswrdBtn.Click();

        #endregion

        #region Public methods

        public void GoToPage()
        {
            string url = GherkinFieldsHelper.GetGherkinObject("Login Page");
            Driver.Navigate().GoToUrl(url);
        }

        #endregion

        #region Private ethods

        public void LogIntoPage()
        {
            string username = GetGherkinObject("Registred User");
            string password = GetGherkinObject("Registed User Pwd");

            EmailField.SendKeys(username);
            PasswordField.SendKeys(password);
            ClickLogin();
        }

        #endregion

    }
}