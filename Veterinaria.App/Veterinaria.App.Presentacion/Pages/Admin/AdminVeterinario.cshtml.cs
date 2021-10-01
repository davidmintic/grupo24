using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Veterinaria.App.Presentacion.Pages
{
    public class AdminVeterinarioModel : PageModel
    {


        public String titulo {get; set; }

        public void OnGet()
        {

            // this.titulo = "Bienvenido al administrador de veterinarios.";
            this.titulo = "Bienvenidos estimados estudiantes";
        }
    }
}
