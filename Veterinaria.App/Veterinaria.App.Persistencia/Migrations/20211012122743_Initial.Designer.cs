// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinaria.App.Persistencia;

namespace Veterinaria.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211012122743_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Veterinaria.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CuidadorId")
                        .HasColumnType("int");

                    b.Property<string>("fechaNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CuidadorId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Veterinaria.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Veterinaria.App.Dominio.Cuidador", b =>
                {
                    b.HasBaseType("Veterinaria.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("Cuidador");
                });

            modelBuilder.Entity("Veterinaria.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("Veterinaria.App.Dominio.Persona");

                    b.Property<string>("Especializacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("Veterinaria.App.Dominio.Mascota", b =>
                {
                    b.HasOne("Veterinaria.App.Dominio.Cuidador", "Cuidador")
                        .WithMany("Mascotas")
                        .HasForeignKey("CuidadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuidador");
                });

            modelBuilder.Entity("Veterinaria.App.Dominio.Cuidador", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}
