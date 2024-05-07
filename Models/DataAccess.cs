using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrepesWaffelsPOS.Models
{
    public class DataAccess : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<FoodModel> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodModel>().Property(e => e.ID).ValueGeneratedOnAdd();
            var user = new FoodModel()
            {
                ID = 1,
                Name = "Burger",
                Price = 10
            };

            modelBuilder.Entity<FoodModel>()
                .HasData(user);
        }

        // Method to add a food item to the foods database
        public void AddFood(FoodModel food)
        {
            Foods.Add(food);

            try
            {
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error adding food item: {ex.Message}");
                throw;
            }
        }
        // Method to get all food items from the foods database
        public List<FoodModel> GetFoods()
        {
            try
            {
                return Foods.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting food items: {ex.Message}");
                throw;
            }
        }
    }
}
