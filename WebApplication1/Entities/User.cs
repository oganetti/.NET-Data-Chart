using Microsoft.AspNetCore.Identity;

namespace OplogDataChartBackend.Entities
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Usernames { get; set; }


        public User(string firstName, string lastName, string email,string userName)
        {
            base.Email = email;
            base.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }


}