using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium_RestSharp_BDD.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;
        
        public BasePage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
    }
}