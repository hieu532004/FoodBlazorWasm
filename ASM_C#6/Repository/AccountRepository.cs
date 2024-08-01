using ASM_C_6.Data;
using ASM_C_6.DTO.Account;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Account> Create(AccountDto accountEmpDto)
        {
            var Account = new Account
            {
                UserName = accountEmpDto.UserName,
                Email = accountEmpDto.Email,
                Password = accountEmpDto.Password,
                Role_Id = accountEmpDto.Role_Id
            };

            await _context.Accounts.AddAsync(Account);
            await _context.SaveChangesAsync();

            return Account;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }
        public async Task<Account> Update(int id, AccountDto accountEmpDto)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null)
            {
                throw new KeyNotFoundException("không tìm thấy id");
            }
            acc.UserName = accountEmpDto.UserName;
            acc.Email = accountEmpDto.Email;
            acc.Password = accountEmpDto.Password;
            acc.Role_Id = accountEmpDto.Role_Id;
            _context.Accounts.Update(acc);
            await _context.SaveChangesAsync();
            return acc;
        }

        public async Task<Account?> DeleteById(int id)
        {
            var existingAccount = await _context.Accounts.FindAsync(id);
            if (existingAccount == null)
            {
                return null;
            }
            _context.Remove(existingAccount);
            await _context.SaveChangesAsync();
            return existingAccount;
        }
    }
}
