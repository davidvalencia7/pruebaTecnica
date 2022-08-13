using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Models
{
    public class Reporte
    {
        public DateTime fecha { get; set; }
        [Key]
        public int cliente_id { get; set; }
        public string cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
