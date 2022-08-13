using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface ITipoMovimientoService
    {
        Task<TipoMovimiento> Get(int id);
        Task<Respuesta> Add(TipoMovimiento model);
        Task<Respuesta> Update(int id, TipoMovimiento model);
        Task<Respuesta> Delete(int id);
    }
}
