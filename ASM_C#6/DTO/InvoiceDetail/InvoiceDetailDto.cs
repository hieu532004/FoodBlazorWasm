using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.DTO.InvoiceDetail
{
    public class InvoiceDetailDto
    {
        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice => Quantity * UnitPrice;

        [Required]
        public int Product_Id { get; set; }

        [Required]
        public int Invoice_Id { get; set; }
    }
}
