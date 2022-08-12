using RestSharp;
using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    public class GraphqlClient
    {
        private static readonly string s_Token = "594add4a6e80e6bfeb2b345424060aad3bba0d538628eeff491d774957ee834a";
        private RestClient _restClient;

        public GraphqlClient(string url) => _restClient = new RestClient(url);
        private RestRequest BaseSpec = new RestRequest()
                                            .AddHeader("Authorization", "Bearer " + s_Token)
                                            .AddHeader("Content-Type", "application/json");

        public RestResponse SendGqlRequest(string query) 
        {
            return _restClient.ExecuteGet(BaseSpec.AddBody(query));
        }
    }
}