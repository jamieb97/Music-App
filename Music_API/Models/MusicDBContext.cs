using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Music_API.Models
{
    public partial class MusicDBContext : DbContext
    {
        public MusicDBContext()
        {
        }

        public MusicDBContext(DbContextOptions<MusicDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Track> Track { get; set; }

        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MusicDB";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.TrackId).HasColumnName("TrackID");

                entity.Property(e => e.Artist)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrackLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TrackName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
