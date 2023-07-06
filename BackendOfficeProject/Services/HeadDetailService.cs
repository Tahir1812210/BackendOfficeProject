using BackendOfficeProject.Context;
using BackendOfficeProject.Models;
using BackendOfficeProject.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Services
{
    public class HeadDetailService : IHeadDetailService
    {

        private readonly ApplicationDbContext _dbContext;

        public HeadDetailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult<HeadDetail>> AddHeadDetail(HeadDetail headDetail)
        {
            _dbContext.HeadDetails.Add(headDetail);
            await _dbContext.SaveChangesAsync();
            return headDetail;
        }

        public async Task<ActionResult<HeadDetail>> DeleteHeadDetail(int id)
        {
            var showheaddetail = await _dbContext.HeadDetails.FindAsync(id);
            try
            {
                _dbContext.HeadDetails.Remove(showheaddetail);
                await _dbContext.SaveChangesAsync();
                return showheaddetail;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<HeadDetail>> GetAllHeadDetails()
        {
            var HeadDetails = await _dbContext.HeadDetails.Include(c => c.Customer).ToListAsync();
            return HeadDetails;
        
        }

        public async Task<IEnumerable<HeadDetail>> GetHeadDetailById(int id)
        {
            var param = new SqlParameter("@Id", id);
            var headdetailbyid = await _dbContext.HeadDetails.FromSqlRaw<HeadDetail>("sp_getheaddetailsbyid @Id", param).ToListAsync();
            return headdetailbyid;
        }

 
        public async Task<ActionResult<HeadDetail>> UpdateHeadDetail(int id, HeadDetail headDetail)
        {
            var existingheaddetail = _dbContext.HeadDetails.FirstOrDefault(c => c.Id == id);
            try
            {
                existingheaddetail.InvoiceNumber = headDetail.InvoiceNumber;
                existingheaddetail.InvoiceDate = headDetail.InvoiceDate;
                existingheaddetail.CustomerId = headDetail.CustomerId;
                existingheaddetail.Remarks = headDetail.Remarks;
                existingheaddetail.TotalSalesInvoiceAmount = headDetail.TotalSalesInvoiceAmount;
                existingheaddetail.TotalVatAmount = headDetail.TotalVatAmount;
                existingheaddetail.TotalSalesInvoiceAmount = headDetail.TotalSalesInvoiceAmount;
              


                _dbContext.HeadDetails.Update(existingheaddetail);
                await _dbContext.SaveChangesAsync();
                return existingheaddetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
