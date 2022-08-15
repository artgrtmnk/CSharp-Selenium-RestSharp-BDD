using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class UserPoco
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }
        [JsonProperty("gender", Required = Required.Always)]
        public string Gender { get; set; }
        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }
        [JsonProperty("id", Required = Required.Default)]
        public int Id { get; set; }

        #region Builder
        public static UserPoco Builder()
        {
            return new UserPoco();
        }

        public UserPoco WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public UserPoco WithEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public UserPoco WithGender(string gender)
        {
            this.Gender = gender;
            return this;
        }

        public UserPoco WithStatus(string status)
        {
            this.Status = status;
            return this;
        }

        public UserPoco WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public UserPoco Build()
        {
            return this;
        }
        #endregion
    }
}