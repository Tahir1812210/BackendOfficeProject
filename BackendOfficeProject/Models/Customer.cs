using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;


namespace BackendOfficeProject.Models
{
    [Table("Customer")]
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string CustomerCode { get; set; } = null!;

        [Required]
        public string CustomerArabicName { get; set; } = null!;

        [Required]
        public string CustomerEnglishName { get; set; } = null!;

        [Required]

        public int MobileNo { get; set; } = 0!;

        [Required]

        public string Email { get; set; } = null!;

        [ForeignKey("Country")]

        
        public int CountryId { get; set; }

        //[JsonIgnore]

        
        public Country? Country { get; set; }

        [ForeignKey("City")]

        [Required]
        public int CityId { get; set; }

        //[JsonIgnore]

        //[Required]
        public City? City { get; set; }

        [JsonIgnore]


        public ICollection<HeadDetail> HeadDetails { get; } = new List<HeadDetail>();
    }
}
