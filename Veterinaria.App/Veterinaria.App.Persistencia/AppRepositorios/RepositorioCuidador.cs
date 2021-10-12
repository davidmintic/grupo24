using System;
using Veterinaria.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia
{
    public class RepositorioCuidador: IRepositorioGenerico
    {
        private readonly AppContext appContext;

        
        public RepositorioCuidador(AppContext appContext){
            this.appContext = appContext;
        }

        public Object Agregar(Object nuevoRegistro){
            
            // veterinario.FechaRegistro = DateTime.Now;
            
            Cuidador nuevo = (Cuidador) nuevoRegistro;
            var cuidadorAdicionado = this.appContext.Cuidadores.Add(nuevo);
            this.appContext.SaveChanges();
            return  null;
        }


        public Object Editar(Object nuevoRegistro){

            Cuidador nuevo = (Cuidador) nuevoRegistro;

            var cuidadorEncontrado =  this.appContext.Cuidadores.FirstOrDefault(p => p.Id == nuevo.Id);

            if(cuidadorEncontrado != null) {                
                cuidadorEncontrado.Nombre = nuevo.Nombre;
                cuidadorEncontrado.Telefono = nuevo.Telefono;
                cuidadorEncontrado.Edad = nuevo.Edad;
                cuidadorEncontrado.Direccion = nuevo.Direccion;
                cuidadorEncontrado.Correo = nuevo.Correo;                      
                this.appContext.SaveChanges();
            }

            return cuidadorEncontrado;
        }

        public void Eliminar(int id){
            var cuidadorEncontrado =  this.appContext.Cuidadores.FirstOrDefault(p => p.Id == id);
            if(cuidadorEncontrado != null) {
                this.appContext.Cuidadores.Remove(cuidadorEncontrado);
                this.appContext.SaveChanges();
            }
        }

        public Object ObtenerRegistro(int id){
            return this.appContext.Cuidadores.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable <Object> ObtenerTodosLosRegistros(){
            return this.appContext.Cuidadores;
        }

        public Cuidador ObtenerCuidadorConMascotas(int idCuidador){            
            var registroEncontrado =  this.appContext.Cuidadores.Include("Mascotas").FirstOrDefault(p => p.Id == idCuidador);
            return registroEncontrado;
        }
            

    }
}