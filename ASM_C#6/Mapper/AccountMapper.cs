using ASM_C_6.DTO.Account;
using ASM_C_6.Models;

namespace ASM_C_6.Mapper
{
    public static class AccountMapper
    {
        public static Account ToAccountEmp(this Account accountEmpModels)
        {
            return new Account
            {
                Id = accountEmpModels.Id,
                Role_Id = accountEmpModels.Role_Id,
                UserName = accountEmpModels.UserName,
                Password = accountEmpModels.Password,
                Email = accountEmpModels.Email,
                Role = accountEmpModels.Role,
            };
        }




    }
}
