using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;


        public CountryController(ICountryService countryService)
        {
            
            _countryService = countryService;

        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<Country>> GetCountries()
        {

            var response = _countryService.GetAllCountriesAsync();
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Country>> GetCountryById(int id)
        {
            return _countryService.GetTheCountriesById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Country>> DeleteCountryById(int id)
        {
            return _countryService.DeleteCountryByIdAsync(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Country>> UpdateCountryById(int id, [FromBody] Country country)
        {

            return _countryService.UpdateCountryAsync(id, country);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public  Task<ActionResult<Country>> AddCountry([FromBody] Country country)
        {
    
            return _countryService.AddCountryAsync(country);
        }


    }
}
