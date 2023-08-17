using SQLite;

namespace CalculatorCalorii.Classes
{
    [SQLite.Table("Alimente")]
    public class Alimente
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement, SQLite.Column("_id")]
        public int ID {  get; set; }
        [SQLite.MaxLength(50), Unique]
        public string Name { get; set; }
        public int Calorii { get; set; }


        public static List<Alimente> GetData()
        {
            List<Alimente> alimentes = SQLiteCon.conn.Table<Alimente>().ToList();
            return alimentes;
        }

        public static int Insert(Alimente aliment)
        {
            int result = int.MinValue;
            try
            {
                result = SQLiteCon.conn.Insert(aliment);
            }
            catch
            {
            }

            return result;
        }

        public static int Update(Alimente aliment)
        {
            int result = int.MinValue;
            try
            {
                result = SQLiteCon.conn.Update(aliment);
            }
            catch
            { }
            return result;
        }

        public static int Delete(int alimentID)
        {
            int result = 0;
            result = SQLiteCon.conn.Delete<Alimente>(alimentID);
            return result;
        }
    }
}
