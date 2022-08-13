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
    public class CuentaRepository : IBancoRepository<Cuenta>
    {
        private readonly BancoContext _context;
        private Respuesta _resp;
        public CuentaRepository() { }

        public CuentaRepository(BancoContext context)
        {
            _context = context;
            _resp = new Respuesta();
        }

        public async Task<Cuenta> Get(int id)
        {
            Cuenta data = await _context.Cuenta.FirstOrDefaultAsync(x => x.id == id);
            return data;
        }
        public async Task<Respuesta> Add(Cuenta model)
        {
            _resp = await ExecuteQuery(1, 0, model);

            return _resp;
        }

        public async Task<Respuesta> Update(int id, Cuenta model)
        {
            _resp = await ExecuteQuery(2, id, model);
            return _resp;
        }

        public async Task<Respuesta> Delete(int id)
        {
            _resp = await ExecuteQuery(3, id, new Cuenta());
            return _resp;
        }

        private async Task<Respuesta> ExecuteQuery(int accion, int id, Cuenta model)
        {
            string query = "EXEC dbo.spMantenimientoCuenta @movimiento, @id, @num_cuenta,@saldo,@tipo_cuenta_id,@cliente_id, @RetVal OUTPUT, @ErrorMessage OUTPUT";
            var movimiento = new SqlParameter("movimiento", accion);
            var _id = new SqlParameter("id", id);
            var num_cuenta = new SqlParameter("num_cuenta", model.num_cuenta != null ? model.num_cuenta : DBNull.Value);
            var saldo = new SqlParameter("saldo", model.saldo);
            var tipo_cuenta_id = new SqlParameter("tipo_cuenta_id", model.tipo_cuenta_id);
            var cliente_id = new SqlParameter("cliente_id", model.cliente_id);
            var retVal = new SqlParameter("RetVal", 0);
            retVal.Direction = ParameterDirection.Output;
            var message = new SqlParameter("ErrorMessage", "");
            message.Direction = ParameterDirection.Output;
            message.SqlDbType = SqlDbType.VarChar;
            message.Size = 255;

            try
            {
                var response = await _context.Database.ExecuteSqlRawAsync(query, new[] { movimiento, _id, num_cuenta,saldo,tipo_cuenta_id,cliente_id, retVal, message });
                if (response == 1 && (accion == 1 || accion == 2))
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

        public async Task<List<Reporte>> GetReporte(int iduser, string fechaIni, string fechaFin)
        {
            string query = "EXEC dbo.spReporte @id_user, @fechaIni, @fechaFin";
            var id_user = new SqlParameter("id_user", iduser);
            id_user.SqlDbType = SqlDbType.Int;
            var _fechaIni = new SqlParameter("fechaIni", fechaIni);
            _fechaIni.SqlDbType = SqlDbType.VarChar;
            _fechaIni.Size = 20;
            var _fechaFin = new SqlParameter("fechaFin", fechaFin);
            _fechaFin.SqlDbType = SqlDbType.VarChar;
            _fechaFin.Size = 20;
            List<Reporte> data = new List<Reporte>();

            try
            {
                data = await _context.Reporte.FromSqlRaw(query, new[] { id_user, _fechaIni, _fechaFin }).ToListAsync();

            }
            catch (Exception ex)
            {
                _resp.message = Messages.TransaccionError;
            }

            return data;
        }

    }
}
