using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;


namespace BackendOfficeProject.Models
{
    [Table("HeadDetail")]
    public class HeadDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string InvoiceNumber { get; set; } = null!;

        [Required]
        public DateTime InvoiceDate { get; set; } 


        [Required]

        public string Remarks { get; set; } = null!;

        [Required]

        public int TotalSalesInvoiceAmount { get; set; } = 0!;

        [Required]

        public int TotalVatAmount { get; set; } = 0!;

        [Required]

        public int TotalSalesInvoicePlusVatAmount { get; set; } = 0!;


        [ForeignKey("Customer")]


        public int CustomerId { get; set; }

        //[JsonIgnore]


        public Customer? Customer { get; set; }

    }
}
