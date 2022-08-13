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
    public class MovimientoService : IMovimientoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovimientoService() { }
        public MovimientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<Movimiento> Get(int id)
        {
            return _unitOfWork.MovimientoRepository.Get(id);
        }
        public Task<Respuesta> Add(Movimiento model)
        {
            return _unitOfWork.MovimientoRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, Movimiento model)
        {
            return _unitOfWork.MovimientoRepository.Update(id, model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.MovimientoRepository.Delete(id);
        }
    }
}
