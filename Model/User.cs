using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Model
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(16)]
        public string UserAccountID { get; set; }

        [StringLength(45)]
        public String Username { get; set; }

        [StringLength(45)]
        public String Password { get; set; }

        public int IsDeleted { get; set; }
    }
}
