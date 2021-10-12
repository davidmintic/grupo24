using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.App.Persistencia;
using Veterinaria.App.Dominio;

namespace Veterinaria.App.Presentacion
{
    public class AdminMascotaModel : PageModel
    {
       
        private RepositorioCuidador repositorioCuidador = new RepositorioCuidador(new Persistencia.AppContext());
        private IRepositorioGenerico repositorioVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());

        public String titulo {get; set; } =  "Bienvenido al administrador de cuidadores";
        public Cuidador cuidadorActual;
        public Mascota mascotaActual;
        public String modoPage = "adicion";

        public IEnumerable<Veterinario> listaVeterinarios;

        public void OnGet(int idCuidador)
        {

           this.listaVeterinarios = (IEnumerable <Veterinario>)repositorioVeterinario.ObtenerTodosLosRegistros();

            if(idCuidador > 0) {
                // this.modoPage = "edicion";
                this.cuidadorActual = this.repositorioCuidador.ObtenerCuidadorConMascotas(idCuidador);
            } else {
                // this.modoPage = "adicion";
            }

            this.ActualizarInformacion();

        }

        public void OnPostAdd(Cuidador cuidador){
            this.repositorioCuidador.Agregar(cuidador);
             this.ActualizarInformacion();
        }

         public void OnPostDel(int idCuidador){

            // repositorioCuidador.Eliminar(idCuidador);
             this.ActualizarInformacion();
        }

         public void OnPostEdit(Cuidador cuidador){

            // repositorioCuidador.Editar(cuidador);
            this.ActualizarInformacion();
        }

        public void ActualizarInformacion(){
            //  this.listaCuidadores = (IEnumerable <Cuidador>)this.repositorioCuidador.ObtenerTodosLosRegistros();
            //  this.cuidadorActual = this.repositorioCuidador.ObtenerCuidadorConMascotas(idCuidador);
        }
    }
}
