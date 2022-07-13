using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mascotas.Models
{
    public partial class GatosContexto : DbContext
    {
        public GatosContexto()
        {
        }

        public GatosContexto(DbContextOptions<GatosContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Gato> Gatos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gato>(entity =>
            {
                entity.HasKey(e => e.IdGato);

                entity.ToTable("Gato");

                entity.Property(e => e.Nacimiento).HasColumnType("smalldatetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
