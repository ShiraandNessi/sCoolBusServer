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

        public virtual DbSet<Rating> Ratings { get; set; }

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

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
