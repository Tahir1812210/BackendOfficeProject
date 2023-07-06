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
    public class HeadDetailController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHeadDetailService _headdetailservice;


        public HeadDetailController(IHeadDetailService headdetailservice)
        {

            _headdetailservice = headdetailservice;

        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        public Task<List<HeadDetail>> GetHeadDetail()
        {
            var response = _headdetailservice.GetAllHeadDetails();
            return response;
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<HeadDetail>> GetHeadDetailById(int id)
        {
            return _headdetailservice.GetHeadDetailById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<HeadDetail>> DeleteHeadDetail(int id)
        {
            return _headdetailservice.DeleteHeadDetail(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<HeadDetail>> UpdateHeadDetail(int id, [FromBody] HeadDetail headDetail)
        {
            return _headdetailservice.UpdateHeadDetail(id, headDetail);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ActionResult<HeadDetail>> AddCustomer([FromBody] HeadDetail headDetail)
        {
            return _headdetailservice.AddHeadDetail(headDetail);
        }


    }
}
