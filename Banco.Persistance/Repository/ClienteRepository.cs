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

namespace Banco.Persistance
{
    public class ClienteRepository : IBancoRepository<Cliente>
    {
        private readonly BancoContext _context;
        private Respuesta _resp;
        public ClienteRepository() { }

        public ClienteRepository(BancoContext context)
        {
            _context = context;
            _resp = new Respuesta();
        }

        public async Task<Cliente> Get(int id)
        {
            Cliente data = await _context.Cliente.FirstOrDefaultAsync(x => x.id == id);
            return data;
        }
        public async Task<Respuesta> Add(Cliente model)
        {
            _resp = await ExecuteQuery(1, 0, model);

            return _resp;
        }

        public async Task<Respuesta> Update(int id, Cliente model)
        {
            _resp = await ExecuteQuery(2, id, model);
            return _resp;
        }

        public async Task<Respuesta> Delete(int id)
        {
            _resp = await ExecuteQuery(3, id, new Cliente());
            return _resp;
        }

        private async Task<Respuesta> ExecuteQuery(int accion, int id, Cliente model)
        {
            string query = "EXEC dbo.spMantenimientoCliente @movimiento,@id,@nombre,@edad,@identificacion,@direccion,@telefono,@password,@genero_id, @RetVal OUTPUT, @ErrorMessage OUTPUT";
            var movimiento = new SqlParameter("movimiento", accion);
            var _id = new SqlParameter("id", id);
            var nombre = new SqlParameter("nombre", model.nombre != null ? model.nombre  : DBNull.Value);
            var edad = new SqlParameter("edad", model.edad != null ? model.edad : DBNull.Value);
            var identificacion = new SqlParameter("identificacion", model.identificacion != null ? model.identificacion : DBNull.Value);
            var direccion = new SqlParameter("direccion", model.direccion != null ? model.direccion : DBNull.Value);
            var telefono = new SqlParameter("telefono", model.telefono != null ? model.telefono : DBNull.Value);
            var password = new SqlParameter("password", model.password != null ? model.password : DBNull.Value);
            var genero_id = new SqlParameter("genero_id", model.genero_id);
            var retVal = new SqlParameter("RetVal", 0);
            retVal.Direction = ParameterDirection.Output;
            var message = new SqlParameter("ErrorMessage", "");
            message.Direction = ParameterDirection.Output;
            message.SqlDbType = SqlDbType.VarChar;
            message.Size = 255;
            SqlParameter[] parameters = new[] { movimiento, _id, nombre, edad, identificacion, direccion, telefono, password, genero_id, retVal, message };

            try
            {
                var response = await _context.Database.ExecuteSqlRawAsync(query, parameters);
                if (response == 1 && (accion == 1 || accion == 2))
                {
                    _resp.respuesta = true;
                    _resp.message = Messages.Success;
                }
                else if(response == 0)
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
