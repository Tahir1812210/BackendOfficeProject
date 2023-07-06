using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
           
            _customerService = customerService;

        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        public Task<List<Customer>> GetCustomers()
        {
            var response = _customerService.GetAllCustomers();
            return response;
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Customer>> GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            return _customerService.UpdateCustomer(id , customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }


    }
}
