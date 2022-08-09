using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CSharp_Selenium_RestSharp_BDD.Utils;
using CSharp_Selenium_RestSharp_BDD.Utils.ApiClients;
	
	namespace CSharp_Selenium_RestSharp_BDD.Steps
	{
		[Binding]
		public class RestSteps
		{
            private readonly ScenarioContext _scenarioContext;

            public RestSteps(ScenarioContext scenarioContext)
            {
                _scenarioContext = scenarioContext;
            }

            [Given(@"I set up a basic url as '(.*)'")]
            public void GivenISetUpABasicUrlAs(string p0)
            {
                Console.WriteLine("OI BOY");
            }
	
            [When(@"I send a Get user list request")]
            public void WhenIsendaGetuserlistrequest()
            {
                Console.WriteLine("OI BOY");
            }

            [When(@"I send a Get created user request")]
            public void WhenISendAGetCreatedUserRequest()
            {
                Console.WriteLine("OI BOY");
            }

            [When(@"I send a Post create user request")]
            public void WhenIsendaPostcreateuserrequest()
            {
                Console.WriteLine("OI BOY");
            }

            
            [When(@"I send a Patch user request with body")]
            public void WhenIsendaPatchuserrequestwithbody(string docString)
            {
                Console.WriteLine("OI BOY");
            }

            [When(@"I send a Delete user request")]
            public void WhenIsendaDeleteuserrequest()
            {
                Console.WriteLine("OI BOY");
            }

            [Then(@"Response code is (.*)")]
            public void ThenResponseCodeIs(int p0)
            {
                Console.WriteLine("OI BOY");
            }

            
            [Then(@"Response contains (.*)")]
            public void ThenResponsecontainsid(string p0)
            {
                Console.WriteLine("OI BOY");
            }

            [Then(@"I save user id")]
            public void Isaveuserid()
            {
                Console.WriteLine("OI BOY");
            }

            [Then(@"Response contains correct user info")]
            public void Responsecontainscorrectuserinfo()
            {
                Console.WriteLine("OI BOY");
            }
        }
    }