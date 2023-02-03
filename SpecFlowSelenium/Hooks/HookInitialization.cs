using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    public class HookInitialization
    {
        private DriverHelper _driverHelper;
        public HookInitialization(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driverHelper.Driver = new ChromeDriver(options);

            _driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
  
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Close();
        }
    }
}