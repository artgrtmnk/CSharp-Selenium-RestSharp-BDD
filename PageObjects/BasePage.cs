using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium_RestSharp_BDD.PageObjects
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;
        
        public BasePage(IWebDriver Driver)
        {
            _driver = Driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
    }
}