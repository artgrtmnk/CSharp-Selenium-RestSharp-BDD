using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils.DeserializedObjects
{
    public class GetUserPoco
    {
        public class Data
        {
            [JsonProperty("user")]
            public UserPoco userPoco { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
        }
    }
}