using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface ICityService
    {

        
        public Task<List<City>> GetAllCitiesAsync();

        public Task<List<City>> GetCityByRoute(int countryId);

        public Task<IEnumerable<City>> GetCitiesById(int id);

        public Task<ActionResult<City>> AddCity(City city);

        public Task<ActionResult<City>> UpdateCity(int  id, City city);

        public Task<ActionResult<City>> DeleteCity(int id);

    }
}
