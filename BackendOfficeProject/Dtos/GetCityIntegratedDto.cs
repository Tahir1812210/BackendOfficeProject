using BackendOfficeProject.Models;
using System.ComponentModel.DataAnnotations;

namespace BackendOfficeProject.Dtos
{
    public class GetCityIntegratedDto
    {


        public int Id { get; set; }
        public string CityArabicName { get; set; }
        public string CityCode { get; set; }
        public string CityEnglishName { get; set; }
        public int CountryId { get; set; }
        public string? CountryCode { get; set; }

    }
}
