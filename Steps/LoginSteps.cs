using TechTalk.SpecFlow;
using CSharp_Selenium_RestSharp_BDD.PageObjects;
	
	namespace CSharp_Selenium_RestSharp_BDD.Steps
	{
		[Binding]
		public class LoginSteps
		{
			private readonly ScenarioContext _scenarioContext;
	
			public LoginSteps(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
            [Given(@"User has opened Oracle Profile page")]
            public void GivenUserhasopenedOracleProfilepage()
            {
                _scenarioContext.Get<LoginPage>("LoginPage")
                    .OpenPage();
            }

            [When(@"User inputs '(.*)' as email")]
            public void WhenUserinputsemailasemail(string email)
            {
                _scenarioContext.Get<LoginPage>("LoginPage")
                    .FillUserNameField(email);
            }

            [When(@"User inputs '(.*)' as password")]
            public void GivenUserinputspasswordaspassword(string password)
            {
                _scenarioContext.Get<LoginPage>("LoginPage")
                    .FillPasswordField(password);
            }

            [When(@"User presses Sign In button")]
            public void GivenUserpressesSignInbutton()
            {
                _scenarioContext.Get<LoginPage>("LoginPage")
                    .ClickLoginButton();
            }

            [Then(@"User sees invalid credentials message")]
            public void ThenUserseesinvalidcredentialsmessage()
            {
                _scenarioContext.Get<LoginPage>("LoginPage")
                    .VerifyErrorMessage("Invalid username and/or password.");
            }

		}
	}