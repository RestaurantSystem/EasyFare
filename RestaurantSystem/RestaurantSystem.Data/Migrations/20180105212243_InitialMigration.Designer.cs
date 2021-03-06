﻿namespace RestaurantSystem.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    [DbContext(typeof(RestaurantSystemDbContext))]
    [Migration("20180105212243_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("MinStockQuantityThreshold");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<float>("QuantityInStock");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillId");

                    b.Property<DateTime>("OrderTime");

                    b.Property<string>("WaiterId");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCookable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Price");

                    b.Property<int?>("RecipeId");

                    b.Property<string>("TableNumber");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RecipeId")
                        .IsUnique()
                        .HasFilter("[RecipeId] IS NOT NULL");

                    b.HasIndex("TableNumber");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.ProductOrder", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("OrderId");

                    b.Property<bool>("IsReadyToServe");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("IngredientId");

                    b.Property<double>("Quantity");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TableNumber");

                    b.HasKey("Id");

                    b.HasIndex("TableNumber");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsForSmokers");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Table", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

                    b.Property<int?>("OrderId");

                    b.Property<int>("Seats");

                    b.Property<int>("SectionId");

                    b.HasKey("Number");

                    b.HasIndex("OrderId");

                    b.HasIndex("SectionId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.TableProduct", b =>
                {
                    b.Property<string>("TableNumber");

                    b.Property<int>("ProductId");

                    b.HasKey("TableNumber", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("TableProduct");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<decimal>("Money");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<decimal>("Salary");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.WaiterSection", b =>
                {
                    b.Property<string>("WaiterId");

                    b.Property<int>("SectionId");

                    b.HasKey("WaiterId", "SectionId");

                    b.HasIndex("SectionId");

                    b.ToTable("WaiterSections");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Order", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Bill", "Bill")
                        .WithMany("Orders")
                        .HasForeignKey("BillId");

                    b.HasOne("RestaurantSystem.Data.Models.User", "Waiter")
                        .WithMany("OrdersAsWaiter")
                        .HasForeignKey("WaiterId");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Product", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Recipe", "Recipe")
                        .WithOne("Product")
                        .HasForeignKey("RestaurantSystem.Data.Models.Product", "RecipeId");

                    b.HasOne("RestaurantSystem.Data.Models.Table")
                        .WithMany("ProductsOnTable")
                        .HasForeignKey("TableNumber");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.ProductOrder", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantSystem.Data.Models.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.RecipeIngredient", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantSystem.Data.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableNumber");
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.Table", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Order", "Order")
                        .WithMany("Tables")
                        .HasForeignKey("OrderId");

                    b.HasOne("RestaurantSystem.Data.Models.Section", "Section")
                        .WithMany("Tables")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.TableProduct", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Product", "Product")
                        .WithMany("Tables")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantSystem.Data.Models.Table", "Table")
                        .WithMany("Products")
                        .HasForeignKey("TableNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RestaurantSystem.Data.Models.WaiterSection", b =>
                {
                    b.HasOne("RestaurantSystem.Data.Models.Section", "Section")
                        .WithMany("WaiterSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantSystem.Data.Models.User", "Waiter")
                        .WithMany("WaiterSections")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
