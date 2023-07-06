using BackendOfficeProject.Context;
using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BackendOfficeProject.Services
{
    public class CityService : ICityService
    {


        private readonly ApplicationDbContext _dbContext;

        private readonly InMemoryDbContext _inmemorydbcontext;

        public CityService(ApplicationDbContext dbContext , InMemoryDbContext inMemoryDbContext )
        {
            _dbContext = dbContext;
            _inmemorydbcontext = inMemoryDbContext;
            
        }
        public async Task<ActionResult<City>> AddCity(City city)
        {
            _dbContext.Cities.Add(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }

        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var showcity = await _dbContext.Cities.FindAsync(id);
            try
            {
               _dbContext.Cities.Remove(showcity);
               await _dbContext.SaveChangesAsync();
               return showcity; 
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<List<City>> GetAllCitiesAsync()
        {
            var cities = await _dbContext.Cities.Include(c => c.Country).ToListAsync();

            

            //// Manually load the related Country entity for each City
            //foreach (var city in cities)
            //{
            //    var country = await _dbContext.Countries.FindAsync(city.CountryId);
            //    city.Country = country;
            //}

            //// Configure JSON serialization options to handle circular references
            return cities;
        }

        public async Task<IEnumerable<City>> GetCitiesById(int id)
        {
            var param = new SqlParameter("@Id",id);
            var countrybyid = await _dbContext.Cities.FromSqlRaw<City>("sp_getcitybyid @Id", param).ToListAsync();

            return countrybyid;
        }

        public async Task<List<City>> GetCityByRoute(int countryId)
        {
            var cities = await _dbContext.Cities
           .Where(city => city.CountryId == countryId)
           .ToListAsync();

            return cities;
            Console.WriteLine("countryId",countryId);
        }

        public async Task<ActionResult<City>> UpdateCity(int id, City city)
        {
            var existingcity = _dbContext.Cities.FirstOrDefault(c => c.Id == id);
            try
            {
                existingcity.CityCode = city.CityCode;
                existingcity.CityArabicName = city.CityArabicName;
                existingcity.CityEnglishName = city.CityEnglishName;

                _dbContext.Cities.Update(existingcity);
                await _dbContext.SaveChangesAsync();
                return existingcity;

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
