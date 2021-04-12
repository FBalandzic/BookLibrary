using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Model
{
    public class Book
    {

        [Key]
        [Required]
        [StringLength(16)]
        public string BookID { get; set; }

        [StringLength(13)]
        public String ISBN { get; set; }

        [StringLength(256)]
        public String Title { get; set; }

        [StringLength(256)]
        public String Author { get; set; }

        [StringLength(256)]
        public String Genre { get; set; }

        public int IsDeleted { get; set; }
    }
}
