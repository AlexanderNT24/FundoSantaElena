using FundoSantaElena.Models;
using Microsoft.EntityFrameworkCore;

namespace FundoSantaElena.Datos
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base (options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Animal> Animales{ get; set; }
        public DbSet<ProduccionAnimal> ProduccionAnimales { get; set; }

    }
}
