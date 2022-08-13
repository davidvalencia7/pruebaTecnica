using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.DTOs
{
    public class Respuesta
    {
        public Respuesta()
        {
            this.respuesta = false;
        }
        public bool respuesta { get; set; }
        public string message { get; set; }
    }
}
