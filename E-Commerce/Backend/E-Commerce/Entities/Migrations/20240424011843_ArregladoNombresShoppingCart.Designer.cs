﻿// <auto-generated />
using System;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20240424011843_ArregladoNombresShoppingCart")]
    partial class ArregladoNombresShoppingCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Model.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("smallmoney")
                        .HasColumnName("total_price");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("cart_item", (string)null);
                });

            modelBuilder.Entity("Entities.Model.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_category")
                        .IsUnique();

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Entities.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("Entities.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar")
                        .HasColumnName("name");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("Entities.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Title" }, "UQ_product")
                        .IsUnique();

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Entities.Model.ProductSale", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int")
                        .HasColumnName("product_quantity");

                    b.HasKey("SaleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsSales");
                });

            modelBuilder.Entity("Entities.Model.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("UserId");

                    b.ToTable("sale", (string)null);
                });

            modelBuilder.Entity("Entities.Model.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SaleQuantity")
                        .HasColumnType("int")
                        .HasColumnName("sale_quantity");

                    b.HasKey("Id");

                    b.ToTable("seller", (string)null);
                });

            modelBuilder.Entity("Entities.Model.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Total")
                        .HasColumnType("smallmoney")
                        .HasColumnName("total");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("shopping_cart", (string)null);
                });

            modelBuilder.Entity("Entities.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("addres");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("date")
                        .HasColumnName("date_of_creation");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("password");

                    b.Property<int>("PurchaseCount")
                        .HasColumnType("int")
                        .HasColumnName("purchase_count");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar")
                        .HasColumnName("username");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex(new[] { "Email" }, "UQ_user_email")
                        .IsUnique();

                    b.HasIndex(new[] { "UserName" }, "UQ_user_username")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Entities.Model.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Type" }, "UQ_usertype")
                        .IsUnique();

                    b.ToTable("userType", (string)null);
                });

            modelBuilder.Entity("Entities.Model.CartItem", b =>
                {
                    b.HasOne("Entities.Model.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Model.ShoppingCart", "ShoppingCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Entities.Model.Comment", b =>
                {
                    b.HasOne("Entities.Model.Comment", "Response")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Model.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Response");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Model.Image", b =>
                {
                    b.HasOne("Entities.Model.Product", "Pruduct")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pruduct");
                });

            modelBuilder.Entity("Entities.Model.Product", b =>
                {
                    b.HasOne("Entities.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Model.ProductSale", b =>
                {
                    b.HasOne("Entities.Model.Product", "Product")
                        .WithMany("ProductsSales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Model.Sale", "Sale")
                        .WithMany("ProductsSales")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Entities.Model.Sale", b =>
                {
                    b.HasOne("Entities.Model.Seller", "Seller")
                        .WithMany("Sales")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Model.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Model.ShoppingCart", b =>
                {
                    b.HasOne("Entities.Model.User", "User")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("Entities.Model.ShoppingCart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Model.User", b =>
                {
                    b.HasOne("Entities.Model.Seller", "Seller")
                        .WithMany("Users")
                        .HasForeignKey("SellerId");

                    b.HasOne("Entities.Model.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Entities.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Model.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("ProductsSales");
                });

            modelBuilder.Entity("Entities.Model.Sale", b =>
                {
                    b.Navigation("ProductsSales");
                });

            modelBuilder.Entity("Entities.Model.Seller", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.Model.ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Entities.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Sales");

                    b.Navigation("ShoppingCart")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Model.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
