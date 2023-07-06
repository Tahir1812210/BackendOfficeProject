using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface ICustomerService
    {

        public Task<List<Customer>> GetAllCustomers();

        public Task<IEnumerable<Customer>> GetCustomerById(int id);

        public Task<ActionResult<Customer>> AddCustomer(Customer customer);

        public Task<ActionResult<Customer>> UpdateCustomer(int  id, Customer customer);

        public Task<ActionResult<Customer>> DeleteCustomer(int id);

    }
}
