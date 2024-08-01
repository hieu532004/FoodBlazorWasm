using ASM_C_6.Data;
using ASM_C_6.DTO.Role;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleRepository : IRoleRepository
{
    public readonly DataContext _context;

    public RoleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Role> Create(RoleDto roleDto)
    {
        var role = new Role
        {
            Name = roleDto.Name,
            Description = roleDto.Description,
        };

        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();

        return role;
    }

    public async Task<List<Role>> GetAll()
    {
        var roles = await _context.Roles.Include(c => c.Accounts).ToListAsync();
        return (roles);
    }

    public async Task<Role?> GetById(int id)
    {
        return await _context.Roles.FindAsync(id);
    }
    public async Task<Role> Update(int id, RoleDto roleDto)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
        {
            throw new KeyNotFoundException("không tìm thấy id");
        }
        role.Name = roleDto.Name;
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();

        return role;
    }

    public async Task<Role?> DeleteById(int id)
    {
        var existingAccount = await _context.Roles.FindAsync(id);
        if (existingAccount == null)
        {
            return null;
        }
        _context.Remove(existingAccount);
        await _context.SaveChangesAsync();
        return existingAccount;
    }
}
