﻿using BookWebApp.Database;
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
        public int addBook() 
        {
            Book book = new Book();
            Guid guid = Guid.NewGuid();
            string bookId = guid.ToString();

            book.BookID = bookId;
            book.ISBN = "9781234567897";
            book.Title = "The Lord of the Rings";
            book.Author = "J. R. R. Tolkien";
            book.Genre = "Fantasy";
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
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                try
                {
                    cmd.ExecuteNonQuery();
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

        public int deleteBook(Book book)
        {
            conn.Open();
            string query = "Update Book set isDeleted = 0 where BookID = @id";
            var command = conn.CreateCommand();
            command.CommandText = query;
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
            conn.Open();
            string query = "Update Book SET BookID = @id AND ISBN = @isbn AND Title = @title AND Author = @author AND Genre = @genre AND isDeleted = @isdel";
            //BookID,ISBN,Title,Author,Genre,isDeleted
            var command = conn.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", book.BookID);
            command.Parameters.AddWithValue("@isbn", book.ISBN);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@genre", book.Genre);
            command.Parameters.AddWithValue("@isdel", book.IsDeleted);
            try
            {
                command.ExecuteNonQuery();
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