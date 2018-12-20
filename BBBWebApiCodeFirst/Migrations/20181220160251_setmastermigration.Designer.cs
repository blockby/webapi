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
    [Migration("20181220160251_setmastermigration")]
    partial class setmastermigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Days", b =>
                {
                    b.Property<int>("IdDay")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameDay");

                    b.HasKey("IdDay");

                    b.ToTable("Dayss");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.Mtc", b =>
                {
                    b.Property<int>("Gid")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Area");

                    b.Property<Geometry>("Geom");

                    b.Property<decimal?>("Groesse");

                    b.Property<decimal?>("Id");

                    b.HasKey("Gid");

                    b.ToTable("Mtcs");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.MtcActivity", b =>
                {
                    b.Property<int>("IdAct")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CountAct");

                    b.Property<int>("DaysAct");

                    b.Property<decimal?>("Density");

                    b.Property<int>("HoursAct");

                    b.Property<int>("ZoneAct");

                    b.HasKey("IdAct");

                    b.HasIndex("DaysAct");

                    b.HasIndex("ZoneAct");

                    b.ToTable("MtcActivitys");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.MtcHomezone", b =>
                {
                    b.Property<int>("IdHz")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DaysHz");

                    b.Property<int>("HomeHz");

                    b.Property<decimal>("SharedHz");

                    b.Property<int>("ZoneHz");

                    b.HasKey("IdHz");

                    b.HasIndex("HomeHz");

                    b.ToTable("MtcHomezones");
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.MtcActivity", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Days", "Days")
                        .WithMany()
                        .HasForeignKey("DaysAct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BBBWebApiCodeFirst.Models.Mtc", "Mtc")
                        .WithMany()
                        .HasForeignKey("ZoneAct")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BBBWebApiCodeFirst.Models.MtcHomezone", b =>
                {
                    b.HasOne("BBBWebApiCodeFirst.Models.Mtc", "Mtc")
                        .WithMany()
                        .HasForeignKey("HomeHz")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
