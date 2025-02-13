﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal_API___Empresa.Models;

#nullable disable

namespace Minimal_API___Empresa.Migrations
{
    [DbContext(typeof(Todos))]
    [Migration("20240619044339_Inicialaaa")]
    partial class Inicialaaa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Departamentold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Departamentold"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Departamentold");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.Empleado", b =>
                {
                    b.Property<int>("Empleadold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Empleadold"));

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

                    b.HasKey("Empleadold");

                    b.HasIndex("Ciudadid");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Minimal_API___Empresa.Models.EmpleadoDepartamento", b =>
                {
                    b.Property<int>("Empleadold")
                        .HasColumnType("int");

                    b.Property<int>("Departamentold")
                        .HasColumnType("int");

                    b.HasKey("Empleadold", "Departamentold");

                    b.HasIndex("Departamentold");

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
                        .HasForeignKey("Departamentold")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Minimal_API___Empresa.Models.Empleado", "Empleado")
                        .WithMany("EmpleadoDepartamentos")
                        .HasForeignKey("Empleadold")
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
