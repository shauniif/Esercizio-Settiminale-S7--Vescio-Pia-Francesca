using Microsoft.EntityFrameworkCore;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Order> Orders { get; set; } 
        
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Products)
                .UsingEntity(j => j.ToTable("IngredientsProduct"));

            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(i => i.Users)
                .UsingEntity(j => j.ToTable("RoleUsers"));

        }
    }
}
