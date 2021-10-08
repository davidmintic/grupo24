using System;
using Veterinaria.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Veterinaria.App.Persistencia
{
    public class RepositorioVeterinario :  IRepositorioVeterinario
    {
        private readonly AppContext appContext;

        
        public RepositorioVeterinario(AppContext appContext){
            this.appContext = appContext;
        }



        Veterinario IRepositorioVeterinario.AgregarVeterinario(Veterinario veterinario){
            var veterinarioAdicionado = this.appContext.Veterinarios.Add(veterinario);
            this.appContext.SaveChanges();
            return  null;
        }


        Veterinario IRepositorioVeterinario.EditarVeterinario(Veterinario nuevoVeterinario){

            var veterinarioEncontrado =  this.appContext.Veterinarios.FirstOrDefault(p => p.Id == nuevoVeterinario.Id);

            if(veterinarioEncontrado != null) {                
                veterinarioEncontrado.Nombre = nuevoVeterinario.Nombre;
                veterinarioEncontrado.Telefono = nuevoVeterinario.Telefono;
                veterinarioEncontrado.Edad = nuevoVeterinario.Edad;
                veterinarioEncontrado.Direccion = nuevoVeterinario.Direccion;
                veterinarioEncontrado.Correo = nuevoVeterinario.Correo;
                veterinarioEncontrado.Especializacion = nuevoVeterinario.Especializacion;
                veterinarioEncontrado.TarjetaProfesional = nuevoVeterinario.TarjetaProfesional;                         
                this.appContext.SaveChanges();
            }

            return veterinarioEncontrado;
        }

        void IRepositorioVeterinario.EliminarVeterinario(int idVeterinario){
                var veterinarioEncontrado =  this.appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
                if(veterinarioEncontrado != null) {
                    this.appContext.Veterinarios.Remove(veterinarioEncontrado);
                    this.appContext.SaveChanges();
                }
        }

        Veterinario IRepositorioVeterinario.ObtenerVeterinario(int idVeterinario){
            return this.appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
        }

        IEnumerable <Veterinario> IRepositorioVeterinario.ObtenerTodosLosVeterinarios(){
            return this.appContext.Veterinarios;
        }
            

    }
}