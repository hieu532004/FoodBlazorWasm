using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Total { get; set; } = 0.0m;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }

        [ForeignKey("Employee")]
        public int Employee_Id { get; set; }

        public Customer? Customer { get; set; }

        public Employee? Employee { get; set; }

        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
