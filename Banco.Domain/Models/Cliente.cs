using Banco.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Models
{
    public class Cliente : IPersona
    {
        public int id { get; set ; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int genero_id { get; set; }
        //public Genero Genero { get; set; }
        public byte? edad { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string identificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string password { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
