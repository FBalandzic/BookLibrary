using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Database
{
    public class Db
    {
        private static SqliteConnection instance = null;

        public static string filepath = Directory.GetCurrentDirectory();

        private static string conns = "Data Source=" + filepath + @"\Database\booksDB.db";

        public static SqliteConnection Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SqliteConnection(conns);
                }
                return instance;
            }
        }
    }
}
