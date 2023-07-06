using BackendOfficeProject.Context;
using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICityService _cityService;


        public CityController(ICityService cityService)
        {
           
            _cityService = cityService;

        }


        [HttpGet("country/{countryId:int}")]
        [ProducesResponseType(statusCode: 200)]
        public Task<List<City>> GetCityByRoute(int countryId)
        {
            var response = _cityService.GetCityByRoute(countryId);
            return response;
        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        public Task<List<City>> GetAllCities()
        {
            var response = _cityService.GetAllCitiesAsync();
            return response;
        }

       



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<City>> GetCityById(int id)
        {
            return _cityService.GetCitiesById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<City>> DeleteCityById(int id)
        {
            return _cityService.DeleteCity(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<City>> UpdateCountryById(int id, [FromBody] City city)
        {

            return _cityService.UpdateCity(id , city);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ActionResult<City>> AddCity([FromBody] City city)
        {

            return _cityService.AddCity(city);
        }


    }
}
