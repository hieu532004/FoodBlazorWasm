using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("InvoiceDetail")]
        public int InvoiceDetail_Id { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethod_Id { get; set; }

        [Column(TypeName ="decimal(10, 2)")]
        public decimal Amount { get; set; }

        public DateTime Payment_Date {  get; set; } = DateTime.Now;

        public string? Payment_Status { get; set; }

        public string? Transaction_Id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public InvoiceDetail? InvoiceDetail { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }



    }
}
