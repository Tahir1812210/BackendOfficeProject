using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace BackendOfficeProject.Models
{

    [Table("Item")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string ItemCode { get; set; } = null!;

        [Required]
        public string ItemArabicName { get; set; } = null!;

        [Required]
        public string ItemEnglishName { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public int Vat { get; set; }

        [JsonIgnore]

        public ICollection<Detail> Detail { get; } = new List<Detail>();
    }
}
