using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Models
{
    public class Genero
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string descripcion { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
