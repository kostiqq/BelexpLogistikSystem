using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BelexpLogistikWebApp
{
    public partial class BelexpLogistikContext : DbContext
    {
        public BelexpLogistikContext()
        {
        }

        public BelexpLogistikContext(DbContextOptions<BelexpLogistikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarOwner> CarOwner { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Ride> Ride { get; set; }
        public virtual DbSet<Trailers> Trailers { get; set; }
        public virtual DbSet<Waybill> Waybill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BLUJC71\\SQLEXPRESS;Database=BelexpLogistik;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOwner>(entity =>
            {
                entity.Property(e => e.OwnerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastTechnicalInspection).HasColumnType("date");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.RegistrSign)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Cars_CarOwner1");
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DriverCardId).HasMaxLength(15);

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DriverPatronymic)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DriverSurname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsFree).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastMedicalInspection).HasColumnType("date");

                entity.Property(e => e.Other).HasMaxLength(30);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.CostumerName)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.GoodsName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IsComplete).HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherInfo).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.WaybillId).HasColumnName("WaybillID");

                entity.HasOne(d => d.Waybill)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WaybillId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Waybill");
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Ride_Cars");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_Ride_Drivers");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Ride_Orders");
            });

            modelBuilder.Entity<Trailers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegisrtSign)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.TrailerModel)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Waybill>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.ShelfLifeFor).HasColumnType("date");

                entity.Property(e => e.WaybillSeries)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Waybill)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waybill_Cars");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Waybill)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waybill_Drivers");

                entity.HasOne(d => d.Trailers)
                    .WithMany(p => p.Waybill)
                    .HasForeignKey(d => d.TrailersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waybill_Trailers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
