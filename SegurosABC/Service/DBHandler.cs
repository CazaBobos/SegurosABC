using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SegurosABC.Service
{
    public class DBHandler
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private SqlDataAdapter Adapter;
        //Public DSet As DataSet

        public DBHandler()
        {
            var cnnStringBuilder = new SqlConnectionStringBuilder();
            cnnStringBuilder.DataSource = @"CAZABOBOSTUF\SQLEXPRESS";
            cnnStringBuilder.InitialCatalog = @"SegurosABC";
            cnnStringBuilder.IntegratedSecurity = true;
            
            Connection = new SqlConnection(cnnStringBuilder.ConnectionString);
            Command = new SqlCommand();
            Adapter = new SqlDataAdapter(Command);
        }

        public DataTable ExecuteSP(string storedProcedureName, params SqlParameter[] parameters)
        {
            try { 
                var dt = new DataTable();

                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = storedProcedureName.Trim();

                Command.Parameters.Clear();
                foreach (var parameter in parameters) 
                    Command.Parameters.Add(parameter);
                
                Adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}