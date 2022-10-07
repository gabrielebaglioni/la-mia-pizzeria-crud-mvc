﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace la_mia_pizzeria_crud_mvc.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "La classica",
                            Name = "Margherita",
                            Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                            Price = 4.00m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Il Sud",
                            Name = "Diavola",
                            Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                            Price = 5.50m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Il Nord",
                            Name = "Boscaiola",
                            Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = 4,
                            Description = "La Pizza Della Casa",
                            Name = "Nostrana",
                            Photo = "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780",
                            Price = 8.50m
                        });
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_crud_mvc.Models.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
