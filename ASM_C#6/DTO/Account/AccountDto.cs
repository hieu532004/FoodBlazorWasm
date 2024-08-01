using ASM_C_6.DTO.Role;
using System.ComponentModel.DataAnnotations;

namespace ASM_C_6.DTO.Account
{
    public class AccountDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Role_Id { get; set; }
    }
}
