namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class DefaultDataValidator
    {
        private readonly string DefaultEmail = "default_email@gmail.com";
        private readonly string DefaultName = "Default User";
        private readonly string DefaultId = "99999";

        public string CheckForDefaultData(string query, UserPoco userPoco)
        {
            if(query.Contains(DefaultEmail) || query.Contains(DefaultName))
            {
                query = query.Replace(DefaultEmail, userPoco.Email)
                            .Replace(DefaultName, userPoco.Name);
                if (query.Contains("female")) query = query.Replace("female", userPoco.Gender);

            }
            else if (query.Contains(DefaultId))
            {
                query = query.Replace(DefaultId, userPoco.Id.ToString());
            }
            return query;
        }
    }
}