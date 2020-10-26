using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using System.Data.SqlClient;
using BookSubscriptions.Models;
using System;

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
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Insert, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.FirstName, Value = book.FirstName }, new SqlParameter() { ParameterName = Constants.LastName, Value = book.LastName }, new SqlParameter() { ParameterName = Constants.EmailAddress, Value = book.EmailAddress },  new SqlParameter() { ParameterName = Constants.CreatedBy, Value = book.CreatedBy } });
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
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Update, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = book.Id }, new SqlParameter() { ParameterName = Constants.FirstName, Value = book.FirstName }, new SqlParameter() { ParameterName = Constants.LastName, Value = book.LastName }, new SqlParameter() { ParameterName = Constants.EmailAddress, Value = book.EmailAddress }, new SqlParameter() { ParameterName = Constants.IsActive, Value = book.IsActive }, new SqlParameter() { ParameterName = Constants.IsDeleted, Value = book.IsDeleted }, new SqlParameter() { ParameterName = Constants.UpdatedBy, Value = book.UpdatedBy } });
                return string.Format(Constants.Update, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Update, Constants.Failed);
            }
        }

        public string Delete(UserModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Delete, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = book.Id }, new SqlParameter() { ParameterName = Constants.UpdatedBy, Value = book.UpdatedBy } });
                return string.Format(Constants.Delete, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Delete, Constants.Failed);
            }
        }

        [Route("api/User/GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_User_Get_All);
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
                ConnectAndGetData connectAndGetData = new ConnectAndGetData(ConfigSettings.Instance.ConnectionString);

                return connectAndGetData;
            }
        }
    }
}
