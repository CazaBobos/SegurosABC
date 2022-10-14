using SegurosABC.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosABC.Service
{
    public interface IQueryExecutor
    {
        List<Cliente> ConsultaPagosCliente(string cedula);
    }
}