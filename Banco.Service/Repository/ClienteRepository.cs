using Banco.Domain.DTOs;
using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using Banco.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Persistance
{
    public class ClienteRepository : IBancoRepository<Cliente>
    {
        private  BancoContext context_ { get; }

        public ClienteRepository( BancoContext context)
        {
            this.context_ = context;
        }


        public Task<Respuesta> Get(int id)
        {
            context_.Database.(
    "GetLecturasEnRangoDeFechas @fecha, @idParteMaquina, @inicio, @inicioMasDuracion, @dia",
    new SqlParameter("@fecha", fecha),
    new SqlParameter("@idParteMaquina", partemaquina.Id),
    new SqlParameter("@inicio", inicio.TotalSeconds),
    new SqlParameter("@inicioMasDuracion", inicioMasDuracion.TotalSeconds),
    new SqlParameter("@dia", dia));
        }
        public Task<Respuesta> Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> Update(int id, Cliente item)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
