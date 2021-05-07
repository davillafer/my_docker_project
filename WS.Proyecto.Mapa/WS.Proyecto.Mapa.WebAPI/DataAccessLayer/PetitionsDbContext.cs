using WS.Proyecto.Mapa.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace WS.Proyecto.Mapa.WebAPI.DataAccessLayer
{
    public class PetitionsDbContext : DbContext
    {
        public DbSet<Petition> Petitions { get; set; }

        public PetitionsDbContext(DbContextOptions<PetitionsDbContext> options) : base(options)
        {}

  }
}