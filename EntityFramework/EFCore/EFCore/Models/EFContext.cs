using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class EFContext : DbContext
    {
        private string connectionString = "Server=localhost;Database=EFCore;Trusted_Connection=True;";

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
            optionsBuilder.UseSqlServer( connectionString );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            base.OnModelCreating( modelBuilder );

            modelBuilder.ApplyConfigurationsFromAssembly( Assembly.GetExecutingAssembly() );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
