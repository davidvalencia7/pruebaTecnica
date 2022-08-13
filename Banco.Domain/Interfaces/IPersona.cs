using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Interfaces
{
    public interface IPersona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int genero_id { get; set; }
        public byte? edad { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
