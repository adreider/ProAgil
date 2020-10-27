using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Entidades;
using ProAgil.Repository.Interfaces;

namespace ProAgil.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase {
        private readonly IProAgilRepository repo;
        public EventoController (IProAgilRepository repo) {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try 
            {
                var results = await repo.GetAllEventoAsync(true);

                return Ok(results);
            } 
            catch (System.Exception) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEventoId (int Id) {
            try {
                var results = await repo.GetEventoAsynById(Id, true);
                return Ok (results);

            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("getByTema/{EventoId}")]
        public async Task<IActionResult> GetTema (string tema) {
            try {
                var results = await repo.GetAllEventoAsynByTema (tema, true);
                return Ok (results);

            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model) {
            try {
                repo.Add (model);

                if (await repo.SaveChangeAsync())
                {   
                    return Created($"/api/evento/{model.Id}", model);
                }

            } catch (System.Exception)
            {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model) {
            try {

                var Evento = await repo.GetEventoAsynById(EventoId, false);
                if (Evento == null) return NotFound();

                repo.Update(Evento);

                if (await repo.SaveChangeAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }
                

            } catch (System.Exception)
            {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int EventoId) {
            try {

                var evento = await repo.GetEventoAsynById(EventoId, false);
                if (evento == null) return NotFound();

                repo.Delete(evento);

                if (await repo.SaveChangeAsync())
                {
                    return Ok( );
                }
                

            } catch (System.Exception)
            {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}