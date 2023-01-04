﻿using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context.Configurations
{
    public class FoodConfiguration : BaseConfiguration<Food>
    {
        public override void Configure(EntityTypeBuilder<Food> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FoodName)
                    .IsRequired()
                    .HasMaxLength(80);

            builder.HasIndex(x => x.FoodName)
                    .IsUnique();

            builder.Property(x => x.Description)
                    .IsRequired(false)
                    .HasMaxLength(200);

            builder.Property(x => x.Calorie)
                    .IsRequired()
                    .HasPrecision(2); 

            builder.HasOne(x => x.Category)
                    .WithMany(x => x.Foods)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MealFoods)
                    .WithOne(x => x.Food)
                    .HasForeignKey(x => x.FoodId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(

                    new Food { ID = 1, FoodName = "Süt", Description = "1 su bardağı, 200ml", Calorie = 11400, CategoryId = 1, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 2, FoodName = "Kıyma", Description = "1 köfte, 30gr", Calorie = 69000, CategoryId = 2, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 3, FoodName = "Mercimek", Description = "4 yemek kaşığı, 25gr", Calorie = 80000, CategoryId = 3, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 4, FoodName = "Makarna", Description = "3 yemek kaşığı, 50gr", Calorie = 68000, CategoryId = 4, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 5, FoodName = "Brokoli(pişmiş)", Description = "4 yemek kaşığı, 200gr", Calorie = 25000, CategoryId = 5, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 6, FoodName = "Elma", Description = "1 küçük boy, 120gr", Calorie = 60000, CategoryId = 6, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 7, FoodName = "Tereyağ", Description = "1 tatlı kaşığı, 5gr", Calorie = 45000, CategoryId = 7, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 8, FoodName = "Bal", Description = "1 yemek kaşığı, 30gr", Calorie = 68000, CategoryId = 8, IsActive = true, CreateOn = DateTime.Now },
                    new Food { ID = 9, FoodName = "Ceviz içi", Description = "2 adet, 8gr", Calorie = 45000, CategoryId = 9, IsActive = true, CreateOn = DateTime.Now }
                );
        }
    }
}
