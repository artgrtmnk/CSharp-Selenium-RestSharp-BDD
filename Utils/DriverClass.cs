using OpenQA.Selenium;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class DriverClass
    {
        private IWebDriver Driver;
        public readonly ScenarioContext _scenarioContext;
        public DriverClass(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver StartDriver(String browserName)
        {
            // new DriverManager().SetUpDriver(new ChromeConfig());

            // Driver = new ChromeDriver();

            Driver = GetBrowser(browserName);
            

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();

            // _scenarioContext.Set(Driver, "WebDriver");

            return Driver;
        }

        public void StopDriver()
        {
            Driver.Quit();
        }

        private dynamic GetBrowser(string browserName)
        {
            switch (browserName) {
                case "firefox":
                    {
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        return new ChromeDriver();
                    }
                case "chrome":
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        return new ChromeDriver();
                    }
                default: 
                {
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                }
            }
        }
    }
}