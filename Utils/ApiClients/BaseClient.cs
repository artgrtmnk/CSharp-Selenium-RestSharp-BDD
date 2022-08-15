using RestSharp;

namespace CSharp_Selenium_RestSharp_BDD.Utils.ApiClients
{
    public abstract class BaseClient
    {
        protected static readonly string s_Token = new Deserializer().getGorestToken();
        protected RestClient _restClient;
        protected RestRequest BaseSpec = new RestRequest()
                                            .AddHeader("Authorization", "Bearer " + s_Token)
                                            .AddHeader("Content-Type", "application/json");

        public BaseClient(string url) => _restClient = new RestClient(url);
    }
}