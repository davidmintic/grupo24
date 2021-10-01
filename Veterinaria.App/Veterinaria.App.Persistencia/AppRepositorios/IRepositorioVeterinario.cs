using System;
using Veterinaria.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Veterinaria.App.Persistencia
{
    public interface IRepositorioVeterinario
    {

        public Veterinario AgregarVeterinario(Veterinario veterinario);
        public Veterinario EditarVeterinario(Veterinario veterinario);
        public void EliminarVeterinario(int idVeterinario);
        public Veterinario ObtenerVeterinario(int idVeterinario);
        public IEnumerable <Veterinario> ObtenerTodosLosVeterinarios();
         
    }
}