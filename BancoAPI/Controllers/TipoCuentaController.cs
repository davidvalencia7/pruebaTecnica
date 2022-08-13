using Banco.Domain.Models;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCuentaController : ControllerBase
    {
        private readonly ITipoCuentaService TipoCuentaService;
        public TipoCuentaController(ITipoCuentaService TipoCuenta)
        {
            this.TipoCuentaService = TipoCuenta;
        }

        // GET api/<TipoCuentaController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var data = await TipoCuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<TipoCuentaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoCuenta TipoCuenta)
        {
            var resp = await TipoCuentaService.Add(TipoCuenta);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<TipoCuentaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoCuenta TipoCuenta)
        {
            var data = await TipoCuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await TipoCuentaService.Update(id, TipoCuenta);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<TipoCuentaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await TipoCuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await TipoCuentaService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
            
        }
    }
}
