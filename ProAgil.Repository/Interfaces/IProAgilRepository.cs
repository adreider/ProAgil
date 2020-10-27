using System.Threading.Tasks;
using ProAgil.Domain.Entidades;

namespace ProAgil.Repository.Interfaces
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         Task<bool> SaveChangeAsync();
         
         //Eventos
         Task<Evento[]> GetAllEventoAsynByTema(string tema, bool includePalestrantes);  
         Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);   
         Task<Evento> GetEventoAsynById(int EventoID, bool includePalestrantes);   

         //Palestrante
         Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos);   
         Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos);
    }
}