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
    [Migration("20221224144656_Initial")]
    partial class Initial
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
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2784),
                            IsActive = true
                        },
                        new
                        {
                            ID = 2,
                            CategoryName = "Et Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2788),
                            IsActive = true
                        },
                        new
                        {
                            ID = 3,
                            CategoryName = "KuruBaklagil Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2789),
                            IsActive = true
                        },
                        new
                        {
                            ID = 4,
                            CategoryName = "Ekmek Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2790),
                            IsActive = true
                        },
                        new
                        {
                            ID = 5,
                            CategoryName = "Sebze Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2791),
                            IsActive = true
                        },
                        new
                        {
                            ID = 6,
                            CategoryName = "Meyve Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2791),
                            IsActive = true
                        },
                        new
                        {
                            ID = 7,
                            CategoryName = "Yağ Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2792),
                            IsActive = true
                        },
                        new
                        {
                            ID = 8,
                            CategoryName = "Tatlı Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2793),
                            IsActive = true
                        },
                        new
                        {
                            ID = 9,
                            CategoryName = "Kuruyemiş Grubu",
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(2794),
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
                        .IsRequired()
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
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5263),
                            Description = "1 su bardağı, 200ml",
                            FoodName = "Süt",
                            IsActive = true
                        },
                        new
                        {
                            ID = 2,
                            Calorie = 69000.0,
                            CategoryId = 2,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5267),
                            Description = "1 köfte, 30gr",
                            FoodName = "Kıyma",
                            IsActive = true
                        },
                        new
                        {
                            ID = 3,
                            Calorie = 80000.0,
                            CategoryId = 3,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5268),
                            Description = "4 yemek kaşığı, 25gr",
                            FoodName = "Mercimek",
                            IsActive = true
                        },
                        new
                        {
                            ID = 4,
                            Calorie = 68000.0,
                            CategoryId = 4,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5269),
                            Description = "3 yemek kaşığı, 50gr",
                            FoodName = "Makarna",
                            IsActive = true
                        },
                        new
                        {
                            ID = 5,
                            Calorie = 25000.0,
                            CategoryId = 5,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5270),
                            Description = "4 yemek kaşığı, 200gr",
                            FoodName = "Brokoli(pişmiş)",
                            IsActive = true
                        },
                        new
                        {
                            ID = 6,
                            Calorie = 60000.0,
                            CategoryId = 6,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5271),
                            Description = "1 küçük boy, 120gr",
                            FoodName = "Elma",
                            IsActive = true
                        },
                        new
                        {
                            ID = 7,
                            Calorie = 45000.0,
                            CategoryId = 7,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5272),
                            Description = "1 tatlı kaşığı, 5gr",
                            FoodName = "Tereyağ",
                            IsActive = true
                        },
                        new
                        {
                            ID = 8,
                            Calorie = 68000.0,
                            CategoryId = 8,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5273),
                            Description = "1 yemek kaşığı, 30gr",
                            FoodName = "Bal",
                            IsActive = true
                        },
                        new
                        {
                            ID = 9,
                            Calorie = 45000.0,
                            CategoryId = 9,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(5274),
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
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(767),
                            IsActive = true,
                            MealName = "Kahvaltı"
                        },
                        new
                        {
                            ID = 2,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(771),
                            IsActive = true,
                            MealName = "Öğle Yemeği"
                        },
                        new
                        {
                            ID = 3,
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 407, DateTimeKind.Local).AddTicks(772),
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
                            CreateOn = new DateTime(2022, 12, 24, 17, 46, 56, 406, DateTimeKind.Local).AddTicks(8684),
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
                        .OnDelete(DeleteBehavior.Restrict)
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
