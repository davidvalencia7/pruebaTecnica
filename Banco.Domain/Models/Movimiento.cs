using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Models
{
    public class Movimiento
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public decimal valor { get; set; }
        public decimal? saldo { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int tipo_movimiento_id { get; set; }
        //public TipoMovimiento TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int cuenta_id { get; set; }
        //public Cuenta Cuenta { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
