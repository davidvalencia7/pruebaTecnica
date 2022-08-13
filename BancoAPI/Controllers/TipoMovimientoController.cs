using Banco.Domain.Models;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly ITipoMovimientoService TipoMovimientoService;
        public TipoMovimientoController(ITipoMovimientoService TipoMovimiento)
        {
            this.TipoMovimientoService = TipoMovimiento;
        }

        // GET api/<TipoMovimientoController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var data = await TipoMovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<TipoMovimientoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoMovimiento TipoMovimiento)
        {
            var resp = await TipoMovimientoService.Add(TipoMovimiento);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoMovimiento TipoMovimiento)
        {
            var data = await TipoMovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await TipoMovimientoService.Update(id, TipoMovimiento);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await TipoMovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await TipoMovimientoService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}
