using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CSharp_Selenium_RestSharp_BDD.Utils.DeserializedObjects;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class Deserializer
    {
        public UserPoco DeserializeGQLResponse(RestResponse restResponse)
        {
            try
            {
                return JsonConvert.DeserializeObject<CreateUserPoco.Root>(restResponse.Content).data.createUser.userPoco;
            }
            catch (System.Exception){};

            try
            {
                return JsonConvert.DeserializeObject<GetUserPoco.Root>(restResponse.Content).data.userPoco;
            }
            catch (System.Exception){};

            try
            {
                return JsonConvert.DeserializeObject<UpdateUserPoco.Root>(restResponse.Content).data.updateUser.userPoco;
            }
            catch (System.Exception){};

            try
            {
                return JsonConvert.DeserializeObject<DeleteUserPoco.Root>(restResponse.Content).data.deleteUser.userPoco;
            }
            catch (System.Exception){};

            return null;
        }

        public string getGorestToken()
        {
            string token;

            try
            {
                JObject o1 = JObject.Parse(File.ReadAllText(@"../../../token.json"));
                token = o1.GetValue("token").ToString();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Check your token value in token.json in the project's root folder!");
                throw;
            }

            return token;
        }
    }
}