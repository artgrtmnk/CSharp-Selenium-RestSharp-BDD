using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class DeleteUserPoco
    {
        public class DeleteUser
        {
            [JsonProperty("user")]
            public UserPoco userPoco { get; set; }
        }

        public class Data
        {
            public DeleteUser deleteUser { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
        }
    }
}