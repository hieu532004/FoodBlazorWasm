using System.ComponentModel.DataAnnotations;

namespace ASM_C_6.DTO.Category
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(200, ErrorMessage = "Không được nhập quá 200 kí tự!")]
        public string? Description { get; set; }

    }
}
