﻿// <auto-generated />
using System;
using BBBWebApiCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BBBWebApiCodeFirst.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190509121805_DeviceDataDataBase")]
    partial class DeviceDataDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("id_day");

                    b.Property<int>("id_day_period");

                    b.Property<int>("id_location");

                    b.Property<int>("id_vendor");

                    b.Property<int>("sn");

                    b.Property<string>("src");

                    b.Property<string>("src_resolved");

                    b.Property<string>("ssid");

                    b.Property<string>("subtype");

                    b.Property<TimeSpan>("time_created");

                    b.HasKey("id_coll_data");

                    b.HasIndex("id_day");

                    b.HasIndex("id_day_period");

                    b.HasIndex("id_location");

                    b.HasIndex("id_vendor");

                    b.ToTable("collected_data");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day", b =>
                {
                    b.Property<int>("id_day")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<int>("id_day_type");

                    b.Property<string>("name_day");

                    b.HasKey("id_day");

                    b.HasIndex("id_day_type");

                    b.ToTable("days");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day_period", b =>
                {
                    b.Property<int>("id_period_day")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_period");

                    b.HasKey("id_period_day");

                    b.ToTable("day_periods");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day_type", b =>
                {
                    b.Property<int>("id_type_day")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("type_day");

                    b.HasKey("id_type_day");

                    b.ToTable("day_types");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Location", b =>
                {
                    b.Property<int>("id_location")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<Point>("coordinates");

                    b.Property<string>("description");

                    b.Property<int>("id_prop_type");

                    b.Property<int>("id_user");

                    b.HasKey("id_location");

                    b.HasIndex("id_prop_type");

                    b.HasIndex("id_user");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Property_type", b =>
                {
                    b.Property<int>("id_type_prop")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("type_prop");

                    b.HasKey("id_type_prop");

                    b.ToTable("property_types");
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
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("depent");

                    b.Property<string>("description");

                    b.Property<int>("id_user_type");

                    b.Property<string>("name");

                    b.HasKey("id_user");

                    b.HasIndex("id_user_type");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.User_type", b =>
                {
                    b.Property<int>("id_type_user")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("type_user");

                    b.HasKey("id_type_user");

                    b.ToTable("user_types");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Vendor", b =>
                {
                    b.Property<int>("id_vendor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name_vendor");

                    b.HasKey("id_vendor");

                    b.ToTable("vendors");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Collected_data", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Day", "day")
                        .WithMany()
                        .HasForeignKey("id_day")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Day_period", "day_period")
                        .WithMany()
                        .HasForeignKey("id_day_period")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("id_location")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Vendor", "vendor")
                        .WithMany()
                        .HasForeignKey("id_vendor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Day", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Day_type", "day_type")
                        .WithMany()
                        .HasForeignKey("id_day_type")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Location", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Property_type", "property_type")
                        .WithMany()
                        .HasForeignKey("id_prop_type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.User", "user")
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

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.User", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.User_type", "user_type")
                        .WithMany()
                        .HasForeignKey("id_user_type")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
