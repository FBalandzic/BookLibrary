using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Model
{
    public class User
    {
        public User()
        {
        }

        public User(string userAccountID, string username, string password, int isDeleted)
        {
            this.UserAccountID = userAccountID;
            this.Username = username;
            this.Password = password;
            this.IsDeleted = isDeleted;
        }

        [Key]
        [StringLength(36)]
        public string UserAccountID { get; set; }

        [Required]
        [StringLength(45)]
        public String Username { get; set; }

        [Required]
        [StringLength(45)]
        public String Password { get; set; }

        public int IsDeleted { get; set; }
    }
}
