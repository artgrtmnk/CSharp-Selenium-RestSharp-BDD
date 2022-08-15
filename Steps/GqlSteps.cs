using TechTalk.SpecFlow;
using KellermanSoftware.CompareNetObjects;
using RestSharp;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    [Binding]
    public class GqlSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private GraphqlClient _graphqlClient;
        private RestResponse response;

        private static UserPocoGenerator s_userPocoGenerator = new UserPocoGenerator();
        private static UserPoco userPoco = s_userPocoGenerator.GenerateUserData();

        public GqlSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"GQL I set up a basic url as '(.*)'")]
        public void GivenGQLISetUpABasicUrlAs(string url)
        {
            _graphqlClient = new GraphqlClient(url);
        }

        [When(@"I send a GQL request with body")]
        public void WhenIsendaGQLrequestwithbody(string docString)
        {
            response = _graphqlClient.SendGqlRequest(docString, userPoco);
        }

        [Then(@"GQL Response code is (.*)")]
        public void ThenGQLResponseCodeIs(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode, "Wrong status code.");
        }

        [Then(@"GQL Response contains '(.*)'")]
        public void ThenGQLResponsecontainsid(string expectedContains)
        {
            Assert.True(response.Content.Contains(expectedContains), "Body of the response doesn't match the expected one.");
        }

        [Then(@"GQL Response does not contains '(.*)'")]
        public void ThenGQLResponseDoesNotContains(string expectedContains)
        {
            Assert.False(response.Content.Contains(expectedContains), "Body of the response doesn't match the expected one.");
        }

        [Then(@"GQL I save user id")]
        public void ThenGQLIsaveuserid()
        {
            userPoco.Id = _graphqlClient.ParseUserFromResponse(response).Id;
        }

        [Then(@"GQL Response contains correct user info")]
        public void ThenGQLResponsecontainscorrectuserinfo()
        {
            UserPoco responseUser = _graphqlClient.ParseUserFromResponse(response);
            CompareLogic compareLogic = new CompareLogic();

            Assert.True(compareLogic.Compare(userPoco, responseUser).AreEqual);
        }
    }
}