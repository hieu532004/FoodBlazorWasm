using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.DTO.Invoice
{
    public class InvoiceDto
    {
        [Column(TypeName = "decimal(18, 2")]
        public decimal Total { get; set; }

        [Required]
        public int Customer_Id { get; set; }

        [Required]
        public int Employee_Id { get; set; }
    }
}
