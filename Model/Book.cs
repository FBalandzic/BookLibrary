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

        public Book(string bookID, string isbn, string title, string author, string genre, int isDeleted)
        {
            this.BookID = bookID;
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.IsDeleted = isDeleted;
        }

        [Key]
        [StringLength(36)]
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
