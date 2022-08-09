using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace CSharp_Selenium_RestSharp_BDD.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly String BaseUrl = "https://profile.oracle.com/";
        public LoginPage(IWebDriver _driver) : base(_driver) => PageFactory.InitElements(_driver, this);

        // Elements
        [FindsBy(How = How.Id, Using = "sso_username")]
        private IWebElement UserNameField;

        [FindsBy(How = How.Id, Using = "ssopassword")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "signin_button")]
        private IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "errormsg")]
        private IWebElement ErrorMessageText;

        // Methods
        public void OpenPage() 
        {
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void FillUserNameField(string UserName)
        {
            EnterText(UserNameField, UserName);
        }

        public void FillPasswordField(string Password)
        {
            EnterText(PasswordField, Password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void VerifyErrorMessage(string ErrorMsg)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(ErrorMessageText, ErrorMsg));
            StringAssert.Contains(ErrorMsg, ErrorMessageText.Text, "Text assertion error.");
        }
    }
}