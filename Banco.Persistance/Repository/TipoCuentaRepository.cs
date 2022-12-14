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
    public class TipoCuentaRepository : IBancoRepository<TipoCuenta>
    {
        private readonly BancoContext _context;
        private Respuesta _resp;
        public TipoCuentaRepository() { }

        public TipoCuentaRepository(BancoContext context)
        {
            _context = context;
            _resp = new Respuesta();
        }

        public async Task<TipoCuenta> Get(int id)
        {
            TipoCuenta data = await _context.TipoCuenta.FirstOrDefaultAsync(x => x.id == id);
            return data;
        }
        public async Task<Respuesta> Add(TipoCuenta model)
        {
            _resp = await ExecuteQuery(1, 0, model);

            return _resp;
        }

        public async Task<Respuesta> Update(int id, TipoCuenta model)
        {
            _resp = await ExecuteQuery(2, id, model);
            return _resp;
        }

        public async Task<Respuesta> Delete(int id)
        {
            _resp = await ExecuteQuery(3, id, new TipoCuenta());
            return _resp;
        }

        private async Task<Respuesta> ExecuteQuery(int accion, int id, TipoCuenta model)
        {
            string query = "EXEC dbo.spMantenimientoTipoCuenta @movimiento, @id, @descripcion, @RetVal, @ErrorMessage";
            var movimiento = new SqlParameter("movimiento", accion);
            var _id = new SqlParameter("id", id);
            var descripcion = new SqlParameter("descripcion", model.descripcion != null ? model.descripcion : DBNull.Value);
            var retVal = new SqlParameter("RetVal", 0);
            retVal.Direction = ParameterDirection.Output;
            var message = new SqlParameter("ErrorMessage", "");
            message.Direction = ParameterDirection.Output;

            try
            {
                var response = await _context.Database.ExecuteSqlRawAsync(query, new[] { movimiento, _id, descripcion, retVal, message });
                if (response == 1 && (accion == 1 || accion == 2) )
                {
                    _resp.respuesta = true;
                    _resp.message = Messages.Success;
                }
                else if (response == 0)
                    _resp.message = Messages.TransaccionError;
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
