using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Veterinaria.App.Dominio;
using Veterinaria.App.Persistencia;
using Newtonsoft.Json.Linq;


namespace Veterinaria.App.Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {



         private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }


        [HttpGet]
        public IEnumerable <Veterinario> Get()
        {
            // return "Tu solicitud ha sido recibida";
            // JArray arrayResponse = new JArray();

            var veterinarios = repositorioVeterinario.ObtenerTodosLosVeterinarios();
            // var lista = veterinarios.ToList();

            // foreach (var v in lista) {
            //     JObject json =  new JObject();
            //     json["nombre"] = v.Nombre;
            //     json["edad"] = v.Edad;
            //     json["correo"] = v.Correo;
            //     arrayResponse.Add(json);
            // }

            // return arrayResponse.ToString();

            return veterinarios;
        }
    }
}
