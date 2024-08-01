using ASM_C_6.DTO.ProductItem;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IProductItemRepository
    {
        Task<List<ProductItem>> GetAll();
        Task<ProductItem> GetById(int id);
        Task<ProductItem> Create(ProductItemDto productItemDto);
        Task<ProductItem> Update(int id, ProductItemDto productItemDto);
        Task<ProductItem> DeleteById(int id);
    }
}
