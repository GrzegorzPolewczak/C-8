using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium8GP.Model
{
    public class DbBiblioteka : DbContext
    {
        public DbSet<Ksiazka> Ksiazki { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Biblioteka; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False");
        }
       
    }
}
