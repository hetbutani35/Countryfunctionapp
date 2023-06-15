using CountryManagement.Domain.Entities;
using CountryManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CountryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _unitOfWork.Country.Add(new Country { id = 2, countrycode = "AUS", countryname = "Australia", createdby = 2, createddate = DateTime.UtcNow, isactive = true });
            //_unitOfWork.Country.RemoveByID(2);
            var countryfrom = _unitOfWork.Country.GetAll();
            return Ok(countryfrom);

            
        }
    }
}
