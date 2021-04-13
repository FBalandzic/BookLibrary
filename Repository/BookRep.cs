using BookWebApp.Database;
using BookWebApp.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Repository
{
    public class BookRep
    {
        SqliteConnection conn = Db.Instance;

        //Vrati nazad addBook(Book book)
        public int addBook(Book book) 
        {
            Guid guid = Guid.NewGuid();
            book.BookID = guid.ToString();
            book.IsDeleted = 0;

            string query = "INSERT INTO Book (BookID,ISBN,Title,Author,Genre,isDeleted) VALUES (@id,@isbn,@title,@author,@genre,@isDeleted)";

            conn.Open();
            using(SqliteCommand cmd = new SqliteCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@id", book.BookID);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@genre", book.Genre);
                cmd.Parameters.AddWithValue("@isDeleted", book.IsDeleted);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("test");
                    return 1;
                }
                catch (SqliteException e)
                {
                    Console.WriteLine(e.Message.ToString(), "Error messagexD");
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Book getBookById(string id)
        {
            Book book = null;
            string query = "SELECT * FROM Book WHERE BookID = @id";

            conn.Open();
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using(var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        book = new Book(reader["BookID"].ToString(),
                                        reader["ISBN"].ToString(),
                                        reader["Title"].ToString(),
                                        reader["Author"].ToString(),
                                        reader["Genre"].ToString(),
                                        int.Parse(reader["isDeleted"].ToString())
                                        );
                    }
                }
            }
            conn.Close();
            return book;
        }

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            string query = "SELECT * FROM Book";
            var command = new SqliteCommand(query, conn);

            conn.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new Book(reader["BookID"].ToString(),
                                        reader["ISBN"].ToString(),
                                        reader["Title"].ToString(),
                                        reader["Author"].ToString(),
                                        reader["Genre"].ToString(),
                                        int.Parse(reader["isDeleted"].ToString())
                                        ));
                }
            }
            conn.Close();
            return books;
        }

        public int deleteBook(BookUpdateModel book)
        {
            conn.Open();
            string query = "Update Book set isDeleted = 1 where BookID = @id";
            var command = new SqliteCommand(query, conn);
            command.Parameters.AddWithValue("@id", book.BookID);
            try
            {
                command.ExecuteNonQuery();
                return 1;
            }
            catch(SqliteException e)
            {
                Console.WriteLine(e.Message.ToString(), "Error message");
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int updateBook(Book book)
        {
            string query = "UPDATE Book SET Title = @title , Author = @author , Genre = @genre WHERE ISBN=@isbn";
            conn.Open();
            //BookID,ISBN,Title,Author,Genre
            using (var command = new SqliteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@genre", book.Genre);
                command.Parameters.AddWithValue("@isbn", book.ISBN);
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine(command.CommandText);
                    return 1;
                }
                catch (SqliteException e)
                {
                    Console.WriteLine(e.Message.ToString(), "Error message");
                    return 0;
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}
