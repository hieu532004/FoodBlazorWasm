using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.DTO.Payment
{
    public class PaymentDto
    {
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Payment_Date { get; set; } = DateTime.Now;

        [Required]
        public string? Payment_Status { get; set; }

        [Required]
        public string? Transaction_Id { get; set; }

        [Required]
        public int PaymentMethod_Id { get; set; }

        [Required]
        public int InvoiceDetail_Id { get; set; }
    }
}
