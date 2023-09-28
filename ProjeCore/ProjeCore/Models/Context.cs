using Microsoft.EntityFrameworkCore;

namespace ProjeCore.Models
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LEGEN\\MSSQLSERVER01;database=BirimDb;integrated security= true; Trust Server Certificate=true;");
        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
