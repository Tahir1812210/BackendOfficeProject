using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface ICountryService
    {

         public Task<List<Country>> GetAllCountriesAsync();

        
        public Task<IEnumerable<Country>> GetTheCountriesById(int id);
       
        public Task<ActionResult<Country>> DeleteCountryByIdAsync(int id);
        public Task<ActionResult<Country>> AddCountryAsync(Country country);
        public Task<ActionResult<Country>> UpdateCountryAsync(int id, Country country);
    }
}
