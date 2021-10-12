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

        private static IRepositorioGenerico repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        public String titulo {get; set; } =  "Bienvenido al administrador de veterinarios";
        // public List <Veterinario> listaVeterinarios = new List<Veterinario>();
        public IEnumerable <Veterinario> listaVeterinarios;

        public Veterinario veterinarioActual;
        public String modoPage = "adicion";

        public void OnGet(int idVeterinario)
        {

            if(idVeterinario > 0) {
                this.modoPage = "edicion";
                this.veterinarioActual = (Veterinario)repositorioVeterinario.ObtenerRegistro(idVeterinario);
            } else {
                this.modoPage = "adicion";
            }

           this.ActualizarInformacion();

        }

        public void OnPostAdd(Veterinario vetetinario){
            repositorioVeterinario.Agregar(vetetinario);
            this.ActualizarInformacion();
        }

         public void OnPostDel(int idVeterinario){

            repositorioVeterinario.Eliminar(idVeterinario);
            this.ActualizarInformacion();
        }

         public void OnPostEdit(Veterinario vetetinario){

            repositorioVeterinario.Editar(vetetinario);
            this.ActualizarInformacion();
        }

           public void ActualizarInformacion(){
             this.listaVeterinarios = (IEnumerable <Veterinario>)repositorioVeterinario.ObtenerTodosLosRegistros();
        }
    }

}
