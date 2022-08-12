using TechTalk.SpecFlow;
using CSharp_Selenium_RestSharp_BDD.Utils;
using CSharp_Selenium_RestSharp_BDD.Utils.ApiClients;
using RestSharp;
using KellermanSoftware.CompareNetObjects;
using CSharp_Selenium_RestSharp_BDD.Steps;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    [Binding]
    public class GqlSteps : BaseSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private GraphqlClient _graphqlClient;
        private RestResponse response;

        private static UserPocoGenerator s_userPocoGenerator = new UserPocoGenerator();
        private static UserPoco userPoco = s_userPocoGenerator.GenerateUserData();

        public GqlSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"GQL Given I set up a basic url as '(.*)'")]
        public void GivenGQLGivenISetUpABasicUrlAs(string url)
        {
            _graphqlClient = new GraphqlClient(url);
        }

        [When(@"I send a GQL request with body")]
        public void WhenIsendaGQLrequestwithbody(string docString)
        {
            response = _graphqlClient.SendGqlRequest(docString);
            Console.WriteLine(docString);
            Console.WriteLine(response.Content);
        }

        [Given(@"GQL I save user data")]
        public void GivenGQLIsaveuserdata()
        {
            _scenarioContext.Pending();
        }

        [Given(@"GQL Response contains correct user info")]
        public void GivenGQLResponsecontainscorrectuserinfo()
        {
            _scenarioContext.Pending();
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

        [Then(@"Response does not contains '(.*)'")]
        public void ThenResponseDoesNotContains(string expectedContains)
        {
            Assert.False(response.Content.Contains(expectedContains), "Body of the response doesn't match the expected one.");
        }
    }
}