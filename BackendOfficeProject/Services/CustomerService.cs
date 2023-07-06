using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var showcustomer = await _dbContext.Customers.FindAsync(id);
            try
            {
               _dbContext.Customers.Remove(showcustomer);
               await _dbContext.SaveChangesAsync();
               return showcustomer; 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _dbContext.Customers.Include(c => c.Country).Include(c=>c.City).ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomerById(int id)
        {
            var param = new SqlParameter("@Id",id);
            var customerbyid = await _dbContext.Customers.FromSqlRaw<Customer>("sp_getcustomerbyid @Id",param).ToListAsync();
            return customerbyid;
        }



        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            var existingcustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            try
            {
                existingcustomer.CustomerCode = customer.CustomerCode;
                existingcustomer.CustomerArabicName = customer.CustomerArabicName;
                existingcustomer.CustomerEnglishName = customer.CustomerEnglishName;
                existingcustomer.MobileNo = customer.MobileNo;
                existingcustomer.Email = customer.Email;
                existingcustomer.CountryId = customer.CountryId;
                existingcustomer.CityId = customer.CityId;


                _dbContext.Customers.Update(existingcustomer);
                await _dbContext.SaveChangesAsync();
                return existingcustomer;

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
