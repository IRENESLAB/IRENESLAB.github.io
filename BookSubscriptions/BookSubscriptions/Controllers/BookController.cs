using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.SqlClient;
using System.Net.Http;
using System.Configuration;
using Entities;
using Entities.Models;

namespace BookSubscriptions.Controllers
{ 
    public class BookController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Get_All);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        [Route("api/Book/GetAllBooks")]
        [HttpGet]
        public HttpResponseMessage GetAllBooks()
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Select_All);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        public string Post(BookModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Insert, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Name, Value = book.Name }, new SqlParameter() { ParameterName = Constants.Text, Value = book.Text }, new SqlParameter() { ParameterName = Constants.PurchasePrice, Value = book.PurchasePrice }});
                return string.Format(Constants.Insert, Constants.Successful);
            }
            catch (Exception ex)
            {
                return string.Format(Constants.Insert, string.Concat(Constants.Failed ,  ex.Message));
            }
        }
        [HttpPut]
        public string Put(BookModel book)
        {
            try
            {
                DataTable dt = ConnectAndGetData.Execute(Constants.sp_Book_Update, new SqlParameter[] { new SqlParameter() { ParameterName = Constants.Id, Value = book.Id }, new SqlParameter() { ParameterName = Constants.Name, Value = book.Name }, new SqlParameter() { ParameterName = Constants.Text, Value = book.Text }, new SqlParameter() { ParameterName = Constants.PurchasePrice, Value = book.PurchasePrice }});
                return string.Format(Constants.Update, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Update, Constants.Failed);
            }
        }
        [HttpDelete]
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
        [Route("api/Book/SaveImage")]
        [HttpPost]
        public string SaveImage()
        {
            string fileName = string.Empty;

            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Images/" + fileName);
                postedFile.SaveAs(physicalPath);
                return string.Format(Constants.Upload, fileName, Constants.Successful);
            }
            catch
            {
                return string.Format(Constants.Upload, fileName, Constants.Failed);
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
