using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using System.Data.SqlClient;
using Entities.Models;
using System;
using System.Configuration;

namespace UserSubscriptions.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Get_All);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(UserModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Insert, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.FirstName, Value = book.FirstName }, new SqlParameter() { ParameterName = Constants.LastName, Value = book.LastName }, new SqlParameter() { ParameterName = Constants.EmailAddress, Value = book.EmailAddress }});
                return string.Format(Constants.Insert, Constants.Successful);
            }
            catch 
            {
                return string.Format(Constants.Insert, Constants.Failed);
            }
        }

        public string Put(UserModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Update, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = book.Id }, new SqlParameter() { ParameterName = Constants.FirstName, Value = book.FirstName }, new SqlParameter() { ParameterName = Constants.LastName, Value = book.LastName }, new SqlParameter() { ParameterName = Constants.EmailAddress, Value = book.EmailAddress } });
                return string.Format(Constants.Update, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Update, Constants.Failed);
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Delete, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = id }, new SqlParameter() { ParameterName = Constants.UpdatedBy, Value = 0 } });
                return string.Format(Constants.Delete, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Delete, Constants.Failed);
            }
        }

        [Route("api/User/GetAllUsers")]
        [HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Select_All);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch(Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private IConnectAndGetData ConnectAndGetData
        {
            get
            {
                ConnectAndGetData connectAndGetData = new ConnectAndGetData(ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString());

                return connectAndGetData;
            }
        }
    }
}
