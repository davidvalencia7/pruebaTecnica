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
    public class CuentaService : ICuentaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CuentaService() { }
        public CuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task<Cuenta> Get(int id)
        {
            return _unitOfWork.CuentaRepository.Get(id);
        }
        public Task<Respuesta> Add(Cuenta model)
        {
            return _unitOfWork.CuentaRepository.Add(model);
        }

        public Task<Respuesta> Update(int id, Cuenta model)
        {
            return _unitOfWork.CuentaRepository.Update(id, model);
        }

        public Task<Respuesta> Delete(int id)
        {
            return _unitOfWork.CuentaRepository.Delete(id);
        }


        Task<List<Reporte>> ICuentaService.GetReporte(int id_user, string fechaIni, string fechaFin)
        {
            return _unitOfWork.CuentaRepository.GetReporte(id_user, fechaIni, fechaFin);
        }
    }
}
