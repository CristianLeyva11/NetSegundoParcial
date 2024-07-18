using Microsoft.EntityFrameworkCore;
using Parcial2.Models;

namespace Parcial2.Data
{
    public class BDProyectoContext : DbContext
    {
        public BDProyectoContext(DbContextOptions<BDProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto).HasName("PK_Producto");
                entity.ToTable("Productos");

                entity.Property(e => e.IdProducto).HasColumnName("IdProducto");
                entity.Property(e => e.IdCategoria).HasColumnName("IdCategoria");
                entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false).IsRequired();
                entity.Property(e => e.Precio).HasColumnType("float").IsRequired(); 
                entity.Property(e => e.Descripcion).HasMaxLength(500).IsUnicode(false).IsRequired();
                entity.Property(e => e.Imagen).HasMaxLength(200).IsUnicode(false);

                entity.HasOne(e => e.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(e => e.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK_Categoria");
                entity.ToTable("Categorias");

                entity.Property(e => e.IdCategoria).HasColumnName("IdCategoria");
                entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
