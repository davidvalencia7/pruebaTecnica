using Banco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Persistance.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext() { }
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("defaultConnection");
            }
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
    }
}
