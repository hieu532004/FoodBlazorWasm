using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.DTO.Employee
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? LastName { get; set; }

        
        public int? Age { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? PhonNumber { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự!")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required]
        public int Account_Id { get; set; }
    }
}
