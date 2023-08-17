using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCalorii.Classes
{
    internal class SQLiteCon
    {
        public const string DatabaseFilename = "alimente.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static SQLiteConnection conn = new SQLiteConnection(DatabasePath);

        public static void conexiune()
        {
            try
            {
                conn.CreateTable<Alimente>();
                conn.CreateTable<Calcule>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
