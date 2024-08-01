using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASM_C_6.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Name { get; set; }

        [StringLength(200, ErrorMessage = "Không được nhập quá 200 kí tự")]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Account>? Accounts { get; set; } 
    }
}
