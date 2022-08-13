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
    public class TipoMovimientoService : ITipoMovimientoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoMovimientoService() { }
        public TipoMovimientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<TipoMovimiento> Get(int id)
        {
            return _unitOfWork.TipoMovimientoRepository.Get(id);
        }
        public Task<Respuesta> Add(TipoMovimiento model)
        {
            return _unitOfWork.TipoMovimientoRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, TipoMovimiento model)
        {
            return _unitOfWork.TipoMovimientoRepository.Update(id, model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.TipoMovimientoRepository.Delete(id);
        }
    }
}
