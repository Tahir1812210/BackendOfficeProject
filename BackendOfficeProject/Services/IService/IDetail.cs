using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface IDetailService
    {

        public Task<List<Detail>> GetAllDetails();

        public Task<IEnumerable<Detail>> GetDetailById(int id);

        public Task<ActionResult<Detail>> AddDetail(Detail detail);

        public Task<ActionResult<Detail>> UpdateDetail(int  id, Detail detail);

        public Task<ActionResult<Detail>> DeleteDetail(int id);

    }
}
