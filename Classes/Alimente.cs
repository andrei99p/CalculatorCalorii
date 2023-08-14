using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
