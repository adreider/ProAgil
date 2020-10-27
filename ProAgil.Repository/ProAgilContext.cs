using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entidades;

namespace ProAgil.Repository.Data
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options)
        {}

        public DbSet<Evento> Enventos {get; set;}
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSocials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new { PE.EventoId, PE.PalestranteId});
        }
        
    }
}