using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface ICuentaService
    {
        Task<Cuenta> Get(int id);
        Task<Respuesta> Add(Cuenta model);
        Task<Respuesta> Update(int id, Cuenta model);
        Task<Respuesta> Delete(int id);
        Task<List<Reporte>> GetReporte(int id_user, string fechaIni, string fechaFin);
    }
}
