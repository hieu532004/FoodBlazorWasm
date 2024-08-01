using System.ComponentModel.DataAnnotations;

namespace ASM_C_6.DTO.PaymentMethod
{
    public class PaymentMethodDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Name { get; set; }
    }
}
