using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBancoRepository<Genero> GeneroRepository { get; }
        public IBancoRepository<Cliente> ClienteRepository { get; }
        public IBancoRepository<Cuenta> CuentaRepository { get; }
        public IBancoRepository<TipoCuenta> TipoCuentaRepository { get; }
        public IBancoRepository<Movimiento> MovimientoRepository { get; }
        public IBancoRepository<TipoMovimiento> TipoMovimientoRepository { get; }
    }
}
