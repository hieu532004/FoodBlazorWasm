using ASM_C_6.DTO.Role;
using ASM_C_6.Models;

public interface IRoleRepository
{
    Task<List<Role>> GetAll();
    Task<Role> GetById(int id);
    Task<Role> Create(RoleDto roleDto);
    Task<Role> Update(int id, RoleDto roleDto);
    Task<Role> DeleteById(int id);



}