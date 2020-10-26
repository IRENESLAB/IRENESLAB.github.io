using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Entities
{
    public class DapperQueryHelper 
    {
        protected string _connectionString = string.Empty;
 
        public DapperQueryHelper(string connectionString)
        {
            this._connectionString = connectionString;
        }
         
        public IEnumerable<Book> Query(string connectionString)
        {
            return null;// _connectionString.QueryAsync<Book>(Constants.sp_Book_Get_All);
        }
       
    }
}