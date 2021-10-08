using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.App.Persistencia;
using Veterinaria.App.Dominio;

namespace Veterinaria.App.Presentacion.Pages
{
    public class AdminVeterinarioModel : PageModel
    {

        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        public String titulo {get; set; }
        // public List <Veterinario> listaVeterinarios = new List<Veterinario>();
        public IEnumerable <Veterinario> listaVeterinarios;


        public void OnGet()
        {
           this.titulo = "Bienvenidos estimados estudiantes";
           this.listaVeterinarios = repositorioVeterinario.ObtenerTodosLosVeterinarios();
        }

        public void OnPostAdd(Veterinario vetetinario){
            repositorioVeterinario.AgregarVeterinario(vetetinario);
            this.listaVeterinarios = repositorioVeterinario.ObtenerTodosLosVeterinarios();
        }

         public void OnPostDel(int idVeterinario){

            repositorioVeterinario.EliminarVeterinario(idVeterinario);
            this.listaVeterinarios = repositorioVeterinario.ObtenerTodosLosVeterinarios();
        }

         public void OnPostEdit(Veterinario vetetinario){

            repositorioVeterinario.EditarVeterinario(vetetinario);
            this.listaVeterinarios = repositorioVeterinario.ObtenerTodosLosVeterinarios();
        }
    }

}





// listaVeterinarios.AddRange(new List<Veterinario>
                // {
                //     new Veterinario {
                //         Nombre = "Julian", Telefono = "310", Edad="21", Direccion = "calle 50", Correo = " juli@gmail.com", 
                //     },  
                //     new Veterinario {
                //         Nombre = "Paula", Telefono = "311", Edad="19", Direccion = "calle 49", Correo = " pau@gmail.com", 
                //     },
                //     new Veterinario {
                //         Nombre = "Digna", Telefono = "314", Edad="23", Direccion = "calle 48", Correo = " digna@gmail.com", 
                //     }
                // });   