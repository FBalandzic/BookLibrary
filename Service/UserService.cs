using BookWebApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Service
{
    public class UserService
    {
        public void Add(User user)
        {
            using (var context = new DBContext())
            {
                var entity = context.Add(user);
                entity.State = EntityState.Added;

                context.SaveChanges();
            }
        }
        public static void Update(User user)
        {
            using (var context = new DBContext())
            {
                var entity = context.Users.Update(user);
                entity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Delete(User user)
        {
            using (var context = new DBContext())
            {
                var entity = context.Users.Remove(user);
                entity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (var context = new DBContext())
            {
                if (context.Users.Any())
                {
                    var data = context.Users.ToList();
                    foreach (var user in data)
                    {
                        Console.WriteLine($"User Account ID:{user.UserAccountID}; Username:{user.Username}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no users in UserAccount Table");
                }
            }
        }

        public static User GetById(int userID)
        {
            using (var context = new DBContext())
            {
                var user = context.Users.Find(userID);
                Console.WriteLine($"User Account ID:{user.UserAccountID}; Username:{user.Username}");
                return user;
            }
        }
    }
}
