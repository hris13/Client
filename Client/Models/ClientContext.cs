using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Client.Models
{
    public partial class ClientContext : DbContext
    {
        public ClientContext()
        {
        }

        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\Local;Database=Clientdb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId).HasColumnName("materialID");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(50)
                    .HasColumnName("materialName");

                entity.Property(e => e.MaterialPrice).HasColumnName("materialPrice");

                entity.Property(e => e.OfferId).HasColumnName("offerID");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_Material_Offer");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.OfferId).HasColumnName("offerID");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(50)
                    .HasColumnName("materialName");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Time).HasColumnName("time");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
