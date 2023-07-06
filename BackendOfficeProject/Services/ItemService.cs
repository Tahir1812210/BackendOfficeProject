using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackendOfficeProject.Services
{
    public class ItemService : IItemService
    {

        private readonly ApplicationDbContext _dbContext;

        public ItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<Item>> AddItemAsync( Item item )
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<ActionResult<Item>> DeleteItemByIdAsync(int id)
        {
            var showitem = await _dbContext.Items.FindAsync(id);
            try
            {
                _dbContext.Items.Remove(showitem);
                await _dbContext.SaveChangesAsync();
                return showitem;
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


        public async Task<List<Item>> GetAllItemsAsync()
        {


            return await _dbContext.Items.FromSqlRaw<Item>("sp_getitem").ToListAsync();

          

        }


        public async Task<IEnumerable<Item>> GetTheItemById(int id)
        {
            var param = new SqlParameter("@Id", id);
            var itembyid = await Task.Run(() => _dbContext.Items.FromSqlRaw("sp_getitembyid @Id", param));
            return itembyid;
        }

        public async Task<ActionResult<Item>> UpdateItemAsync(int id, Item item)
        {
            var existingitem = _dbContext.Items.FirstOrDefault(c => c.Id == id);

            
            try
            {

                existingitem.ItemCode = item.ItemCode;
                existingitem.ItemEnglishName = item.ItemEnglishName;
                existingitem.ItemArabicName = item.ItemArabicName;
                existingitem.Price = item.Price;
                existingitem.Vat = item.Vat;

                _dbContext.Items.Update(existingitem);

                await _dbContext.SaveChangesAsync();
                return existingitem;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    
    }
}
