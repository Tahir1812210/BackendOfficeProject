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
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;


        public ItemController(IItemService itemService)
        {

            _itemService = itemService;

        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<Item>> GetItems()
        {

            var response = _itemService.GetAllItemsAsync();
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Item>> GetItemById(int id)
        {
            return _itemService.GetTheItemById(id);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Item>> DeleteItemById(int id)
        {
            return _itemService.DeleteItemByIdAsync(id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Item>> UpdateItemById(int id, [FromBody] Item item)
        {

            return _itemService.UpdateItemAsync(id, item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ActionResult<Item>> AddCountry([FromBody] Item item)
        {

            return _itemService.AddItemAsync(item);
        }


    }
}
