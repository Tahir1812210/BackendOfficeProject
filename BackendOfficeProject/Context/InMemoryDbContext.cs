using BackendOfficeProject.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BackendOfficeProject.Context
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GetCityIntegratedDto> getCityIntegratedDtos { get; set; }

    }
}
