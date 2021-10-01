using System;
using Veterinaria.App.Dominio;
using Veterinaria.App.Persistencia;

namespace Veterinaria.App.Consola
{
    class Program
    {

        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // AgregarVeterinario();
            // BuscarVeterinario(1);
            // EliminarVeterinario(1);
            EditarVeterinario();
        }


         private static void AgregarVeterinario(){
            var veterinario = new Veterinario 
            {
                Nombre = "Juan Pérez",
                Telefono = "8965",
                Edad = 18,
                Direccion = "calle 10",
                Correo=" juan@",
                Contrasenia = "axccdfpo",
                Especializacion = "veterinario felino",
                TarjetaProfesional = "hjagsu120",
                FechaNacimiento = new DateTime(1985, 03, 15)
            };       
            repositorioVeterinario.AgregarVeterinario(veterinario);
        }


        private static void BuscarVeterinario(int idVeterinario) {
           var veterinario = repositorioVeterinario.ObtenerVeterinario(idVeterinario);
           Console.WriteLine("El veterinario es: " + veterinario.Nombre + " y su edad es: " +  veterinario.Edad);
        }


        private static void EliminarVeterinario(int idVeterinario) {
            repositorioVeterinario.EliminarVeterinario(idVeterinario);
        }


        private static void EditarVeterinario(){
            var veterinario = new Veterinario 
            {
                Id = 2,
                Nombre = "Juan Suarez",
                Telefono = "8965",
                Edad = 20,
                Direccion = "calle 11",
                Correo=" juan@gmail.com",
                Contrasenia = "sakaFDkd@$",
                Especializacion = "Veterinario felino",
                TarjetaProfesional = "123647",
                FechaNacimiento = new DateTime(1985, 03, 15)
            };       

            repositorioVeterinario.EditarVeterinario(veterinario);
        }



    }
}
