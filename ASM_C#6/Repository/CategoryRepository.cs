using ASM_C_6.Data;
using ASM_C_6.DTO.Category;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(CategoryDto categoryDto)
        {
            var ct = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
            _context.categories.AddAsync(ct);
            await _context.SaveChangesAsync();
            return ct;
        }
        
        public async Task<List<Category>> GetAll()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
           return await _context.categories.FindAsync(id);
        }

        public async Task<Category> Update(int id, CategoryDto categoryDto)
        {
            var ct = await _context.categories.FindAsync(id);
            if (ct == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id ");
            }

            ct.Name = categoryDto.Name;
            ct.Description = categoryDto.Description;
            _context.categories.Update(ct);
            await _context.SaveChangesAsync();
            return ct;
        }

        public async Task<Category> DeleteById(int id)
        {
            var ct = _context.categories.Find(id);
            if (ct == null)
            {
                return null;
            }
            _context.categories.Remove(ct);
            await _context.SaveChangesAsync();
            return ct;
        }
     
    }
}
