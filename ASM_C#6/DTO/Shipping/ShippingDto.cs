using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM_C_6.DTO.Shipping
{
    public class ShippingDto
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(50, ErrorMessage = "Không được nhập quá 50 kí tự")]
        public string? Shipping_Address { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_City { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_State { get; set; }

        [Required]
        public string? Shipping_ZipCode { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Shipping_Country { get; set; }

        [Required]
        public string? Shipping_Method { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal Shipping_Cost { get; set; }

        [Required]
        public string? Tracking_Number { get; set; }

        [Required]
        public string? Shipping_Status { get; set; }

        public DateOnly Shipping_Date { get; set; } = new DateOnly();

        public DateOnly Expected_Delivery_Date { get; set; }

        public DateTime Delivered_Date { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        [Required]
        public int InvoiceDetail_Id { get; set; }
    }
}
