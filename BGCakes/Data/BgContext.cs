using Microsoft.EntityFrameworkCore;
using BGCakes.Models;

namespace BGCakes.Data
{
    public class BgContext : DbContext  
    {
        public BgContext( DbContextOptions<BgContext> options) : base(options) 
        { 
        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CakeIngredient>().HasKey(ca => new
            {
                ca.CakeId,
                ca.IngredientId
            });
            modelBuilder.Entity<CakeIngredient>().HasOne(c => c.Cake).WithMany(ca => ca.CakeIngredients)
                .HasForeignKey(c => c.CakeId);
            modelBuilder.Entity<CakeIngredient>().HasOne(i => i.Ingredient).WithMany(ca => ca.CakeIngredients)
                .HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Cake>().HasData(
                new Cake
                {
                    Id = 1,
                    Name = "Chocolate",
                    Price = 670,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHC-0lnHat0m6-MP2d-7xxN5J_5fiNqFM1vjFxta_KMg&s"
                });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Flour" },
                new Ingredient { Id = 2, Name = "Pure Chocolate" },
                new Ingredient { Id = 3, Name = "Flavors" }
                );
            modelBuilder.Entity<CakeIngredient>().HasData(
                new CakeIngredient { CakeId = 1, IngredientId = 1 },
                new CakeIngredient { CakeId = 1, IngredientId = 2 },
                new CakeIngredient { CakeId = 1, IngredientId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CakeIngredient> CakeIngredients { get; set; }
    }
}
