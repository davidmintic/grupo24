using System;
namespace Veterinaria.App.Dominio
{
    public class Mascota
    {
        public int Id { get; set; }
        public String raza{get; set;}
        public String nombre{get; set;}
        public String fechaNacimiento{get; set;}
        public Cuidador Cuidador{get; set;}
    }
}