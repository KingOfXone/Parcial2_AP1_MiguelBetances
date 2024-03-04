using Parcial2_AP1_MiguelBetances.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial2_AP1_MiguelBetances.Api.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Accesorios> Accesorios { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
