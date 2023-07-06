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
    public class DetailController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDetailService _detailservice;


        public DetailController(IDetailService detailservice)
        {

            _detailservice = detailservice;

        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        public Task<List<Detail>> GetDetail()
        {
            var response = _detailservice.GetAllDetails();
            return response;
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Detail>> GetDetailById(int id)
        {
            return _detailservice.GetDetailById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Detail>> DeleteDetail(int id)
        {
            return _detailservice.DeleteDetail(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Detail>> UpdateHeadDetail(int id, [FromBody] Detail detail)
        {
            return _detailservice.UpdateDetail(id, detail);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ActionResult<Detail>> AddCustomer([FromBody] Detail detail)
        {
            return _detailservice.AddDetail(detail);
        }


    }
}
