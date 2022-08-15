using RestSharp;
using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    public class RestApiClient :BaseClient
    {
        public RestApiClient(string url) : base(url) {}

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