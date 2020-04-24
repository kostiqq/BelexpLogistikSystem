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
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Costumers> Costumers { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<FuelForRide> FuelForRide { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
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

                entity.Property(e => e.TrailersId).HasColumnName("TrailersID");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Cars_CarOwner1");

                entity.HasOne(d => d.Trailers)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.TrailersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Cars_Trailers");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Cities_Country");
            });

            modelBuilder.Entity<Costumers>(entity =>
            {
                entity.Property(e => e.CostumerEmail).HasMaxLength(20);

                entity.Property(e => e.CostumerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OtherInfo).HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DriverPatronymic)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DriverSurname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastMedicalInspection).HasColumnType("date");
            });

            modelBuilder.Entity<FuelForRide>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FuelingId).HasColumnName("FuelingID");

                entity.Property(e => e.RideId).HasColumnName("RideID");

                entity.Property(e => e.WayBillId).HasColumnName("WayBillID");

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.FuelForRide)
                    .HasForeignKey(d => d.RideId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FuelForRide_Ride");
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.Property(e => e.GoodsName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Notes).HasMaxLength(100);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.CostumerId).HasColumnName("CostumerID");

                entity.Property(e => e.GoodsId).HasColumnName("GoodsID");

                entity.Property(e => e.OtherInfo).HasMaxLength(100);

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CostumerId)
                    .HasConstraintName("FK_Orders_Costumers");

                entity.HasOne(d => d.DepartureCityNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DepartureCity)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Cities");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("FK_Orders_Goods");
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
