using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organizador.API.Data;
using Organizador.API.Models;

namespace Organizador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : HomeController
    {
        private DataContext _dataContext;

        public void PessoasController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("api/getProjeto")]
        public ActionResult<IEnumerable<Projeto>> GetProjeto()
        {
            _dataContext = new DataContext();

            var data = _dataContext.GetProjeto();

            return data.ToList();
        }

         [HttpPost("api/createProjeto")]
        public async Task<ActionResult> Cadastro([FromBody]Projeto projeto)
        {
            _dataContext = new DataContext();

            _dataContext.Projeto.Add(projeto);
            await _dataContext.SaveChangesAsync();

            return Created("Objeto pessoa", projeto);
        }

        [HttpPut("api/atualizaProjeto")]
        public async Task<ActionResult> Atualiza([FromBody] Projeto projeto)
        {
            _dataContext = new DataContext();

            if (projeto == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Projeto.Update(projeto);
            await _dataContext.SaveChangesAsync();

            return Ok("Updated!");
        }

         [HttpDelete("api/deleteProjeto")]
        public async Task<ActionResult> Delete([FromBody] Projeto projeto)
        {
            _dataContext = new DataContext();

            if(projeto == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Projeto.Remove(projeto);
            await _dataContext.SaveChangesAsync();

            return Ok("Deleted!");

        }
    }
}