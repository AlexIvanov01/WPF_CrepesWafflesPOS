using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
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
            var food1 = new FoodModel()
            {
                ID = 1,
                Name = "Burger",
                Price = 10,
                Category = FoodCategory.Burger
            };
            var food2 = new FoodModel()
            {
                ID = 2,
                Name = "Nutella and strawberry waffle",
                Price = 7,
                Category = FoodCategory.Waffle
            };
            var food3 = new FoodModel()
            {
                ID = 3,
                Name = "Crepe Hat \"Vueltiao\"",
                Price = 15,
                Category = FoodCategory.Crepe
            };
            var food4 = new FoodModel()
            {
                ID = 4,
                Name = "Mexican Soup with Chicken",
                Price = 9,
                Category = FoodCategory.Soup
            };
            var food5 = new FoodModel()
            {
                ID = 5,
                Name = "Sicilian Pita",
                Price = 11,
                Category = FoodCategory.Pizza
            };

            modelBuilder.Entity<FoodModel>()
                .HasData(food1);
            modelBuilder.Entity<FoodModel>()
                .HasData(food2);
            modelBuilder.Entity<FoodModel>()
                .HasData(food3);
            modelBuilder.Entity<FoodModel>()
                .HasData(food4);
            modelBuilder.Entity<FoodModel>()
                .HasData(food5);

            var user = new UserModel()
            {
                Username = "Admin",
                Password = "password",
                Balance = 100
            };

            modelBuilder.Entity<UserModel>()
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

        public void AddUser(UserModel user)
        {
            Users.Add(user);

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

        public List<UserModel> GetUsers()
        {
            try
            {
                return Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting food items: {ex.Message}");
                throw;
            }
        }

        public void UpdateUserBalance(string username, double newBalance)
        {
            using (var transaction = Database.BeginTransaction())
            {
                try
                {
                    var user = Users.SingleOrDefault(u => u.Username == username);
                    if (user != null)
                    {
                        user.Balance = newBalance;
                        SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
