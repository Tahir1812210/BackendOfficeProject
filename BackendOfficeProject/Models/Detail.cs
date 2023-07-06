using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;


namespace BackendOfficeProject.Models
{
    [Table("Detail")]
    public class Detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }


        [Required]
        public string Price { get; set; } = null!;

        [Required]

        public int Qty { get; set; } = 0!;

        [Required]

        public int TotalAmount { get; set; } = 0!;

        [Required]

        public int Vat { get; set; } = 0!;

        [Required]

        public int TotalAmountPlusVat { get; set; } = 0!;

        [ForeignKey("Item")]


        public int ItemId { get; set; }

        //[JsonIgnore]


        public Item? Item { get; set; }


    }
}
