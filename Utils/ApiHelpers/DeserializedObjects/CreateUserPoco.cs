using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class CreateUserPoco
    {
        public class CreateUser
        {
            [JsonProperty("user")]
            public UserPoco userPoco { get; set; }
        }

        public class Data
        {
            public CreateUser createUser { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
        }
    }
}