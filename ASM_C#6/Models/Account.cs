using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASM_C_6.Models
{
   
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]      
        public string? UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Email { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Password { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Role? Role { get; set; }

       //public Customer Customer { get; set; }

        public Employee Employee { get; set; }



        
    }
}
