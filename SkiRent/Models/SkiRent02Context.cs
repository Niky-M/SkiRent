using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SkiRent.Models
{
    public partial class SkiRent02Context : DbContext
    {
        public SkiRent02Context()
        {
        }

        public SkiRent02Context(DbContextOptions<SkiRent02Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Boot> Boots { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Ski> Skis { get; set; }
        public virtual DbSet<Stick> Sticks { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<StuffsPosition> StuffsPositions { get; set; }
        public virtual DbSet<training> training { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;Database=SkiRent02;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Boot>(entity =>
            {
                entity.ToTable("Boot");

                entity.HasIndex(e => e.BrandId, "IX_Boots_BrandId");

                entity.HasIndex(e => e.LevelId, "IX_Boots_LevelId");

                entity.Property(e => e.Bracing)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Boots)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Boots_Brands");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Boots)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Boots_Levels");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.ClientId, "IX_Orders_ClientId");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.Boot)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BootId)
                    .HasConstraintName("FK_Order_Boot");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.Ski)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SkiId)
                    .HasConstraintName("FK_Order_Ski");

                entity.HasOne(d => d.Stick)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StickId)
                    .HasConstraintName("FK_Order_Stick");

                entity.HasOne(d => d.Stuff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StuffId)
                    .HasConstraintName("FK_Order_Stuff");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId).ValueGeneratedNever();

                entity.Property(e => e.Position1).HasColumnName("Position");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).ValueGeneratedNever();

                entity.Property(e => e.Service1)
                    .IsRequired()
                    .HasColumnName("Service");

                entity.HasOne(d => d.Stuff)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.StuffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Stuff");
            });

            modelBuilder.Entity<Ski>(entity =>
            {
                entity.ToTable("Ski");

                entity.HasIndex(e => e.BrandId, "IX_Ski_BrandId");

                entity.HasIndex(e => e.LevelId, "IX_Ski_LevelId");

                entity.Property(e => e.Bracing)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Skis)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ski_Brands");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Skis)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ski_Levels");
            });

            modelBuilder.Entity<Stick>(entity =>
            {
                entity.ToTable("Stick");

                entity.HasIndex(e => e.BrandId, "IX_Sticks_BrandId");

                entity.HasIndex(e => e.LevelId, "IX_Sticks_LevelId");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Sticks)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sticks_Brands");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Sticks)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sticks_Levels");
            });

            modelBuilder.Entity<Stuff>(entity =>
            {
                entity.ToTable("Stuff");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<StuffsPosition>(entity =>
            {
                entity.ToTable("StuffsPosition");

                entity.Property(e => e.StuffsPositionId).ValueGeneratedNever();

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.StuffsPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuffsPosition_Position");

                entity.HasOne(d => d.Stuff)
                    .WithMany(p => p.StuffsPositions)
                    .HasForeignKey(d => d.StuffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StuffsPosition_Stuff");
            });

            modelBuilder.Entity<training>(entity =>
            {
                entity.ToTable("Training");

                entity.Property(e => e.TrainingId).ValueGeneratedNever();

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TrainingType).IsRequired();

                entity.HasOne(d => d.Stuff)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.StuffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Training_Stuff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
