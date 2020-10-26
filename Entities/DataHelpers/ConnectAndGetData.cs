using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Entities
{
    public class ConnectAndGetData : IConnectAndGetData
    {
        protected string _connectionString = string.Empty;

        public string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
            set
            {
                this._connectionString = value;
            }
        }

        public ConnectAndGetData(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public ConnectAndGetData()
        {
        }

      
        public DataTable Execute(string procedure)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    command.ExecuteNonQuery();

                    SqlDataAdapter sqlDataAdapter = (new SqlDataAdapter(command));
                    sqlDataAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               if(connection.State == ConnectionState.Open) connection.Close();
            }
        }      
        public DataTable Execute(string procedure, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    command.ExecuteNonQuery();

                    SqlDataAdapter sqlDataAdapter = (new SqlDataAdapter(command));
                    sqlDataAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
        public DataSet DatasetExecute(string procedure, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    command.ExecuteNonQuery();

                    SqlDataAdapter sqlDataAdapter = (new SqlDataAdapter(command));
                    sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
        public DataSet DatasetExecute(string procedure)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    command.ExecuteNonQuery();

                    SqlDataAdapter sqlDataAdapter = (new SqlDataAdapter(command));
                    sqlDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
        public void Execute(String procedure, SqlParameter[] parameters, out int id)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

       
        public void Execute(String procedure, SqlParameter[] parameters, out string id)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.CommandText = procedure;
                    command.CommandTimeout = connection.ConnectionTimeout;
                    command.ExecuteNonQuery();

                    id = command.Parameters[parameters.Length - 1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

       
    }
}