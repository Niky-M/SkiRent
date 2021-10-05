//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace SkiRent.Models
//{
//    public partial class SkiRentContext : DbContext
//    {
//        public SkiRentContext()
//        {
//        }

//        public SkiRentContext(DbContextOptions<SkiRentContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Boots> Boots { get; set; }
//        public virtual DbSet<Brands> Brands { get; set; }
//        public virtual DbSet<Clients> Clients { get; set; }
//        //public virtual DbSet<DbEquipment> DbEquipment { get; set; }
//        public virtual DbSet<Levels> Levels { get; set; }
//        public virtual DbSet<Orders> Orders { get; set; }
//        public virtual DbSet<Positions> Positions { get; set; }
//        public virtual DbSet<Services> Services { get; set; }
//        public virtual DbSet<Ski> Ski { get; set; }
//        public virtual DbSet<Sticks> Sticks { get; set; }
//        public virtual DbSet<Stuff> Stuff { get; set; }
//        public virtual DbSet<StuffPosition> StuffPosition { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SkiRent02;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Boots>(entity =>
//            {
//                entity.HasKey(e => e.BootsId);

//                entity.HasIndex(e => e.BrandId);

//                entity.HasIndex(e => e.LevelId);

//                entity.Property(e => e.Bracing).IsRequired();

//                entity.Property(e => e.Style).IsRequired();

//                entity.HasOne(d => d.Brand)
//                    .WithMany(p => p.Boots)
//                    .HasForeignKey(d => d.BrandId)
//                    .HasConstraintName("FK_Boots_Brands");

//                entity.HasOne(d => d.LevelNavigation)
//                    .WithMany(p => p.Boots)
//                    .HasForeignKey(d => d.LevelId)
//                    .HasConstraintName("FK_Boots_Levels");
//            });

//            modelBuilder.Entity<Brands>(entity =>
//            {
//                entity.HasKey(e => e.BrandId);

//                entity.Property(e => e.Brand).IsRequired();
//            });

//            modelBuilder.Entity<Clients>(entity =>
//            {
//                entity.HasKey(e => e.ClientId);

//                entity.Property(e => e.ClientId).ValueGeneratedOnAdd();// тестовое добавление

//                entity.Property(e => e.Login)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.Name).IsRequired();

//                entity.Property(e => e.Phone).IsRequired(); // добавлено 09.02.2021

//                entity.Property(e => e.Password)
//                    .IsRequired()
//                    .HasMaxLength(50);
//            });

//            //modelBuilder.Entity<DbEquipment>(entity =>
//            //{
//            //    entity.HasKey(e => e.EquipmentId); //new { e.OrderId, e.SkiId, e.BootsId, e.SticksId });

//            //    entity.HasIndex(e => e.BootsId);

//            //    entity.HasIndex(e => e.SkiId);

//            //    entity.HasIndex(e => e.SticksId);

//            //    entity.HasOne(d => d.Boots)
//            //        .WithMany(p => p.DbEquipment)
//            //        .HasForeignKey(d => d.BootsId);

//            //    entity.HasOne(d => d.Order)
//            //        .WithMany(p => p.DbEquipment)
//            //        .HasForeignKey(d => d.OrderId);

//            //    entity.HasOne(d => d.Ski)
//            //        .WithMany(p => p.DbEquipment)
//            //        .HasForeignKey(d => d.SkiId);

//            //    entity.HasOne(d => d.Sticks)
//            //        .WithMany(p => p.DbEquipment)
//            //        .HasForeignKey(d => d.SticksId);
//            //});

//            modelBuilder.Entity<Levels>(entity =>
//            {
//                entity.HasKey(e => e.LevelId);

//                entity.Property(e => e.Level).IsRequired();
//            });

//            modelBuilder.Entity<Orders>(entity =>
//            {
//                entity.HasKey(e => e.OrderId);

//                entity.HasIndex(e => e.ClientId);

//                entity.HasIndex(e => e.StuffId);

//                entity.HasIndex(e => e.SkiId);

//                entity.HasIndex(e => e.BootsId);

//                entity.HasIndex(e => e.SticksId);

//                entity.Property(e => e.Status);

//                entity.Property(e => e.Data).HasColumnType("datetime");

//                entity.HasOne(d => d.Clients)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.ClientId);
//                    //.HasConstraintName("FK_Orders_Clients");

//                entity.HasOne(d => d.Stuff)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.StuffId);
//                   // .HasConstraintName("FK_Orders_Stuff");

//                entity.HasOne(d => d.Boots)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.BootsId);
//                    //.HasConstraintName("FK_Orders_Boots");

//                entity.HasOne(d => d.Ski)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.SkiId);
//                //.HasConstraintName("FK_Orders_Ski");

//                entity.HasOne(d => d.Sticks)
//                    .WithMany(p => p.Orders)
//                    .HasForeignKey(d => d.SticksId);
//                    //.HasConstraintName("FK_Orders_Sticks");
//            });

//            modelBuilder.Entity<Positions>(entity =>
//            {
//                entity.HasKey(e => e.PositionId);

//                entity.Property(e => e.Position);
//            });

//            modelBuilder.Entity<Services>(entity =>
//            {
//                entity.HasKey(e => e.ServiceId);

//                entity.HasIndex(e => e.StuffId);

//                entity.Property(e => e.Service);

//                entity.Property(e => e.Price);
//                entity.HasOne(d => d.Stuff)
//                    .WithMany(p => p.Services)
//                    .HasForeignKey(d => d.StuffId)
//                    .HasConstraintName("FK_Services_Stuff");
//            });

//            modelBuilder.Entity<Ski>(entity =>
//            {
//                entity.HasIndex(e => e.BrandId);

//                entity.HasIndex(e => e.LevelId);

//                entity.Property(e => e.Bracing).IsRequired();

//                entity.Property(e => e.Style).IsRequired();

//                entity.HasOne(d => d.BrandNavigation)
//                    .WithMany(p => p.Ski)
//                    .HasForeignKey(d => d.BrandId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Ski_Brands");

//                entity.HasOne(d => d.LevelNavigation)
//                    .WithMany(p => p.Ski)
//                    .HasForeignKey(d => d.LevelId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Ski_Levels");
//            });

//            modelBuilder.Entity<Sticks>(entity =>
//            {
//                entity.HasKey(e => e.StickId);

//                entity.HasIndex(e => e.BrandId);

//                entity.HasIndex(e => e.LevelId);

//                entity.HasOne(d => d.BrandNavigation)
//                    .WithMany(p => p.Sticks)
//                    .HasForeignKey(d => d.BrandId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Sticks_Brands");

//                entity.HasOne(d => d.LevelNavigation)
//                    .WithMany(p => p.Sticks)
//                    .HasForeignKey(d => d.LevelId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Sticks_Levels");
//            });

//            modelBuilder.Entity<Stuff>(entity =>
//            {
//                entity.HasKey(e => e.StuffId);

//                entity.Property(e => e.Name);

//                entity.Property(e => e.Phone);

//                entity.Property(e => e.PasportData);

//                entity.Property(e => e.Password);
//            });

//            modelBuilder.Entity<StuffPosition>(entity =>
//            {
//                entity.HasKey(e => e.StuffsPositionId);

//                entity.HasIndex(e => e.StuffId);

//                entity.HasIndex(e => e.PositionId);
//            });

//            modelBuilder.Entity<Trainings>(entity =>
//            {
//                entity.HasKey(e => e.TrainingId);

//                entity.Property(e => e.TrainingType);

//                entity.Property(e => e.Duration);

//                entity.Property(e => e.StartTime);

//                entity.Property(e => e.Price);

//                entity.HasIndex(e => e.StuffId);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}