using SegurosABC.Service;
using SegurosABC.Types;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace SegurosABC
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SOAPService : WebService
    {
        private IQueryExecutor service;
        public SOAPService() => service = new QueryExecutor();
    
        [WebMethod]
        public List<Cliente> ConsultaPagosCliente(string cedula)
        {
            try
            {
                return service.ConsultaPagosCliente(cedula); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Cliente>()
                {
                    new Cliente(){
                        Cedula="ERROR",
                        NombreCompleto="ERROR",
                        PIN="ERROR",
                        Pagos=null,
                    }
                };
            }
        }
    }
}
