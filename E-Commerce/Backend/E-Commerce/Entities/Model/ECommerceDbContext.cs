using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext( DbContextOptions options ) : base( options ) {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductImage> ProductsImages { get; set; } = null!;
        public DbSet<ProductSale> ProductsSales { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserType> UsersTypes { get; set; } = null!;

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            base.OnModelCreating( modelBuilder );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
