using Banco.Domain.Models;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {

        private readonly IMovimientoService MovimientoService;
        public MovimientosController(IMovimientoService Movimiento)
        {
            this.MovimientoService = Movimiento;
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var data = await MovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Movimiento Movimiento)
        {
            var resp = await MovimientoService.Add(Movimiento);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Movimiento Movimiento)
        {
            var data = await MovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await MovimientoService.Update(id, Movimiento);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await MovimientoService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await MovimientoService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }
    }
}
