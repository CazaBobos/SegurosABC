using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosABC.Types
{
    public class Cliente
    {
        public string NombreCompleto { get; set; } = null;
        public string Cedula { get; set; } = null;
        public string PIN { get; set; } = null;
        public List<Pago> Pagos { get; set; } = new List<Pago>();
    }
}