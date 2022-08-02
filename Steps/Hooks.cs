// using Allure.Commons;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CSharp_Selenium_RestSharp_BDD.Utils;
using CSharp_Selenium_RestSharp_BDD.PageObjects;

namespace CSharp_Selenium_RestSharp_BDD.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        // public  AllureLifecycle _allureLifecycle;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            // _allureLifecycle = AllureLifecycle.Instance;
        }

        // This step is implemented like a hook for UI tests only.
        [Given(@"User is using browser")]
        public void GivenUserisusingbrowser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            DriverClass driverClass = new DriverClass(_scenarioContext);
            IWebDriver driver = driverClass.StartDriver((string)data.Browser);

            _scenarioContext.Set(driverClass, "DriverClass");
            _scenarioContext.Set(driver, "Driver");

            LoginPage loginPage = new LoginPage(driver);
            _scenarioContext.Set(loginPage, "LoginPage");
        }

        [BeforeScenario]
        //[Obsolete]
        public void BeforeFeature()
        {
            // DriverClass driverClass = new DriverClass();
            // IWebDriver driver = driverClass.StartDriver();

            // _scenarioContext.Set(driverClass, "DriverClass");
            // _scenarioContext.Set(driver, "Driver");

            // LoginPage loginPage = new LoginPage(driver);
            // _scenarioContext.Set(loginPage, "LoginPage");

        }

        // [BeforeTestRun]
        // public static void CleanAllureDirecory()
        // {
        //     AllureLifecycle.Instance.CleanupResultDirectory();
        // }

        // [OneTimeSetUp]
        // public void SetupForAllure()
        // {
        //     Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        // }

        [AfterScenario]
        public void AfterFeature()
        {
            _scenarioContext.Get<DriverClass>("DriverClass").StopDriver();
            //_scenarioContext.Get<ChromiumDriver>("WebDriver").Quit();
        }
    }
}