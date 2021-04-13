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

        public User(string v1, string v2, string v3, int v4)
        {
            this.UserAccountID = v1;
            this.Username = v2;
            this.Password = v3;
            this.IsDeleted = v4;
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
