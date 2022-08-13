using Banco.Domain.DTOs;
using Banco.Domain.Interfaces;
using Banco.Domain.Models;
using Banco.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Services.Implementations
{
    public class GeneroService : IGeneroService
    {
        private readonly IUnitOfWork _unitOfWork;   

        public GeneroService() { }
        public GeneroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<Genero> Get(int id)
        {
            return _unitOfWork.GeneroRepository.Get(id);
        }
        public Task<Respuesta> Add(Genero model)
        {
            return _unitOfWork.GeneroRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, Genero model)
        {
            return _unitOfWork.GeneroRepository.Update(id,model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.GeneroRepository.Delete(id);
        }

    }
}
