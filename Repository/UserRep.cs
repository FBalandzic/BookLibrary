using BookWebApp.Database;
using BookWebApp.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Repository
{
    public class UserRep
    {
        SqliteConnection conn = Db.Instance;

        public int addUser(User user)
        {
            Guid guid = Guid.NewGuid();
            user.UserAccountID = guid.ToString();
            user.IsDeleted = 0;

            string query = "INSERT INTO UserAccount (UserAccountID,Username,Password,IsDeleted) VALUES (@id,@user,@password,@isDeleted)";

            conn.Open();
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@id", user.UserAccountID);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@isDeleted", user.IsDeleted);
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

        public User getUserById(string id)
        {
            User user = null;
            string query = "SELECT * FROM UserAccount WHERE UserAccountID = @id";

            conn.Open();
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User(reader["UserAccountID"].ToString(),
                                        reader["Username"].ToString(),
                                        reader["Password"].ToString(),
                                        int.Parse(reader["IsDeleted"].ToString())
                                        );
                    }
                }
            }
            conn.Close();
            return user;
        }

        public User login(User user)
        {
            if (user == null)
            {
                return null;
            }
            string query = "SELECT UserAccountID FROM UserAccount WHERE Username=@username AND Password = @password";
            conn.Open();
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                try
                {
                    Console.WriteLine(cmd.CommandText);
                    string userid = (string)cmd.ExecuteScalar();
                    if(userid != null)
                    {
                        Console.WriteLine(userid);
                        return getUserById(userid);
                    }
                    return null;
                }
                catch (SqliteException e)
                {
                    Console.WriteLine(e.Message.ToString(), "Error messagexD");
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            } 
        }
    }
}
