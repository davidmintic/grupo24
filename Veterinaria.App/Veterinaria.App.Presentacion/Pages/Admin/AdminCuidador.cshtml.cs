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
        
        private static IRepositorioGenerico repositorioCuidador = new RepositorioCuidador(new Persistencia.AppContext());

        public String titulo {get; set; } =  "Mascotas";
        // public List <Cuidador> listaCuidadores = new List<Cuidador>();
        public IEnumerable <Cuidador> listaCuidadores;

        public Cuidador cuidadorActual;
        public String modoPage = "adicion";

        public void OnGet(int idCuidador)
        {

            if(idCuidador > 0) {
                this.modoPage = "edicion";
                this.cuidadorActual = (Cuidador)repositorioCuidador.ObtenerRegistro(idCuidador);
                this.titulo = "Mascotas de " + this.cuidadorActual.Nombre;
            } else {
                this.modoPage = "adicion";
            }

            this.ActualizarInformacion();

        }

        public void OnPostAdd(Cuidador cuidador){
            repositorioCuidador.Agregar(cuidador);
             this.ActualizarInformacion();
        }

         public void OnPostDel(int idCuidador){

            repositorioCuidador.Eliminar(idCuidador);
             this.ActualizarInformacion();
        }

         public void OnPostEdit(Cuidador cuidador){

            repositorioCuidador.Editar(cuidador);
            this.ActualizarInformacion();
        }

        public void ActualizarInformacion(){
             this.listaCuidadores = (IEnumerable <Cuidador>)repositorioCuidador.ObtenerTodosLosRegistros();
        }
    }
}
