using BackendOfficeProject.Dtos;
using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface IItemService
    {

         public Task<List<Item>> GetAllItemsAsync();

        
        public Task<IEnumerable<Item>> GetTheItemById(int id);
       
        public Task<ActionResult<Item>> DeleteItemByIdAsync(int id);
        public Task<ActionResult<Item>> AddItemAsync(Item item);
        public Task<ActionResult<Item>> UpdateItemAsync(int id, Item item);
    }
}
