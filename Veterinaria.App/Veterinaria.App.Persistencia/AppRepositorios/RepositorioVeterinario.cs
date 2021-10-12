using System;
using Veterinaria.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Veterinaria.App.Persistencia
{
    public class RepositorioVeterinario :  IRepositorioGenerico
    {
        private readonly AppContext appContext;

        
        public RepositorioVeterinario(AppContext appContext){
            this.appContext = appContext;
        }

        Object IRepositorioGenerico.Agregar(Object nuevoRegistro){
            
            // veterinario.FechaRegistro = DateTime.Now;
            
            Veterinario nuevoVeterinario = (Veterinario) nuevoRegistro;
            var veterinarioAdicionado = this.appContext.Veterinarios.Add(nuevoVeterinario);
            this.appContext.SaveChanges();
            return  null;
        }


        Object IRepositorioGenerico.Editar(Object nuevoRegistro){

            Veterinario nuevoVeterinario = (Veterinario) nuevoRegistro;

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

        void IRepositorioGenerico.Eliminar(int idVeterinario){
            var veterinarioEncontrado =  this.appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
            if(veterinarioEncontrado != null) {
                this.appContext.Veterinarios.Remove(veterinarioEncontrado);
                this.appContext.SaveChanges();
            }
        }

        Object IRepositorioGenerico.ObtenerRegistro(int idVeterinario){
            return this.appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
        }

        IEnumerable <Object> IRepositorioGenerico.ObtenerTodosLosRegistros(){
            return this.appContext.Veterinarios;
        }
            

    }
}