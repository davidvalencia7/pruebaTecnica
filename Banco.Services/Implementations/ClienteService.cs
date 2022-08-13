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
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService() { }
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<Cliente> Get(int id)
        {
            return _unitOfWork.ClienteRepository.Get(id);
        }
        public Task<Respuesta> Add(Cliente model)
        {
            return _unitOfWork.ClienteRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, Cliente model)
        {
            return _unitOfWork.ClienteRepository.Update(id, model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.ClienteRepository.Delete(id);
        }
    }
}
