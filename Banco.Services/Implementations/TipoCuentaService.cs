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
    public class TipoCuentaService : ITipoCuentaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoCuentaService() { }
        public TipoCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<TipoCuenta> Get(int id)
        {
            return _unitOfWork.TipoCuentaRepository.Get(id);
        }
        public Task<Respuesta> Add(TipoCuenta model)
        {
            return _unitOfWork.TipoCuentaRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, TipoCuenta model)
        {
            return _unitOfWork.TipoCuentaRepository.Update(id, model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.TipoCuentaRepository.Delete(id);
        }
    }
}
