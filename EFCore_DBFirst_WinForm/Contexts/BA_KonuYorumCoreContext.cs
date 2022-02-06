using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCore_DBFirst_WinForm.Entities;

namespace EFCore_DBFirst_WinForm.Contexts
{
    public partial class BA_KonuYorumCoreContext : DbContext
    {
        public BA_KonuYorumCoreContext()
        {
        }

        public BA_KonuYorumCoreContext(DbContextOptions<BA_KonuYorumCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Konular> Konulars { get; set; } = null!;
        public virtual DbSet<Yorumlar> Yorumlars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BA_KonuYorumCore;user id=sa;password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konular>(entity =>
            {
                entity.ToTable("Konular");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Baslik)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tarih).HasColumnType("datetime");
            });

            modelBuilder.Entity<Yorumlar>(entity =>
            {
                entity.ToTable("Yorumlar");

                entity.Property(e => e.Icerik)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.Property(e => e.Yorumcu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Konu)
                    .WithMany(p => p.Yorumlars)
                    .HasForeignKey(d => d.KonuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Yorum_Konu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
