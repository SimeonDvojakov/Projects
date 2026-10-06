using Bogus;
using Burger_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Burger_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Category> Categories => Set<Category>();
        public DbSet<MenuItem> Burgers => Set<MenuItem>();
        public Faker faker = new Faker();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .Property(b => b.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MenuItem>()
                .Property(b => b.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Burgers" },
                new Category { Id = 2, Name = "Chicken" },
                new Category { Id = 3, Name = "Sides" },
                new Category { Id = 4, Name = "Drinks" }
                );

            modelBuilder.Entity<MenuItem>().HasData(
                 new MenuItem { Id = 1, Name = "Classic stack", Description = "Beef, cheddar, pickles", Price = 8.99m, CategoryId = 1 },
                 new MenuItem { Id = 2, Name = "Double smash", Description = "Two patties, double cheese", Price = 11.49m, CategoryId = 1 },
                 new MenuItem { Id = 3, Name = "Crispy chicken", Description = "Buttermilk fried, slaw, mayo", Price = 9.99m, CategoryId = 2 },
                 new MenuItem { Id = 4, Name = "Loaded fries", Description = "Cheese sauce, jalapeños", Price = 5.49m, CategoryId = 3 },
                 new MenuItem { Id = 5, Name = "Vanilla shake", Description = "Thick, hand-spun", Price = 4.99m, CategoryId = 4 });
        }
    }
}
