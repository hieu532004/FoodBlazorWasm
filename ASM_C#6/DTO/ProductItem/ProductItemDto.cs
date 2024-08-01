using System.ComponentModel.DataAnnotations;

namespace ASM_C_6.DTO.ProductItem
{
    public class ProductItemDto
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Stock { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string? Categry_Id { get; set; }
    }
}
