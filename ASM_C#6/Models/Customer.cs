using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? LastName { get; set; }

        public int Age { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự ")]
        public string? Address { get; set; }

        [StringLength(20, ErrorMessage = "không được nhập quá 20 kí tự ")]
        public string? City { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự ")]
        public string? Country { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự")]
        public string? PostalCode { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự")]
        public string? UserName { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự")]
        public string? Email { get; set; }

        [StringLength(50, ErrorMessage = "không được nhập quá 50 kí tự")]
        public string? PassWord { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //[ForeignKey("Account_Id")]
        //public Account? Account { get; set; }

        //public ICollection<Address> Addresses { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
