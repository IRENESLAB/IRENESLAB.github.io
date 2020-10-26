using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookSubscriptionController : ControllerBase
    {
        [Route("GetAllBookSubscriptions")]
        [HttpGet]
        public async Task<IEnumerable<BookSubscriptionModel>> GetAllBookSubscriptions()
        {
            var books_ = await _conn.QueryAsync<BookSubscriptionModel>(Constants.sp_UserBook_Get_All);
            return books_;
        }
        [Route("GetAllUserBookSubscriptions")]
        [HttpGet]
        public async Task<IEnumerable<BookSubscriptionModel>> GetAllUserBookSubscriptions(string userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add(Constants.UserId, userId); 
            var books_ = await _conn.QueryAsync<BookSubscriptionModel>(Constants.sp_UserBook_Get_By_UserId, parameters, null, 6000, System.Data.CommandType.StoredProcedure);
            return books_;
        }
        [HttpGet]
        public async Task<IEnumerable<BookSubscriptionModel>> Get()
        {
            var books_ = await _conn.QueryAsync<BookSubscriptionModel>(Constants.sp_UserBook_Get_All);
            return books_;
        }
        [HttpDelete("{id}")]
        public async Task<IEnumerable<BookSubscriptionModel>> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add(Constants.Id, id); 

            return await _conn.QueryAsync<BookSubscriptionModel>(Constants.sp_UserBook_Delete, parameters, null, 6000, System.Data.CommandType.StoredProcedure);

        }
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UserBook model)
        {
            try
            {
                await _conn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add(Constants.UserId, model.UserId);
                parameters.Add(Constants.BookId, model.BookId);
                var bookId = await _conn.ExecuteScalarAsync<int>(Constants.sp_UserBook_Insert, parameters, null, 6000, System.Data.CommandType.StoredProcedure);
              
                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UserBook model)
        {
            try
            {
                await _conn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add(Constants.Id, model.Id);
                parameters.Add(Constants.IsActive, model.IsActive);
                await _conn.ExecuteScalarAsync<int>(Constants.sp_UserBook_Update, parameters, null, 6000, System.Data.CommandType.StoredProcedure);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        private readonly IConfiguration _configuration;
        private readonly ILogger<BookSubscriptionController> _logger;
        private readonly SqlConnection _conn;
        public BookSubscriptionController(IConfiguration configuration, ILogger<BookSubscriptionController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _conn = new SqlConnection(_configuration.GetConnectionString(Constants.ConnectionString));
        }
        private IConnectAndGetData ConnectAndGetData
        {
            get
            {

                ConnectAndGetData connectAndGetData = new ConnectAndGetData(_configuration.GetConnectionString(Constants.ConnectionString));

                return connectAndGetData;
            }
        }
    }
}
