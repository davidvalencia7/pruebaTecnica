using Banco.Domain.DTOs;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Interfaces
{
    public interface IGeneroService
    {
        Task<Genero> Get(int id);
        Task<Respuesta> Add(Genero model);
        Task<Respuesta> Update(int id, Genero model);
        Task<Respuesta> Delete(int id);
    }
}
