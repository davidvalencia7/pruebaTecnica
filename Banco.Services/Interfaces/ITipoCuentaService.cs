using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface ITipoCuentaService
    {
        Task<TipoCuenta> Get(int id);
        Task<Respuesta> Add(TipoCuenta model);
        Task<Respuesta> Update(int id, TipoCuenta model);
        Task<Respuesta> Delete(int id);
    }
}
