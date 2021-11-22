using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class SchoolBusContext : DbContext
    {
        public SchoolBusContext()
        {
        }

        public SchoolBusContext(DbContextOptions<SchoolBusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<Messege> Messeges { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationOfRoute> StationOfRoutes { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentStatus> StudentStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=SchoolBus;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasIndex(e => e.DriverId, "IX_Drivers")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drivers_Users");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasIndex(e => e.FamilyId, "IX_Families")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FamilyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FatherPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MotherName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MotherPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Families_Stations");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Families_Users");
            });

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.ToTable("MessageType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Messege>(entity =>
            {
                entity.Property(e => e.MessageText).HasMaxLength(50);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Messeges)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messeges_Drivers");

                entity.HasOne(d => d.MessageType)
                    .WithMany(p => p.Messeges)
                    .HasForeignKey(d => d.MessageTypeId)
                    .HasConstraintName("FK_Messeges_MessageType");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_Routes_Drivers");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StationOfRoute>(entity =>
            {
                entity.ToTable("StationOfRoute");

                entity.HasIndex(e => e.StationOfRouteId, "IX_StationOfRoute")
                    .IsUnique();

                entity.Property(e => e.StationOfRouteId).ValueGeneratedNever();

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.StationOfRoutes)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationOfRoute_Routes2");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationOfRoutes)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationOfRoute_Stations");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.ToTable("StatusType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageRoute)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Families");

                entity.HasOne(d => d.Rout)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.RoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Routes1");
            });

            modelBuilder.Entity<StudentStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("StudentStatus");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.StudentStatuses)
                    .HasForeignKey(d => d.StatusTypeId)
                    .HasConstraintName("FK_StudentStatus_StatusType");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentStatuses)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentStatus_Students");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
