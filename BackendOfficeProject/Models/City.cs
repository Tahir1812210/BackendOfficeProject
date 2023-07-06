using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.Json;


namespace BackendOfficeProject.Models
{
    [Table("City")]
    public class City
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; private set; }

        [Required]
        public string CityCode { get; set; } = null!;

        [Required]
        public string CityArabicName { get; set; } = null!;

        [Required]
        public string CityEnglishName { get; set; } = null!;


        //[NotMapped]
        //public string? CountryCode { get; set;}
       

        [ForeignKey("Country" )]
        public int CountryId { get; set; }

        //[JsonIgnore]
        public Country? Country { get; set; }

  

        [JsonIgnore]

        public ICollection<Customer> Customers { get; } = new List<Customer>();
     
    }
}
