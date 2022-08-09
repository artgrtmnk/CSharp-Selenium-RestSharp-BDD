namespace CSharp_Selenium_RestSharp_BDD.Utils
{
    public class UserPojo
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private string Gender { get; set; }
        private string Status { get; set; }
        private int Id { get; set; }


        #region Builder
        public static UserPojo Builder()
        {
            return new UserPojo();
        }

        public UserPojo WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public UserPojo WithEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public UserPojo WithGender(string gender)
        {
            this.Gender = gender;
            return this;
        }

        public UserPojo WithStatus(string status)
        {
            this.Status = status;
            return this;
        }

        public UserPojo WithId(int id)
        {
            this.Id = id;
            return this;
        }


        public UserPojo Build()
        {
            return this;
        }
        #endregion
    }
}