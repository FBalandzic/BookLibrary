using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Model
{
    public class Book
    {
        public Book()
        {
        }

        public Book(string v1, string v2, string v3, string v4, string v5, int v6)
        {
            this.BookID = v1;
            this.ISBN = v2;
            this.Title = v3;
            this.Author = v4;
            this.Genre = v5;
            this.IsDeleted = v6;
        }

        [Key]
        [Required]
        [StringLength(16)]
        public string BookID { get; set; }

        [Required]
        [StringLength(13)]
        public String ISBN { get; set; }

        [Required]  
        public String Title { get; set; }

        [Required]
        public String Author { get; set; }

        [Required]
        public String Genre { get; set; }

        public int IsDeleted { get; set; }
    }
}
