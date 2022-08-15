namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class UserPocoGenerator
    {
        private readonly string[] genders = { "male", "female" };

        public UserPoco GenerateUserData()
        {
            return UserPoco.Builder()
                        .WithEmail(Faker.InternetFaker.Email())
                        .WithName(Faker.NameFaker.Name())
                        .WithGender(genders[new Random().Next(genders.Length)])
                        .WithStatus("active");
        }
    }
}