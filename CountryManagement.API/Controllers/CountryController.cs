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
            _unitOfWork.Country.RemoveByID(2);

            var countryfrom = _unitOfWork.Country.GetAll();
            return Ok(countryfrom);

            
        }
    }
}
