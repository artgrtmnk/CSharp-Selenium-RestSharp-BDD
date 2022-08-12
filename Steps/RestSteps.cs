using TechTalk.SpecFlow;
using CSharp_Selenium_RestSharp_BDD.Utils;
using CSharp_Selenium_RestSharp_BDD.Utils.ApiClients;
using RestSharp;
using KellermanSoftware.CompareNetObjects;
	
	namespace CSharp_Selenium_RestSharp_BDD.Steps
	{
		[Binding]
		public class RestSteps
		{
            private readonly ScenarioContext _scenarioContext;
            private RestApiClient _restApiClient;
            private RestResponse response;

            private static UserPocoGenerator s_userPocoGenerator = new UserPocoGenerator();
            private static UserPoco userPoco = s_userPocoGenerator.GenerateUserData();

            public RestSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

            [Given(@"I set up a basic url as '(.*)'")]
            public void GivenISetUpABasicUrlAs(string url)
            {
                _restApiClient = new RestApiClient(url);
            }
	
            [When(@"I send a Get user list request")]
            public void WhenIsendaGetuserlistrequest()
            {
                response = _restApiClient.GetUserList();
            }

            [When(@"I send a Post create user request")]
            public void WhenIsendaPostcreateuserrequest()
            {
                response = _restApiClient.CreateUser(userPoco);
            }

            [When(@"I send a Get created user request")]
            public void WhenISendAGetCreatedUserRequest()
            {
                // I don't really like it, but seems like that's the only way to save it flexible... =///
                _restApiClient = new RestApiClient("https://gorest.co.in/public/v2/users/" + userPoco.Id);

                response = _restApiClient.GetCreatedUser(userPoco);
            }
            
            [When(@"I send a Patch user request with body")]
            public void WhenIsendaPatchuserrequestwithbody(string docString)
            {
                _restApiClient = new RestApiClient("https://gorest.co.in/public/v2/users/" + userPoco.Id);

                response = _restApiClient.PatchCreatedUser(docString);
            }

            [When(@"I send a Delete user request")]
            public void WhenIsendaDeleteuserrequest()
            {
                _restApiClient = new RestApiClient("https://gorest.co.in/public/v2/users/" + userPoco.Id);

                response = _restApiClient.DeleteCreatedUser();
            }

            [Then(@"Response code is (.*)")]
            public void ThenResponseCodeIs(int expectedStatusCode)
            {
                Assert.AreEqual(expectedStatusCode, (int)response.StatusCode, "Wrong status code.");
            }
            
            [Then(@"Response contains (.*)")]
            public void ThenResponsecontainsid(string expectedContains)
            {
                Assert.True(response.Content.Contains(expectedContains), "Body of the response doesn't match the expected one."); 
            }

            [Then(@"I save user id")]
            public void Isaveuserid()
            {
                userPoco.Id = _restApiClient.ParseUserFromResponse(response).Id;
            }

            [Then(@"Response body contains correct user info")]
            public void Responsebodycontainscorrectuserinfo()
            {
                UserPoco responseUser = _restApiClient.ParseUserFromResponse(response);
                CompareLogic compareLogic = new CompareLogic();

                Assert.True(compareLogic.Compare(userPoco, responseUser).AreEqual);
            }
        }
    }