using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowSelenium.Hooks
{
    public class HookInitialization
    {
        public IWebDriver webDriver;
  
        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver();

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Close();
        }
    }
}