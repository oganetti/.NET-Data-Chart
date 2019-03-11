using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace OplogDataChartBackend.Entities
{
    public class User : IdentityUser
    {

        internal HashSet<MenuBarUser> _menubaruser = new HashSet<MenuBarUser>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Usernames { get; set; }

        public IReadOnlyCollection<MenuBarUser> MenuBarUser { get => _menubaruser.ToList(); }



        public User(string firstName, string lastName, string email,string userName)
        {
            base.Email = email;
            base.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }


}