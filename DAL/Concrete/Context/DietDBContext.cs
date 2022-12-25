using DAL.Concrete.Context.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context
{
    public class DietDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration())
                        .ApplyConfiguration(new MealConfiguration())
                        .ApplyConfiguration(new CategoryConfiguration())
                        .ApplyConfiguration(new FoodConfiguration())
                        .ApplyConfiguration(new MealFoodConfiguration());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = YAVUZ-PC\SQLSERVER2019; Database = DietDatabase; Trusted_Connection = True;");
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
