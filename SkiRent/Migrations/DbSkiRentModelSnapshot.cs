﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkiRent.Models;

namespace SkiRent.Migrations
{
    [DbContext(typeof(SkiRent02Context))]
    partial class DbSkiRentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkiRent.Models.Boots", b =>
                {
                    b.Property<int>("BootsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bracing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BootsId");

                    b.HasIndex("BrandId");

                    b.HasIndex("LevelId");

                    b.ToTable("Boots");
                });

            modelBuilder.Entity("SkiRent.Models.Brands", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SkiRent.Models.Clients", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Depozit")
                        .HasColumnType("real");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SkiRent.Models.Levels", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LevelId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SkiRent.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BootsId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SkiId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SticksId")
                        .HasColumnType("int");

                    b.Property<int>("StuffId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("BootsId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SkiId");

                    b.HasIndex("SticksId");

                    b.HasIndex("StuffId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SkiRent.Models.Positions", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("SkiRent.Models.Services", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StuffId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("StuffId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SkiRent.Models.Ski", b =>
                {
                    b.Property<int>("SkiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bracing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("SkiId");

                    b.HasIndex("BrandId");

                    b.HasIndex("LevelId");

                    b.ToTable("Ski");
                });

            modelBuilder.Entity("SkiRent.Models.Sticks", b =>
                {
                    b.Property<int>("StickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("StickId");

                    b.HasIndex("BrandId");

                    b.HasIndex("LevelId");

                    b.ToTable("Sticks");
                });

            modelBuilder.Entity("SkiRent.Models.Stuff", b =>
                {
                    b.Property<int>("StuffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PasportData")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("StuffId");

                    b.ToTable("Stuff");
                });

            modelBuilder.Entity("SkiRent.Models.StuffPosition", b =>
                {
                    b.Property<int>("StuffsPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("StuffId")
                        .HasColumnType("int");

                    b.HasKey("StuffsPositionId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StuffId");

                    b.ToTable("StuffPosition");
                });

            modelBuilder.Entity("SkiRent.Models.Trainings", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StuffId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingId");

                    b.HasIndex("StuffId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("SkiRent.Models.Boots", b =>
                {
                    b.HasOne("SkiRent.Models.Brands", "Brand")
                        .WithMany("Boots")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Boots_Brands")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Levels", "LevelNavigation")
                        .WithMany("Boots")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_Boots_Levels")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("LevelNavigation");
                });

            modelBuilder.Entity("SkiRent.Models.Orders", b =>
                {
                    b.HasOne("SkiRent.Models.Boots", "Boots")
                        .WithMany("Orders")
                        .HasForeignKey("BootsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Clients", "Clients")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Ski", "Ski")
                        .WithMany("Orders")
                        .HasForeignKey("SkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Sticks", "Sticks")
                        .WithMany("Orders")
                        .HasForeignKey("SticksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Stuff", "Stuff")
                        .WithMany("Orders")
                        .HasForeignKey("StuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boots");

                    b.Navigation("Clients");

                    b.Navigation("Ski");

                    b.Navigation("Sticks");

                    b.Navigation("Stuff");
                });

            modelBuilder.Entity("SkiRent.Models.Services", b =>
                {
                    b.HasOne("SkiRent.Models.Stuff", "Stuff")
                        .WithMany("Services")
                        .HasForeignKey("StuffId")
                        .HasConstraintName("FK_Services_Stuff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stuff");
                });

            modelBuilder.Entity("SkiRent.Models.Ski", b =>
                {
                    b.HasOne("SkiRent.Models.Brands", "BrandNavigation")
                        .WithMany("Ski")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Ski_Brands")
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Levels", "LevelNavigation")
                        .WithMany("Ski")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_Ski_Levels")
                        .IsRequired();

                    b.Navigation("BrandNavigation");

                    b.Navigation("LevelNavigation");
                });

            modelBuilder.Entity("SkiRent.Models.Sticks", b =>
                {
                    b.HasOne("SkiRent.Models.Brands", "BrandNavigation")
                        .WithMany("Sticks")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Sticks_Brands")
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Levels", "LevelNavigation")
                        .WithMany("Sticks")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_Sticks_Levels")
                        .IsRequired();

                    b.Navigation("BrandNavigation");

                    b.Navigation("LevelNavigation");
                });

            modelBuilder.Entity("SkiRent.Models.StuffPosition", b =>
                {
                    b.HasOne("SkiRent.Models.Positions", "Position")
                        .WithMany("StuffPosition")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkiRent.Models.Stuff", "Stuff")
                        .WithMany("StuffPosotion")
                        .HasForeignKey("StuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Stuff");
                });

            modelBuilder.Entity("SkiRent.Models.Trainings", b =>
                {
                    b.HasOne("SkiRent.Models.Stuff", "Stuff")
                        .WithMany("Trainings")
                        .HasForeignKey("StuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stuff");
                });

            modelBuilder.Entity("SkiRent.Models.Boots", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SkiRent.Models.Brands", b =>
                {
                    b.Navigation("Boots");

                    b.Navigation("Ski");

                    b.Navigation("Sticks");
                });

            modelBuilder.Entity("SkiRent.Models.Clients", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SkiRent.Models.Levels", b =>
                {
                    b.Navigation("Boots");

                    b.Navigation("Ski");

                    b.Navigation("Sticks");
                });

            modelBuilder.Entity("SkiRent.Models.Positions", b =>
                {
                    b.Navigation("StuffPosition");
                });

            modelBuilder.Entity("SkiRent.Models.Ski", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SkiRent.Models.Sticks", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SkiRent.Models.Stuff", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Services");

                    b.Navigation("StuffPosotion");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
