using OpenQA.Selenium;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class DriverClass
    {
        private IWebDriver Driver;
        public readonly ScenarioContext _scenarioContext;

        public IWebDriver StartDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            Driver = new ChromeDriver();
            

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();

            // _scenarioContext.Set(Driver, "WebDriver");

            return Driver;
        }

        public void StopDriver()
        {
            Driver.Quit();
        }
    }
}