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
    public class AdminCuidadorModel : PageModel
    {
        
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        public String titulo {get; set; } =  "Bienvenido al administrador de cuidadores";
        // public List <Veterinario> listaVeterinarios = new List<Veterinario>();
        public IEnumerable <Veterinario> listaVeterinarios;

        public Veterinario veterinarioActual;
        public String modoPage = "adicion";

        public void OnGet(int idVeterinario)
        {

            if(idVeterinario > 0) {
                this.modoPage = "edicion";
                this.veterinarioActual = repositorioVeterinario.ObtenerVeterinario(idVeterinario);
            } else {
                this.modoPage = "adicion";
            }

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
