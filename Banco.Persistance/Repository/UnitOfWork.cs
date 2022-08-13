using Banco.Domain.Interfaces;
using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using Banco.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly BancoContext _context;
		private IBancoRepository<Genero> _genero;
		private IBancoRepository<Cliente> _cliente;
		private IBancoRepository<Cuenta> _cuenta;
		private IBancoRepository<TipoCuenta> _tipocuenta;
		private IBancoRepository<Movimiento> _movimiento;
		private IBancoRepository<TipoMovimiento> _tipomovimiento;

		public UnitOfWork(BancoContext context)
		{
			_context = context;
		}

		public IBancoRepository<Genero> GeneroRepository
		{
			get { return _genero ??= new GeneroRepository(_context); }
		}

		public IBancoRepository<Cliente> ClienteRepository
		{
			get { return _cliente ??= new ClienteRepository(_context); }
		}

		public IBancoRepository<Cuenta> CuentaRepository
		{
			get { return _cuenta ??= new CuentaRepository(_context); }
		}

		public IBancoRepository<TipoCuenta> TipoCuentaRepository
		{
			get { return _tipocuenta ??= new TipoCuentaRepository(_context); }
		}

		public IBancoRepository<Movimiento> MovimientoRepository
		{
			get { return _movimiento ??= new MovimientoRepository(_context); }
		}

		public IBancoRepository<TipoMovimiento> TipoMovimientoRepository
		{
			get { return _tipomovimiento ??= new TipoMovimientoRepository(_context); }
		}
		public void Dispose()
		{
			_context.Dispose();
		}
	}
}

