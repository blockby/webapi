﻿// <auto-generated />
using System;
using BBBWebApiCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Collected_data", b =>
                {
                    b.Property<int>("id_coll_data")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("data_created");

                    b.Property<DateTime>("date_created");

                    b.Property<string>("dst");

                    b.Property<int>("hours");

                    b.Property<int>("id_day");

                    b.Property<int>("id_day_type");

                    b.Property<int>("id_in_activity");

                    b.Property<int>("id_in_day_period");

                    b.Property<int>("id_location");

                    b.Property<string>("id_oui");

                    b.Property<int>("id_out_activity");

                    b.Property<int>("id_out_day_period");

                    b.Property<int>("id_service");

                    b.Property<int>("returning_customer");

                    b.Property<int>("sn");

                    b.Property<long>("src");

                    b.Property<string>("src_resolved");

                    b.Property<string>("ssid");

                    b.Property<double>("stay");

                    b.Property<string>("subtype");

                    b.Property<TimeSpan>("time_created");

                    b.HasKey("id_coll_data");

                    b.HasIndex("id_day");

                    b.HasIndex("id_day_type");

                    b.HasIndex("id_in_activity");

                    b.HasIndex("id_in_day_period");

                    b.HasIndex("id_location");

                    b.HasIndex("id_out_activity");

                    b.HasIndex("id_out_day_period");

                    b.ToTable("collected_data");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day", b =>
                {
                    b.Property<int>("id_day")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name_day");

                    b.HasKey("id_day");

                    b.ToTable("days");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day_type", b =>
                {
                    b.Property<int>("id_day_type")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("day_type");

                    b.Property<string>("description");

                    b.HasKey("id_day_type");

                    b.ToTable("day_types");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.In_activity", b =>
                {
                    b.Property<int>("id_in_activity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_activity");

                    b.HasKey("id_in_activity");

                    b.ToTable("in_activitys");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.In_day_period", b =>
                {
                    b.Property<int>("id_in_day_period")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_period");

                    b.HasKey("id_in_day_period");

                    b.ToTable("in_day_periods");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Location", b =>
                {
                    b.Property<int>("id_location")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<Point>("coordinates");

                    b.Property<string>("description");

                    b.Property<int>("id_prop_type");

                    b.Property<int>("id_service");

                    b.Property<int>("id_user");

                    b.HasKey("id_location");

                    b.HasIndex("id_prop_type");

                    b.HasIndex("id_service");

                    b.HasIndex("id_user");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Out_activity", b =>
                {
                    b.Property<int>("id_out_activity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_activity");

                    b.HasKey("id_out_activity");

                    b.ToTable("out_activitys");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Out_day_period", b =>
                {
                    b.Property<int>("id_out_day_period")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_period");

                    b.HasKey("id_out_day_period");

                    b.ToTable("out_day_periods");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Property_type", b =>
                {
                    b.Property<int>("id_prop_type")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("prop_type");

                    b.HasKey("id_prop_type");

                    b.ToTable("property_types");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Service", b =>
                {
                    b.Property<int>("id_service")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_service");

                    b.HasKey("id_service");

                    b.ToTable("services");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Shared_location", b =>
                {
                    b.Property<int>("id_sh_location")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("id_location");

                    b.Property<int>("id_user");

                    b.Property<bool>("state");

                    b.HasKey("id_sh_location");

                    b.HasIndex("id_location");

                    b.ToTable("shared_locations");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("depend");

                    b.Property<string>("description");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.User_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("description");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = 2, Name = "Broker", NormalizedName = "BROKER" },
                        new { Id = 3, Name = "ShopOwner", NormalizedName = "SHOPOWNER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Collected_data", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Day", "day")
                        .WithMany()
                        .HasForeignKey("id_day")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Day_type", "day_type")
                        .WithMany()
                        .HasForeignKey("id_day_type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.In_activity", "in_activity")
                        .WithMany()
                        .HasForeignKey("id_in_activity")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.In_day_period", "in_day_period")
                        .WithMany()
                        .HasForeignKey("id_in_day_period")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("id_location")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Out_activity", "out_activity")
                        .WithMany()
                        .HasForeignKey("id_out_activity")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Out_day_period", "out_day_period")
                        .WithMany()
                        .HasForeignKey("id_out_day_period")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Location", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Property_type", "property_type")
                        .WithMany()
                        .HasForeignKey("id_prop_type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Service", "service")
                        .WithMany()
                        .HasForeignKey("id_service")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("id_user")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Shared_location", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("id_location")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User_type")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User_type")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
