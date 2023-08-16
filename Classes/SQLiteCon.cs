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

        //static string filename = "C:\\Users\\DRAGOS-ANDREIPOPESCU\\Desktop\\calorii\\alimente.db";
        ////static string filename = "alimente.db";
        static SQLiteConnection conn = new SQLiteConnection(DatabasePath);

        public static int Insert(Alimente aliment)
        {
            int result = int.MinValue;
                try
                {
                    result = conn.Insert(aliment);
                }
                catch
                {
                }

            return result;
        }


        public static List<Alimente> GetData()
        {
            List<Alimente> alimentes = conn.Table<Alimente>().ToList();
            return alimentes;
        }


        public static int Update(Alimente aliment)
        {
            int result = int.MinValue;
            try
            {
                result = conn.Update(aliment);
            }
            catch
            { }
            return result;
        }


        public static int Delete(int alimentID)
        {
            int result = 0;
            result = conn.Delete<Alimente>(alimentID);
            return result;
        }

        public static void conexiune()
        {
            try
            {
                conn.CreateTable<Alimente>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
