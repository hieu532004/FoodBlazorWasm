using ASM_C_6.DTO.Role;
using ASM_C_6.Models;
using System.Runtime.CompilerServices;

namespace ASM_C_6.Mapper
{
    public static class RoleMapper
    {
        public static Role ToRoleDto(this Role roleModel)
        {
            return new Role
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                Description = roleModel.Description,
                Accounts = roleModel.Accounts.Select(emp => emp.ToAccountEmp()).ToList()
            };
        }
    }

}
