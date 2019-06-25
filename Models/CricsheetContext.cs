using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CricAPI.Models
{
    public partial class CricsheetContext : DbContext
    {
        public CricsheetContext()
        {
        }

        public CricsheetContext(DbContextOptions<CricsheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Matches> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Cricsheet;User Id=sa;Password=nani@472;"); */
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.Cricsheetid)
                    .HasName("matches_pkey");

                entity.ToTable("matches");

                entity.Property(e => e.Cricsheetid)
                    .HasColumnName("cricsheetid")
                    .ValueGeneratedNever();

                entity.Property(e => e._Jsondata)
                    .HasColumnName("matchdata")
                    .HasColumnType("jsonb");
            });
        }
    }
}
