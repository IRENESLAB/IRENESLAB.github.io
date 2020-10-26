using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Linq;
using System.Net;
using System.Web.Http;
using Entities;
using Entities.Models;
using System.Data.SqlClient;
using System.Net.Http;
using System.Configuration;

namespace BookSubscriptions.Controllers
{
    public class BookSubscriptionController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = ConnectAndGetData.Execute(Constants.sp_UserBook_Get_All);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        [Route("api/Book/GetAllUserSubscriptions")]
        [HttpGet]
        public HttpResponseMessage GetAllUserSubscriptions(UserModel user)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_UserBook_Get_By_UserId, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.UserId, Value = user.Id } });
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public string Post(BookSubscriptionModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_UserBook_Insert, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.UserId, Value = book.UserId }, new SqlParameter() { ParameterName = Constants.BookId, Value = book.BookId }, new SqlParameter() { ParameterName = Constants.CreatedBy} });
                return string.Format(Constants.Insert, Constants.Successful);
            }
            catch 
            {
                return string.Format(Constants.Insert, Constants.Failed);
            }
        }

        public string Put(BookSubscriptionModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Update, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = book.Id },  new SqlParameter() { ParameterName = Constants.IsActive, Value = book.IsActive } });
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
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Delete, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = id }, new SqlParameter() { ParameterName = Constants.UpdatedBy, Value = 0 } });
                return string.Format(Constants.Delete, Constants.Successful);
            }
            catch (Exception ex)
            {
                return string.Format(Constants.Delete, string.Format(Constants.Failed_0, ex.Message)); ;
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
