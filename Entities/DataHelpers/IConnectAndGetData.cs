using System;
using System.Data;
using System.Data.SqlClient;

namespace Entities
{
	public interface IConnectAndGetData
	{
        DataTable Execute(string sqlStatement);

        DataTable Execute(string procedure, SqlParameter[] parameters);
        DataSet DatasetExecute(string procedure);
        void Execute(String procedure, SqlParameter[] parameters, out int id);
        DataSet DatasetExecute(string procedure, SqlParameter[] parameters);

        void Execute(String procedure, SqlParameter[] parameters, out string id);
       
    }
}