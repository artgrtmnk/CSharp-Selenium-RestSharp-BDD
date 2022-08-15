using RestSharp;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    public class GraphqlClient : BaseClient
    {
        public GraphqlClient(string url) : base(url) {}

        public RestResponse SendGqlRequest(string query, UserPoco userPoco) 
        {
            DefaultDataValidator defaultDataValidator = new DefaultDataValidator();
            query = query.Replace("\n", "").Replace("\r", "");
            query = defaultDataValidator.CheckForDefaultData(query, userPoco);

            return _restClient.ExecutePost(BaseSpec.AddBody(query));
        }

        public UserPoco ParseUserFromResponse(RestResponse restResponse)
        {
            return new Deserializer().DeserializeGQLResponse(restResponse);
        }
    }
}