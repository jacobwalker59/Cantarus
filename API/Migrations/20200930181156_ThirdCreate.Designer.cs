﻿// <auto-generated />
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200930181156_ThirdCreate")]
    partial class ThirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("SupermarketCheckout.ProductDeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemId");

                    b.ToTable("ProductDeals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 3,
                            Price = 2f,
                            ProductItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Count = 7,
                            Price = 4.2f,
                            ProductItemId = 1
                        });
                });

            modelBuilder.Entity("SupermarketCheckout.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ProductItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductName = "Apples",
                            ProductPrice = 1f
                        });
                });

            modelBuilder.Entity("SupermarketCheckout.ProductDeal", b =>
                {
                    b.HasOne("SupermarketCheckout.ProductItem", "ProductItem")
                        .WithMany("ProductDeals")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}