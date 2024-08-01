using ASM_C_6.DTO.Account;
using ASM_C_6.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAccountRepository
{
    Task<List<Account>> GetAll();
    Task<Account> GetById(int id);
    Task<Account> Create(AccountDto accountEmpDto);
    Task<Account> Update(int id, AccountDto accountEmpDto);
    Task<Account> DeleteById(int id);

    // Thêm phương thức mới nếu cần
    // Nếu bạn cần cập nhật thông qua DTO
}
