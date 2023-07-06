using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace BackendOfficeProject.Models
{
    [Table("Country")]
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string CountryCode { get; set; } 

        [Required]
        public string CountryArabicName { get; set; } 

        [Required]
        public string CountryEnglishName { get; set; } 

        [JsonIgnore]
        public ICollection<City> Cities { get; } = new List<City>();

        [JsonIgnore]

      
        public ICollection<Customer> Customers { get; } = new List<Customer>();

       
    }
}
