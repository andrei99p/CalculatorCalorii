using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CalculatorCalorii.Classes
{
    public class DbContextClass : DbContext
    {
        public DbSet<Alimente> YourEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "YourDatabase.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}"); // Correct usage of UseSqlite

            base.OnConfiguring(optionsBuilder);
        }
    }
}
