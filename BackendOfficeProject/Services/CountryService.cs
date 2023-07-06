using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackendOfficeProject.Services
{
    public class CountryService : ICountryService
    {

        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<Country>> AddCountryAsync( Country country)
        {
            _dbContext.Countries.Add(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<ActionResult<Country>> DeleteCountryByIdAsync(int id)
        {
            var showcountry = await _dbContext.Countries.FindAsync(id);
            try
            {
                _dbContext.Countries.Remove(showcountry);
                await _dbContext.SaveChangesAsync();
                return showcountry;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        //public async Task<List<Country>> GetAllCountriesAsync()
        //{
        //    return await _dbContext.Countries.FromSqlRaw<Country>("sp_getcountry").ToListAsync();
        //}


        public async Task<List<Country>> GetAllCountriesAsync()
        {


            return await _dbContext.Countries.FromSqlRaw<Country>("sp_getcountry").ToListAsync();

         

        }


        public async Task<IEnumerable<Country>> GetTheCountriesById(int id)
        {
            var param = new SqlParameter("@Id", id);
            var countrybyid = await Task.Run(() => _dbContext.Countries.FromSqlRaw("sp_getcountrybyid @Id", param));
            return countrybyid;
        }

        public async Task<ActionResult<Country>> UpdateCountryAsync(int id, Country country)
        {
            var existingcountry = _dbContext.Countries.FirstOrDefault(c => c.Id == id);

            
            try
            {

                existingcountry.CountryCode = country.CountryCode;
                existingcountry.CountryEnglishName = country.CountryEnglishName;
                existingcountry.CountryArabicName = country.CountryArabicName;

                _dbContext.Countries.Update(existingcountry);

                await _dbContext.SaveChangesAsync();
                return existingcountry;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
