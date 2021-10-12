using System;
using Veterinaria.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Veterinaria.App.Persistencia
{
    public interface IRepositorioGenerico
    {

        public Object Agregar(Object objeto);
        public Object Editar(Object objeto);
        public void Eliminar(int idVeterinario);
        public Object ObtenerRegistro(int idVeterinario);
        public IEnumerable <Object> ObtenerTodosLosRegistros();
         
    }
}