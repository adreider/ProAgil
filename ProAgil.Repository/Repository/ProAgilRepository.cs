using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entidades;
using ProAgil.Repository.Data;
using ProAgil.Repository.Interfaces;

namespace ProAgil.Repository.Repository {
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository (ProAgilContext context) {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T> (T entity) where T : class {
            _context.Add (entity);
        }

        public void Delete<T> (T entity) where T : class {
            _context.Remove (entity);
        }

        public void Update<T> (T entity) where T : class {
            _context.Set<T>().Update(entity);
        }
        public async Task<bool> SaveChangeAsync () {
            return (await _context.SaveChangesAsync ()) > 0;
        }

      
        public async Task<Evento[]> GetAllEventoAsync (bool includePalestrantes = false) {
            IQueryable<Evento> query = _context.Enventos
                .Include (c => c.Lotes)
                .Include (c => c.RedeSociais);

            if (includePalestrantes) {
                query = query
                    .Include (pe => pe.PalestrantesEventos)
                    .ThenInclude (p => p.Palestrante);
            }

            query = query.AsNoTracking ()
                .OrderByDescending (c => c.DataEvento);

            return await query.ToArrayAsync ();
        }
        public async Task<Evento[]> GetAllEventoAsynByTema (string tema, bool includePalestrantes) {
            IQueryable<Evento> query = _context.Enventos
                .Include (c => c.Lotes)
                .Include (c => c.RedeSociais);

            if (includePalestrantes) {
                query = query
                    .Include (pe => pe.PalestrantesEventos)
                    .ThenInclude (p => p.Palestrante);
            }

            query = query.AsNoTracking ()
                .OrderByDescending (c => c.DataEvento)
                .Where (c => c.Tema.Contains (tema));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsynById (int EventoID, bool includePalestrantes) {
            IQueryable<Evento> query = _context.Enventos
                .Include (c => c.Lotes)
                .Include (c => c.RedeSociais);

            if (includePalestrantes) {
                query = query
                    .Include (pe => pe.PalestrantesEventos)
                    .ThenInclude (p => p.Palestrante);
            }

            query = query.AsNoTracking ()
                .OrderByDescending (c => c.DataEvento)
                .Where (c => c.Id == EventoID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync (int PalestranteId, bool includeEventos) {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include (c => c.RedeSociais);

            if (includeEventos) {
                query = query
                    .Include (pe => pe.PalestrantesEventos)
                    .ThenInclude (p => p.Evento);
            }

            query = query.AsNoTracking ()
                .OrderBy (c => c.Nome)
                .Where (p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync ();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName (string name, bool includeEventos) {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include (c => c.RedeSociais);

            if (includeEventos) {
                query = query
                    .Include (pe => pe.PalestrantesEventos)
                    .ThenInclude (p => p.Evento);
            }

            query = query.AsNoTracking ()
                .OrderBy (c => c.Nome.ToLower ().Contains (name.ToLower ()));

            return await query.ToArrayAsync ();
        }

    }
}