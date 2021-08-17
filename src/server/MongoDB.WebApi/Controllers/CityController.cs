using Microsoft.AspNetCore.Mvc;
using MongoDB.Business.Abstract;
using MongoDB.Entities.Concrete;

namespace MongoDB.WebApi.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) => _cityService = cityService;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cityService.GetAllCities().Result);
        }

        [HttpPost]
        public IActionResult Post(City model)
        {
            _cityService.InsertOne(model);
            return Created("", null);
        }

    }
}
