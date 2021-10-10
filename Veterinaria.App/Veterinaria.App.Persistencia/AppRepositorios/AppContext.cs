using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia
{
    public class AppContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cuidador> Cuidadores { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = VeterinariaG24");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Mascota>().HasOne(x => x.Cuidador);

        }
        
    }
}