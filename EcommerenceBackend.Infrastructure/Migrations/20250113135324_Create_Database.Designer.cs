﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerenceBackend.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250113135324_Create_Database")]
    partial class Create_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MobileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("Guid");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Orders.Order", b =>
                {
                    b.HasOne("EcommerenceBackend.Application.Domain.Customers.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Products.Product", b =>
                {
                    b.OwnsOne("EcommerenceBackend.Application.Domain.Products.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("varchar(3)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.HasOne("EcommerenceBackend.Application.Domain.Orders.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerenceBackend.Application.Domain.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EcommerenceBackend.Application.Domain.Products.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("EcommerenceBackend.Application.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
