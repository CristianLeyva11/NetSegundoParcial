using Microsoft.EntityFrameworkCore;

namespace Minimal_API___Empresa.Models
{
    public class Todos : DbContext
    {
        public Todos(DbContextOptions<Todos> options)
            : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir claves primarias
            modelBuilder.Entity<Ciudad>().HasKey(c => c.idCiudad);
            modelBuilder.Entity<Departamento>().HasKey(d => d.idDepartamento);
            modelBuilder.Entity<Empleado>().HasKey(e => e.idEmpleado);

            // Configuración de la relación muchos a muchos
            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasKey(ed => new { ed.idEmpleado, ed.idDepartamento });

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(ed => ed.Empleado)
                .WithMany(e => e.EmpleadoDepartamentos)
                .HasForeignKey(ed => ed.idEmpleado);

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(ed => ed.Departamento)
                .WithMany(d => d.EmpleadoDepartamentos)
                .HasForeignKey(ed => ed.idDepartamento);

            // Relación uno a muchos entre Empleado y Ciudad
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Ciudad)
                .WithMany(c => c.Empleados)
                .HasForeignKey(e => e.idCiudad);
        }
    }
}
