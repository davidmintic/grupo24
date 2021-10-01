using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia
{
    public class AppContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = VeterinariaG24");
            }

        }
        
    }
}