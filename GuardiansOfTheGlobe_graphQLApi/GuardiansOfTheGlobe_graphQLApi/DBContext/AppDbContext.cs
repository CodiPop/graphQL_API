using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GuardiansOfTheGlobeApi.Models;
using GuardiansOfTheGlobe_graphQLApi.Models;

namespace GuardiansOfTheGlobe_graphQLApi.DBContext
{
    public partial class AppDbContext : DbContext
    {
        internal object VillanoPeleasResult;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agenda> Agenda { get; set; } = null!;
        public virtual DbSet<Hero> Heroes { get; set; } = null!;
        public virtual DbSet<Patrocinador> Patrocinadores { get; set; } = null!;
        public virtual DbSet<Pelea> Peleas { get; set; } = null!;
        public virtual DbSet<Villano> Villanos { get; set; } = null!;
        public virtual DbSet<MyG> Myg { get; set; } = null!;
        public virtual DbSet<Villanomas> Villanomas { get; set; } = null!;
        public virtual DbSet<Heroestop3> Heroestop3s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasOne(d => d.IdHeroeNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdHeroe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__agenda__id_heroe__3E52440B");
            });
            modelBuilder.Entity<Patrocinador>(entity =>
            {
                entity.HasOne(d => d.IdHeroeNavigation)
                    .WithMany(p => p.Patrocinadores)
                    .HasForeignKey(d => d.IdHeroe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__patrocina__id_he__412EB0B6");
            });

            modelBuilder.Entity<Pelea>(entity =>
            {
                entity.HasOne(d => d.IdHeroeNavigation)
                    .WithMany(p => p.Peleas)
                    .HasForeignKey(d => d.IdHeroe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__peleas__id_heroe__440B1D61");

                entity.HasOne(d => d.IdVillanoNavigation)
                    .WithMany(p => p.Peleas)
                    .HasForeignKey(d => d.IdVillano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__peleas__id_villa__44FF419A");
            });

            modelBuilder.Entity<MyG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(m => m.NombreHeroe)
                    .HasColumnName("nombre_heroe");

                entity.Property(m => m.NombreVillano)
                    .HasColumnName("nombre_villano");

                entity.Property(m => m.Resultado)
                    .HasColumnName("resultado");
            });

            modelBuilder.Entity<Villanomas>(entity =>
            {
                // Indicar que no hay una tabla correspondiente a este tipo
                entity.HasNoKey();

                // Mapear las propiedades a las columnas de la consulta
                entity.Property(v => v.NombreVillano)
                    .HasColumnName("nombre_villano")
                    .IsRequired();

                entity.Property(v => v.CantidadDePeleas)
                    .HasColumnName("cantidad_de_peleas")
                    .IsRequired();
            });

            modelBuilder.Entity<Heroestop3>(entity =>
            {
                // Indicar que no hay una tabla correspondiente a este tipo
                entity.HasNoKey();

                // Mapear las propiedades a las columnas de la consulta
                entity.Property(h => h.Nombre)
                    .HasColumnName("nombre")
                    .IsRequired();

                entity.Property(h => h.Victorias)
                    .HasColumnName("victorias")
                    .IsRequired();
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
