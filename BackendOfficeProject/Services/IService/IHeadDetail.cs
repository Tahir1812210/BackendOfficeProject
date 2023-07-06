using BackendOfficeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOfficeProject.Services.IService
{
    public interface IHeadDetailService
    {

        public Task<List<HeadDetail>> GetAllHeadDetails();

        public Task<IEnumerable<HeadDetail>> GetHeadDetailById(int id);

        public Task<ActionResult<HeadDetail>> AddHeadDetail(HeadDetail headDetail);

        public Task<ActionResult<HeadDetail>> UpdateHeadDetail(int  id, HeadDetail headDetail);

        public Task<ActionResult<HeadDetail>> DeleteHeadDetail(int id);

    }
}
