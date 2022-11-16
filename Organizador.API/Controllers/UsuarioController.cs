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
    public class UsuarioController : HomeController
    {
        private DataContext _dataContext;

        public void PessoasController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuario()
        {
            _dataContext = new DataContext();

            var data = _dataContext.GetUsuario();

            return data.ToList();
        }

         [HttpPost]
        public async Task<ActionResult> Cadastro([FromBody]Usuario usuario)
        {
            _dataContext = new DataContext();

            _dataContext.Usuario.Add(usuario);
            await _dataContext.SaveChangesAsync();

            return Created("Objeto pessoa", usuario);
        }

        [HttpPut]
        public async Task<ActionResult> Atualiza([FromBody] Usuario usuario)
        {
            _dataContext = new DataContext();

            if (usuario == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Usuario.Update(usuario);
            await _dataContext.SaveChangesAsync();

            return Ok("Updated!");
        }

         [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Usuario usuario)
        {
            _dataContext = new DataContext();

            if(usuario == null)
            {
                return BadRequest("Not found!");
            }

            _dataContext.Usuario.Remove(usuario);
            await _dataContext.SaveChangesAsync();

            return Ok("Deleted!");

        }
    }
}