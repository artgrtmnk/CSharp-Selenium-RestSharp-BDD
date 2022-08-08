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
        private IWebDriver _driver;
        public readonly ScenarioContext _scenarioContext;
        public DriverClass(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver StartDriver(String browserName)
        {
            _driver = GetBrowser(browserName);
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();

            return _driver;
        }

        public void StopDriver()
        {
            _driver.Quit();
        }

        private dynamic GetBrowser(string browserName)
        {
            switch (browserName) {
                case "firefox":
                    {
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        return new FirefoxDriver();
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