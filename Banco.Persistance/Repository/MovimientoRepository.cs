using Banco.Domain.DTOs;
using Banco.Domain.HelperMessages;
using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using Banco.Persistance.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Persistance.Repository
{
    public class MovimientoRepository : IBancoRepository<Movimiento>
    {
        private readonly BancoContext _context;
        private Respuesta _resp;
        public MovimientoRepository() { }

        public MovimientoRepository(BancoContext context)
        {
            _context = context;
            _resp = new Respuesta();
        }

        public async Task<Movimiento> Get(int id)
        {
            Movimiento data = await _context.Movimiento.FirstOrDefaultAsync(x => x.id == id);
            return data;
        }
        public async Task<Respuesta> Add(Movimiento model)
        {
            _resp = await ExecuteQuery(1, 0, model);

            return _resp;
        }

        public async Task<Respuesta> Update(int id, Movimiento model)
        {
            _resp = await ExecuteQuery(2, id, model);
            return _resp;
        }

        public async Task<Respuesta> Delete(int id)
        {
            _resp = await ExecuteQuery(3, id, new Movimiento());
            return _resp;
        }

        private async Task<Respuesta> ExecuteQuery(int accion, int id, Movimiento model)
        {
            string query = "EXEC dbo.spMantenimientoMovimiento @movimiento, @id,@fecha,@valor,@cuenta_id,@tipo_movimiento_id, @RetVal OUTPUT, @ErrorMessage OUTPUT";
            var movimiento = new SqlParameter("movimiento", accion);
            var _id = new SqlParameter("id", id);
            var fecha = new SqlParameter("fecha", model.fecha);
            var valor = new SqlParameter("valor", model.valor);
            var cuenta_id = new SqlParameter("cuenta_id", model.cuenta_id);
            var tipo_movimiento_id = new SqlParameter("tipo_movimiento_id", model.tipo_movimiento_id);
            var retVal = new SqlParameter("RetVal", 0);
            retVal.Direction = ParameterDirection.Output;
            var message = new SqlParameter("ErrorMessage", "");
            message.Direction = ParameterDirection.Output;
            message.SqlDbType = SqlDbType.VarChar;
            message.Size = 255;
            try
            {
                var response = await _context.Database.ExecuteSqlRawAsync(query, new[] { movimiento, _id, fecha,valor,cuenta_id,tipo_movimiento_id, retVal, message });
                int result = (int)(long)retVal.Value;
                if (result == 0 && (accion == 1 || accion == 2))
                {
                    _resp.respuesta = true;
                    _resp.message = message.Value.ToString();
                }
                else if (result == -1)
                    _resp.message = message.Value.ToString();
                else
                {
                    _resp.respuesta = true;
                    _resp.message = Messages.Delete;
                }
            }
            catch (Exception ex)
            {
                _resp.message = Messages.TransaccionError;
            }

            return _resp;
        }

        public Task<List<Reporte>> GetReporte(int iduser, string fechaIni, string fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
