using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Models
{
    public class TestDBContext : DbContext
    {

        private const string connectionString = "Server=localhost;Database=TestEF;Trusted_Connection=True;";

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {

            optionsBuilder.UseSqlServer( connectionString );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
    

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoUsuario> CursosUsuarios { get; set; }
        public DbSet<Pais>? Pais { get; set; }
    }
}
