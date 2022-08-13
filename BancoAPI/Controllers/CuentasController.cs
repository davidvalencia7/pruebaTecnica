using Banco.Domain.DTOs;
using Banco.Domain.Models;
using Banco.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {


        private readonly ICuentaService CuentaService;
        public CuentasController(ICuentaService Cuenta)
        {
            this.CuentaService = Cuenta;
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var data = await CuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");
            return Ok(data);
        }

        // POST api/<CuentaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cuenta Cuenta)
        {
            var resp = await CuentaService.Add(Cuenta);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cuenta Cuenta)
        {
            var data = await CuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await CuentaService.Update(id, Cuenta);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await CuentaService.Get(id);
            if (data == null)
                return NotFound("Registro no encontrado");

            var resp = await CuentaService.Delete(id);
            if (resp.respuesta)
                return Ok(resp);
            else
                return BadRequest(resp);
        }

        [HttpGet("reportes")]
        public async Task<ActionResult<List<Reporte>>> Reporte([FromQuery] int cliente_id,[FromQuery] DateTime? fechaIni, DateTime? fechaFin)
        {
            if(fechaIni == null || fechaFin == null)
                return BadRequest("fechas son requeridas");

            var resp = await CuentaService.GetReporte(cliente_id,fechaIni.Value.ToString("yyyyMMdd"),fechaFin.Value.ToString("yyyyMMdd"));
            return resp;
        }

    }
}
