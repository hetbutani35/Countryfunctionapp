using System.Diagnostics.Metrics;
using System.Net;
using CountryManagement.DataAccess.Context;
using CountryManagement.Domain.Entities;
using CountryManagement.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IsolatedCountryFunction
{
    public class CRUDFunction
    {
        public readonly ILogger _logger;
        public IUnitOfWork _unitOfWork;
        public CRUDFunction(IUnitOfWork unitofwork, ILoggerFactory loggerFactory)
        {
            _unitOfWork = unitofwork;
            _logger = loggerFactory.CreateLogger<CRUDFunction>();

        }

        [Function("create")]
        public async Task<IActionResult> create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "create")] HttpRequest req,
            ILogger log)
        {
            string message = $"country created successfully, country id is 8";
            _unitOfWork.Country.Add(new Country { id = 8, countrycode = "USA", countryname = "America", createdby = 8, createddate = DateTime.UtcNow, isactive = true });
            return new OkObjectResult(message);
        }

        [Function("delete")]
        public async Task<IActionResult> delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "delete")] HttpRequest req,
            ILogger log)
        {
            _unitOfWork.Country.RemoveByID(8);
            return new OkObjectResult($"the country is deleted : 8");
        }

        [Function("list")]
        public async Task<IActionResult> list(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "list")] HttpRequest req,
            ILogger log)
        {
            var country = JsonConvert.SerializeObject(_unitOfWork.Country.GetAll());
            return new OkObjectResult(country);
        }

        [Function("read")]
        public async Task<IActionResult> read(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "read")] HttpRequest req,
            ILogger log)
        {
            var country = JsonConvert.SerializeObject(_unitOfWork.Country.GetById(1));
            return new OkObjectResult(country);
        }

        [Function("update")]
        public async Task<IActionResult> update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get","post", Route = "update")] HttpRequest req,
            ILogger log)
        {
            string message = $"country updated successfully 2";
            _unitOfWork.Country.Update(new Country { id = 2, countrycode = "NZ", countryname = "New Zeland", createdby = 5, createddate = DateTime.UtcNow, isactive = true });
            return new OkObjectResult(message);
        }
    }
}
