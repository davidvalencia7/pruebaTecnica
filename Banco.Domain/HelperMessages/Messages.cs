using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.HelperMessages
{
    public static class Messages
    {
        public const string Success = "El registro se guardo correctamente";
        public const string Delete = "El registro se elimino correctamente";
        public const string TransaccionError = "Surgio un error interno al estar guardando";
        public const string NotFound = "El registro no se encontro";
    }
}
