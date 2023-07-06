using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Services
{
    public class DetailService : IDetailService
    {

        private readonly ApplicationDbContext _dbContext;

        public DetailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult<Detail>> AddDetail(Detail detail)
        {
            _dbContext.Details.Add(detail);
            await _dbContext.SaveChangesAsync();
            return detail;
        }

        public async Task<ActionResult<Detail>> DeleteDetail(int id)
        {
            var showdetail = await _dbContext.Details.FindAsync(id);
            try
            {
                _dbContext.Details.Remove(showdetail);
                await _dbContext.SaveChangesAsync();
                return showdetail;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Detail>> GetAllDetails()
        {
            return await _dbContext.Details.Include(c => c.Item).ToListAsync();
        }

        public async Task<IEnumerable<Detail>> GetDetailById(int id)
        {
            var param = new SqlParameter("@Id", id);
            var detailbyid = await _dbContext.Details.FromSqlRaw<Detail>("sp_getdetailsbyid @Id", param).ToListAsync();
            return detailbyid;
        }

 
        public async Task<ActionResult<Detail>> UpdateDetail(int id, Detail detail)
        {
            var existingdetail = _dbContext.Details.FirstOrDefault(c => c.Id == id);
            try
            {
                existingdetail.Price = detail.Price;
                existingdetail.Qty = detail.Qty;
                existingdetail.TotalAmount = detail.TotalAmount;
                existingdetail.Vat = detail.Vat;
                existingdetail.TotalAmountPlusVat = detail.TotalAmountPlusVat;
                existingdetail.ItemId = detail.ItemId;
              


                _dbContext.Details.Update(existingdetail);
                await _dbContext.SaveChangesAsync();
                return existingdetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
