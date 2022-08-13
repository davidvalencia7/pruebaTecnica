using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Models
{
    public class Cuenta
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string num_cuenta { get; set; }
        public decimal saldo { get; set; }
        public decimal total { get; set; }
        public bool status { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int tipo_cuenta_id { get; set; }
        /// <summary>
        /// public TipoCuenta TipoCuenta { get; set; }
        /// </summary>
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int cliente_id { get; set; }
        //public Cliente Cliente { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
