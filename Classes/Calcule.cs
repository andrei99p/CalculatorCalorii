using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCalorii.Classes
{
    [Table("Calcule")]
    public class Calcule
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Calcul { get; set; }

        public static List<Calcule> GetData()
        {
            List<Calcule> Calcules = SQLiteCon.conn.Table<Calcule>().ToList();
            //TODO: Sort descending
            return Calcules;
        }

        public static int Insert(Calcule calcul)
        {
            int result = int.MinValue;
            try
            {
                result = SQLiteCon.conn.Insert(calcul);
            }
            catch
            {}
            return result;
        }

        public static int Update(Calcule calcul)
        {
            int result = int.MinValue;
            try
            {
                result = SQLiteCon.conn.Update(calcul);
            }
            catch
            { }
            return result;
        }

        public static int Delete(int calculID)
        {
            int result = 0;
            result = SQLiteCon.conn.Delete<Calcule>(calculID);
            return result;
        }
    }
}
