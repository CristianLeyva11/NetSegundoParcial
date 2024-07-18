using ApiLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLINQ
{
    public class EmpresaContext: DbContext
    {
        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        { }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Ciudad> ciudadInit = new List<Ciudad>();
            ciudadInit.Add(new Ciudad {

                idCiudad = 1,
                nombreCiudad = "Leon"

                });
            ciudadInit.Add(new Ciudad
            {

                idCiudad = 2,
                nombreCiudad = "Puri"

            });
            ciudadInit.Add(new Ciudad
            {

                idCiudad = 3,
                nombreCiudad = "Silao"

            });

            modelBuilder.Entity<Ciudad>(ciudad =>
            {
                ciudad.ToTable("Ciudad");
                ciudad.HasKey(p => p.idCiudad);
                ciudad.Property(p => p.idCiudad).ValueGeneratedOnAdd().UseIdentityColumn();
                ciudad.Property(p => p.nombreCiudad).IsRequired().HasMaxLength(150);


                //Agregar datos iniciales
                ciudad.HasData(ciudadInit);
            });





            //Creando una colección de objetos Empleado para los datos iniciales.
            List<Empleado> empleadoInit = new List<Empleado>();
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 1,
                nombreEmpleado = "Mario Zuniga",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 1600,
                idCiudad = 1
            });
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 2,
                nombreEmpleado = "Cristian Leyva",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 3200,
                idCiudad = 2
            });
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 3,
                nombreEmpleado = "Emmanuel Escobedo",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 3200,
                idCiudad = 2
            });
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 4,
                nombreEmpleado = "Brenda Gutierrez",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 3200,
                idCiudad = 3
            });
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 5,
                nombreEmpleado = "Pedro Morales",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 3200,
                idCiudad = 1
            });
            empleadoInit.Add(new Empleado
            {
                idEmpleado = 6,
                nombreEmpleado = "Israel Lopez",
                fechaIngreso = DateTime.Now,
                puesto = "Desarrollador",
                sueldo = 3200,
                idCiudad = 1
            });

            modelBuilder.Entity<Empleado>(empleado =>
            {
                empleado.ToTable("Empleado");
                empleado.HasKey(p => p.idEmpleado);
                empleado.Property(p => p.idEmpleado).ValueGeneratedOnAdd().UseIdentityColumn();
                empleado.Property(p => p.nombreEmpleado).IsRequired().HasMaxLength(150);
                empleado.Property(p => p.puesto).IsRequired();
                empleado.Property(p => p.sueldo).IsRequired();
                empleado.Property(p => p.fechaIngreso).IsRequired();

                empleado.HasOne(e => e.Ciudad)
                .WithMany(c => c.Empleado)
                .HasForeignKey(e => e.idCiudad);
                //Agregar datos iniciales
                empleado.HasData(empleadoInit);
            });




            List<Departamento> departamentoInit = new List<Departamento>();
            departamentoInit.Add(new Departamento
            {
                idDepartamento = 1,
                nombreDepartamento = "Tickets",
                descripcion = "Aqui hacen tickets Jaja (Mucho ojo con la Coordi)."
            });
            departamentoInit.Add(new Departamento
            {
                idDepartamento = 2,
                nombreDepartamento = "Logistica",
                descripcion = "Aqui hacen cosas de Logistica Duh!"
            });
            departamentoInit.Add(new Departamento
            {
                idDepartamento = 3,
                nombreDepartamento = "Administrativo",
                descripcion = "Aqui hacen Pan, o no se, nunca le supe a la administracion."
            });

            modelBuilder.Entity<Departamento>(departamento =>
            {
                departamento.ToTable("Departamento");
                departamento.HasKey(p => p.idDepartamento);
                departamento.Property(p => p.idDepartamento).ValueGeneratedOnAdd().UseIdentityColumn();
                departamento.Property(p => p.nombreDepartamento).IsRequired().HasMaxLength(150);
                departamento.Property(p => p.descripcion).IsRequired();


                //Agregar datos iniciales
                departamento.HasData(departamentoInit);
            });

            List<EmpleadoDepartamento> empdepInnt = new List<EmpleadoDepartamento>();
            empdepInnt.Add(new EmpleadoDepartamento {
            
                idDepartamento = 1,
                idEmpleado = 1,
            
            });
            empdepInnt.Add(new EmpleadoDepartamento
            {

                idDepartamento = 1,
                idEmpleado = 2,

            });
            empdepInnt.Add(new EmpleadoDepartamento
            {

                idDepartamento = 2,
                idEmpleado = 3,

            });
            empdepInnt.Add(new EmpleadoDepartamento
            {

                idDepartamento = 2,
                idEmpleado = 4,

            });
            empdepInnt.Add(new EmpleadoDepartamento
            {

                idDepartamento = 3,
                idEmpleado = 5,

            });
            empdepInnt.Add(new EmpleadoDepartamento
            {

                idDepartamento = 3,
                idEmpleado = 6,

            });

            modelBuilder.Entity<EmpleadoDepartamento>(empleadoDepartamento =>
            {
                empleadoDepartamento.ToTable("EmpleadoDepartamento");
                empleadoDepartamento.HasKey(ed => new { ed.idEmpleado, ed.idDepartamento });

                empleadoDepartamento.HasOne(ed => ed.Empleado)
                    .WithMany(e => e.EmpleadoDepartamentos)
                    .HasForeignKey(ed => ed.idEmpleado);

                empleadoDepartamento.HasOne(ed => ed.Departamento)
                    .WithMany(d => d.EmpleadoDepartamentos)
                    .HasForeignKey(ed => ed.idDepartamento);

                empleadoDepartamento.HasData(empdepInnt);
            });

        }
    }
}
