using SegurosABC.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SegurosABC.Service
{
    public class QueryExecutor : IQueryExecutor
    {   
        public List<Cliente> ConsultaPagosCliente(string cedula)
        {
            try
            {
                var handler = new DBHandler();

                var dataTable = handler.ExecuteSP("ConsultaPagosCliente", new SqlParameter("Cedula", cedula));

                return TableToList(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Cliente> TableToList(DataTable dataTable)
        {
            try { 
                var response = new List<Cliente>();
                foreach (DataRow row in dataTable.Rows)
                {
                    var client = new Cliente
                    {
                        Cedula = row.Field<string>("Cedula"),
                        NombreCompleto = row.Field<string>("NombreCompleto"),
                    };
                    var pago = new Pago
                    {
                        FechaPago = row.Field<DateTime>("FechaPago"),
                        Monto = row.Field<decimal>("Monto")
                    };

                    if (response.FirstOrDefault(c => c.Cedula == client.Cedula) == null) response.Add(client);

                    response
                        .Where(c => c.Cedula == client.Cedula)
                        .FirstOrDefault()
                        .Pagos.Add(pago);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}