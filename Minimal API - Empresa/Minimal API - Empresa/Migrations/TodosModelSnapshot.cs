﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal_API___Empresa.Models;

#nullable disable

namespace Minimal_API___Empresa.Migrations
{
    [DbContext(typeof(Todos))]
    partial class TodosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Minimal_API___Empresa.Models.Ciudad", b =>
                {
                    b.Property<int>("Ciudadid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ciudadid"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ciudadid");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"));

                    b.Property<int>("Ciudadid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechaingreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sueldo")
                        .HasColumnType("float");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("Ciudadid");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.EmpleadoDepartamento", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId", "DepartamentoId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("EmpleadoDepartamentos");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Empleado", b =>
                {
                    b.HasOne("Minimal_API___Empresa.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("Ciudadid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.EmpleadoDepartamento", b =>
                {
                    b.HasOne("Minimal_API___Empresa.Models.Departamento", "Departamento")
                        .WithMany("EmpleadoDepartamentos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Minimal_API___Empresa.Models.Empleado", "Empleado")
                        .WithMany("EmpleadoDepartamentos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Departamento", b =>
                {
                    b.Navigation("EmpleadoDepartamentos");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Empleado", b =>
                {
                    b.Navigation("EmpleadoDepartamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
