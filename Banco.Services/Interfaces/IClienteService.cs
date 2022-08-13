using Banco.Domain.DTOs;
using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Get(int id);
        Task<Respuesta> Add(Cliente model);
        Task<Respuesta> Update(int id, Cliente model);
        Task<Respuesta> Delete(int id);
    }
}
