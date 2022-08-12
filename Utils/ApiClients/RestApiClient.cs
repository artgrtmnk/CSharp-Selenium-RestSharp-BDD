using RestSharp;
using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    public class RestApiClient
    {
        private static readonly string s_Token = "594add4a6e80e6bfeb2b345424060aad3bba0d538628eeff491d774957ee834a";
        private RestClient _restClient;

        public RestApiClient(string url) => _restClient = new RestClient(url);
        private RestRequest BaseSpec = new RestRequest()
                                            .AddHeader("Authorization", "Bearer " + s_Token)
                                            .AddHeader("Content-Type", "application/json");

        public RestResponse GetUserList() 
        {
            return _restClient.ExecuteGet(BaseSpec);
        }

        public RestResponse CreateUser(UserPoco userPoco) 
        {
            string UserPocoJson = JsonConvert.SerializeObject(userPoco);
            return _restClient.ExecutePost(BaseSpec.AddBody(UserPocoJson));
        }

        public RestResponse GetCreatedUser(UserPoco userPoco)
        {
            return _restClient.ExecuteGet(BaseSpec);
        }

        public RestResponse PatchCreatedUser(string docString)
        {
            Console.WriteLine(docString);
            return _restClient.Execute(BaseSpec.AddBody(docString), Method.Patch);
        }

        public RestResponse DeleteCreatedUser()
        {
            return _restClient.Execute(BaseSpec, Method.Delete);
        }

        public UserPoco ParseUserFromResponse(RestResponse restResponse)
        {
            return JsonConvert.DeserializeObject<UserPoco>(restResponse.Content);
        }
    }
}