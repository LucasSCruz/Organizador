using Microsoft.AspNetCore.Mvc;
using Organizador.API.Data;
using Organizador.API.Models;

namespace Organizador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : HomeController
    {
        private DataContext _dataContext;

        public void PessoasController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("api/getTarefa")]
        public ActionResult<IEnumerable<Tarefa>> GetTarefa()
        {
            _dataContext = new DataContext();

            var data = _dataContext.GetTarefa();

            return data.ToList();
        }

         [HttpPost("api/createTarefa")]
        public async Task<ActionResult> Cadastro([FromBody]Tarefa tarefa)
        {
            _dataContext = new DataContext();

            _dataContext.Tarefa.Add(tarefa);
            await _dataContext.SaveChangesAsync();

            return Created("Objeto pessoa", tarefa);
        }

        [HttpPut("api/atualizaTarefa")]
        public async Task<ActionResult> Atualiza([FromBody] Tarefa tarefa)
        {
            _dataContext = new DataContext();

            if (tarefa == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Tarefa.Update(tarefa);
            await _dataContext.SaveChangesAsync();

            return Ok("Updated!");
        }

         [HttpDelete("api/deleteTarefa")]
        public async Task<ActionResult> Delete([FromBody] Tarefa tarefa)
        {
            _dataContext = new DataContext();

            if(tarefa == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Tarefa.Remove(tarefa);
            await _dataContext.SaveChangesAsync();

            return Ok("Deleted!");

        }
    }
}