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

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GUSKUDA;Database=dbPeliculas;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("peliculas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

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
