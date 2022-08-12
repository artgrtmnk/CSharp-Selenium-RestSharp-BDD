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

        public RestResponse SendGqlRequest(string query, UserPoco userPoco) 
        {
            DefaultDataValidator defaultDataValidator = new DefaultDataValidator();
            query = query.Replace("\n", "").Replace("\r", "");
            query = defaultDataValidator.CheckForDefaultData(query, userPoco);

            return _restClient.ExecutePost(BaseSpec.AddBody(query));
        }

        public void ParseUserFromResponse(RestResponse restResponse, UserPoco userPoco)
        {
            var jjj = JsonConvert.DeserializeObject(restResponse.Content);
            Console.WriteLine(jjj.ToString());
            //return jjj.data.createUser.user;
        }
    }
}