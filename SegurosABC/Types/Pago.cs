using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosABC.Types
{
    public class Pago
    {
        public string Cedula { get; set; } = null;
        public Cliente Cliente { get; set; } = null;
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; } = 0m;

    }
}