using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreService.Models
{
    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {
        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U6TULLG;Database=BlogDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Slag)
                    .HasColumnName("SLAG")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POST");

                entity.Property(e => e.PostId).HasColumnName("POST_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
