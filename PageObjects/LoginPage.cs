using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharp_Selenium_RestSharp_BDD.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly String BaseUrl = "https://profile.oracle.com/";
        public LoginPage(IWebDriver Driver) : base(Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "sso_username")]
        private IWebElement UserNameField;

        [FindsBy(How = How.Id, Using = "ssopassword")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "signin_button")]
        private IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "errormsg")]
        private IWebElement ErrorMessage;

        public void OpenPage() 
        {
            Driver.Navigate().GoToUrl(BaseUrl);
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
            StringAssert.Contains(ErrorMsg, ErrorMessage.Text, "Text assertion error.");
        }
    }
}