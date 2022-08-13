using Banco.Domain.Interfaces;
using Banco.Domain.Models;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {

        private readonly IGeneroService generoService;
        public GeneroController(IGeneroService genero)
        {
            this.generoService = genero;
        }

        // GET api/<GeneroController>/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult> Get(int id)
        {
            var data = await generoService.Get(id);
            if(data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<GeneroController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            var resp = await generoService.Add(genero);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<GeneroController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Genero genero)
        {
            var data = await generoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await generoService.Update(id,genero);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<GeneroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await generoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await generoService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}
