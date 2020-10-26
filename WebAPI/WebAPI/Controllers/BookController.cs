
using Microsoft.AspNetCore.Mvc;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Entities.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [Route("api/Book/GetAllBooks")]
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books_ = await _conn.QueryAsync<Book>(Constants.sp_Book_Get_All);
            return books_;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            var books_ = await _conn.QueryAsync<Book>(Constants.sp_Book_Get_All);
            return books_;
        }
        [Route("api/Book/GetBook")]
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBook(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add(Constants.Id, id);

            return await _conn.QueryAsync<Book>(Constants.sp_Book_Get_By_Id, parameters, null, 6000, System.Data.CommandType.StoredProcedure);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(Constants.Id, id);

                var bookId = await _conn.ExecuteScalarAsync<int>(Constants.sp_Book_Delete, parameters, null, 6000, System.Data.CommandType.StoredProcedure);

                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] BookModel model)
        {
            try
            {
                await _conn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add(Constants.Name, model.Name);
                parameters.Add(Constants.Text, model.Text);
                parameters.Add(Constants.PurchasePrice, model.PurchasePrice);
                var bookId = await _conn.ExecuteScalarAsync<int>(Constants.sp_Book_Insert, parameters, null, 6000, System.Data.CommandType.StoredProcedure);

                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookModel model)
        {
            try
            {
                await _conn.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add(Constants.Id, id);
                parameters.Add(Constants.Name, model.Name);
                parameters.Add(Constants.Text, model.Text);
                parameters.Add(Constants.PurchasePrice, model.PurchasePrice);
                var bookId = await _conn.ExecuteScalarAsync<int>(Constants.sp_Book_Update, parameters, null, 6000, System.Data.CommandType.StoredProcedure);
                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        private readonly IConfiguration _configuration;
        private readonly ILogger<BookController> _logger;
        private readonly SqlConnection _conn;
        public BookController(IConfiguration configuration, ILogger<BookController> logger)
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
