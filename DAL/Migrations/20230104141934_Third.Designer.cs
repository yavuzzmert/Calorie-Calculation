﻿// <auto-generated />
using System;
using DAL.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DietDBContext))]
    [Migration("20230104141934_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateOn")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryName = "Süt Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(192),
                            IsActive = true
                        },
                        new
                        {
                            ID = 2,
                            CategoryName = "Et Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(195),
                            IsActive = true
                        },
                        new
                        {
                            ID = 3,
                            CategoryName = "KuruBaklagil Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(196),
                            IsActive = true
                        },
                        new
                        {
                            ID = 4,
                            CategoryName = "Ekmek Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(197),
                            IsActive = true
                        },
                        new
                        {
                            ID = 5,
                            CategoryName = "Sebze Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(198),
                            IsActive = true
                        },
                        new
                        {
                            ID = 6,
                            CategoryName = "Meyve Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(199),
                            IsActive = true
                        },
                        new
                        {
                            ID = 7,
                            CategoryName = "Yağ Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(200),
                            IsActive = true
                        },
                        new
                        {
                            ID = 8,
                            CategoryName = "Tatlı Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(200),
                            IsActive = true
                        },
                        new
                        {
                            ID = 9,
                            CategoryName = "Kuruyemiş Grubu",
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(201),
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Entities.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("Calorie")
                        .HasPrecision(2)
                        .HasColumnType("float(2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateOn")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FoodName")
                        .IsUnique();

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Calorie = 11400.0,
                            CategoryId = 1,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2509),
                            Description = "1 su bardağı, 200ml",
                            FoodName = "Süt",
                            IsActive = true
                        },
                        new
                        {
                            ID = 2,
                            Calorie = 69000.0,
                            CategoryId = 2,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2513),
                            Description = "1 köfte, 30gr",
                            FoodName = "Kıyma",
                            IsActive = true
                        },
                        new
                        {
                            ID = 3,
                            Calorie = 80000.0,
                            CategoryId = 3,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2514),
                            Description = "4 yemek kaşığı, 25gr",
                            FoodName = "Mercimek",
                            IsActive = true
                        },
                        new
                        {
                            ID = 4,
                            Calorie = 68000.0,
                            CategoryId = 4,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2515),
                            Description = "3 yemek kaşığı, 50gr",
                            FoodName = "Makarna",
                            IsActive = true
                        },
                        new
                        {
                            ID = 5,
                            Calorie = 25000.0,
                            CategoryId = 5,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2516),
                            Description = "4 yemek kaşığı, 200gr",
                            FoodName = "Brokoli(pişmiş)",
                            IsActive = true
                        },
                        new
                        {
                            ID = 6,
                            Calorie = 60000.0,
                            CategoryId = 6,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2517),
                            Description = "1 küçük boy, 120gr",
                            FoodName = "Elma",
                            IsActive = true
                        },
                        new
                        {
                            ID = 7,
                            Calorie = 45000.0,
                            CategoryId = 7,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2518),
                            Description = "1 tatlı kaşığı, 5gr",
                            FoodName = "Tereyağ",
                            IsActive = true
                        },
                        new
                        {
                            ID = 8,
                            Calorie = 68000.0,
                            CategoryId = 8,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2519),
                            Description = "1 yemek kaşığı, 30gr",
                            FoodName = "Bal",
                            IsActive = true
                        },
                        new
                        {
                            ID = 9,
                            Calorie = 45000.0,
                            CategoryId = 9,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2519),
                            Description = "2 adet, 8gr",
                            FoodName = "Ceviz içi",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Entities.Meal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateOn")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("MealName")
                        .IsUnique();

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8147),
                            IsActive = true,
                            MealName = "Kahvaltı"
                        },
                        new
                        {
                            ID = 2,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8151),
                            IsActive = true,
                            MealName = "Öğle Yemeği"
                        },
                        new
                        {
                            ID = 3,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8152),
                            IsActive = true,
                            MealName = "Akşam Yemeği"
                        });
                });

            modelBuilder.Entity("Entities.MealFood", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<double>("Portion")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateOn")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodId");

                    b.HasIndex("MealId");

                    b.HasIndex("UserId");

                    b.ToTable("MealFoods");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateOn")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateOn = new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(6138),
                            Email = "admin@gmail.com",
                            IsActive = true,
                            Password = "123456",
                            UserName = "Admin",
                            UserTypes = "Admin"
                        });
                });

            modelBuilder.Entity("Entities.Food", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.MealFood", b =>
                {
                    b.HasOne("Entities.Food", "Food")
                        .WithMany("MealFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Meal", "Meal")
                        .WithMany("MealFoods")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.User", "User")
                        .WithMany("MealFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Meal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Entities.Food", b =>
                {
                    b.Navigation("MealFoods");
                });

            modelBuilder.Entity("Entities.Meal", b =>
                {
                    b.Navigation("MealFoods");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("MealFoods");
                });
#pragma warning restore 612, 618
        }
    }
}