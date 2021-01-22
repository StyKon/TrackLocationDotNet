using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace TrackLocation.Model
{
    public class TrackLocationContext:DbContext
    {
        public TrackLocationContext()
        {
        }

        public TrackLocationContext(DbContextOptions<TrackLocationContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<FamilyCar> FamilyCar { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<TypeCar> TypeCar { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9GD4K4L;Initial Catalog=TrackLocation;User ID=sa;Password=calipso1996;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", x => x.UseNetTopologySuite());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(e => e.FamilyCarId);

                entity.HasIndex(e => e.TypeCarId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.FamilyCarId).HasColumnName("FamilyCarID");

                entity.Property(e => e.Matricule).IsRequired();

                entity.Property(e => e.NameCar).IsRequired();

                entity.Property(e => e.TypeCarId).HasColumnName("TypeCarID");

                entity.Property(e => e.UserId).HasColumnName("UserID");


                entity.HasOne(d => d.User)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FamilyCar>(entity =>
            {
                entity.Property(e => e.FamilyCarId).HasColumnName("FamilyCarID");

                entity.Property(e => e.NameFamily).IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Location__E7FEA47605B8C4E7")
                    .IsClustered(false);

                entity.HasIndex(e => e.Severity)
                    .HasName("ix_severity");
               
                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .ValueGeneratedNever();
                entity.Property(b => b.Tracking)
                     .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<ICollection<Coordination>>(v));
                        

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.Severity)
                    .HasColumnName("severity")
                    .HasComputedColumnSql("(CONVERT([tinyint],json_value([Tracking],'$.severity')))");

                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.Property(e => e.Tracking).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAR_LOC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_LOC");
            });

            modelBuilder.Entity<TypeCar>(entity =>
            {
                entity.Property(e => e.TypeCarId).HasColumnName("TypeCarID");

                entity.Property(e => e.NameType).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Cin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NumPassport)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumTel)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.TypeUser).IsRequired();
            });

            
        }
        


    }
}
