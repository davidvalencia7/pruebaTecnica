using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Interfaces.Repository
{
    public interface IBancoRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<Respuesta> Add(T model);
        Task<Respuesta> Update(int id, T model);
        Task<Respuesta> Delete(int id);
        Task<List<Reporte>> GetReporte(int iduser, string fechaIni, string fechaFin);
    }

}
