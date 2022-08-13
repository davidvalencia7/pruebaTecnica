using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface IMovimientoService
    {
        Task<Movimiento> Get(int id);
        Task<Respuesta> Add(Movimiento model);
        Task<Respuesta> Update(int id, Movimiento model);
        Task<Respuesta> Delete(int id);
    }
}
