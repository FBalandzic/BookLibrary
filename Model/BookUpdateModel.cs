using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Model
{
    public class BookUpdateModel
    {

        public BookUpdateModel()
        {
        }

        public BookUpdateModel(string bookID, string isbn, string title, string author, string genre, int isDeleted)
        {
            this.BookID = bookID;
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.IsDeleted = isDeleted;
        }

        [Required]
        [Key]
        [StringLength(36)]
        public string BookID { get; set; }

       
        [StringLength(13)]
        public String ISBN { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }

        public String Genre { get; set; }

        public int IsDeleted { get; set; }
    }
}
