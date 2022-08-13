using Banco.Domain.Models;
using Banco.Persistance.Data;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteService ClienteService;
        public ClientesController(IClienteService Cliente)
        {
            this.ClienteService = Cliente;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var data = await ClienteService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente Cliente)
        {
            var resp = await ClienteService.Add(Cliente);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente Cliente)
        {

            var data = await ClienteService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await ClienteService.Update(id, Cliente);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await ClienteService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await ClienteService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}
