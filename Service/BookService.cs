using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWebApp.Model;

namespace BookWebApp
{
    public static class BookService
    {
        public static void Add(Book book)
        {
            using(var context = new DBContext())
            {
                var entity = context.Books.Add(book);
                entity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public static void Update(Book book)
        {
            using(var context = new DBContext())
            {
                var entity = context.Books.Update(book);
                entity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Delete(Book book)
        {
            using (var context = new DBContext())
            {
                var entity = context.Books.Remove(book);
                entity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (var context = new DBContext())
            {
                if (context.Books.Any())
                {
                    var data = context.Books.ToList();
                    foreach(var book in data)
                    {
                        Console.WriteLine($"Book ID:{book.BookID}; Book Title:{book.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no books in Book Table");
                }
            }
        }

        public static Book GetById(int bookId)
        {
            using(var context = new DBContext())
            {
                var book = context.Books.Find(bookId);
                Console.WriteLine($"Product ID:{book.BookID}; Book Title:{book.Title}");
                return book;
            }
        }
    }
}
