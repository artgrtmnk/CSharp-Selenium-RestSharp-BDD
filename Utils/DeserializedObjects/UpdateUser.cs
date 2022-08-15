using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class UpdateUserPoco
    {
        public class UpdateUser
        {
            [JsonProperty("user")]
            public UserPoco userPoco { get; set; }
        }

        public class Data
        {
            public UpdateUser updateUser { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
        }
    }
}