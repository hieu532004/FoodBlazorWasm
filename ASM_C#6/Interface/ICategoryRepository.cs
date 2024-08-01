using ASM_C_6.DTO.Category;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Create(CategoryDto categoryDto);
        Task<Category> Update(int id, CategoryDto categoryDto);
        Task<Category> DeleteById(int id);
    }
}
