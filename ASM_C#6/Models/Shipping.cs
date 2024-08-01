using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class Shipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("InvoiceDetail")]
        public int InvoiceDetail_Id { get; set; }

        [StringLength(50, ErrorMessage = "Không được nhập quá 50 kí tự")]
        public string? Shipping_Address { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_City { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_State { get; set; }

        public string? Shipping_ZipCode { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_Country { get; set; }

        public string? Shipping_Method { get; set; }

        [Column(TypeName ="decimal(12, 2)")]
        public decimal Shipping_Cost { get; set; }

        public string? Tracking_Number { get; set; }

        public string? Shipping_Status { get; set; }

        public DateOnly Shipping_Date { get; set; } = new DateOnly();

        public DateOnly Expected_Delivery_Date { get; set; }

        public DateTime Delivered_Date { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public InvoiceDetail? InvoiceDetail { get; set; }




    }
}
