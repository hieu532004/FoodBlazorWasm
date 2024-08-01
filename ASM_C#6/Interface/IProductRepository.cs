using ASM_C_6.DTO.Product;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Create(ProductDto productDto);
        Task<Product> Update(int id, ProductDto productDto);
        Task<Product> DeleteById(int id);
    }
}
