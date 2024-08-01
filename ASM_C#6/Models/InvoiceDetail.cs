using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
     
        [ForeignKey("Invoice")]
        public int Invoice_Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice => Quantity * UnitPrice;

        public Product? Product { get; set; }

        public Invoice? Invoice { get; set; }

        public ICollection<Shipping>? shippings { get; set; }

        public ICollection<Payment>? payments { get; set; }

    }
}
