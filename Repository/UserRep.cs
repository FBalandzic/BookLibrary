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
            string userId = guid.ToString();

            user.UserAccountID = userId;

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

        public List<User> getAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM UserAccount";
            var command = new SqliteCommand(query, conn);

            conn.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User(reader["UserAccountID"].ToString(),
                                        reader["Username"].ToString(),
                                        reader["Password"].ToString(),
                                        int.Parse(reader["IsDeleted"].ToString())
                                        ));
                }
            }
            conn.Close();
            return users;
        }

        public int deleteUser(User user)
        {
            conn.Open();
            string query = "Update UserAccount set IsDeleted = 0 where UserAccountID = @id";
            var command = conn.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", user.UserAccountID);
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
