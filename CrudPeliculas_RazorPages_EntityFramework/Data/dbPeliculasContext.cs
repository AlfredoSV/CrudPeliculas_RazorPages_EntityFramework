using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CrudPeliculas_RazorPages_EntityFramework.Data
{
    public partial class dbPeliculasContext : DbContext
    {
        public dbPeliculasContext()
        {
        }

        public dbPeliculasContext(DbContextOptions<dbPeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GUSKUDA;Database=dbPeliculas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("peliculas");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
