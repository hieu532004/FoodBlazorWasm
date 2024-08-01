using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.DTO.Product
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Description { get; set; }

        [Required]
        public int? Status { get; set; }
    }
}
