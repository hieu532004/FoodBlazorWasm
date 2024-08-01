using ASM_C_6.Data;
using ASM_C_6.DTO.ProductItem;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class ProductItemReposytory : IProductItemRepository
    {
        private readonly DataContext _context;

        public ProductItemReposytory(DataContext context)
        {
            _context = context;
        }
        
        public async Task<ProductItem> Create(ProductItemDto productItemDto)
        {
            var pr = new ProductItem()
            {
                Name = productItemDto.Name,
                Description = productItemDto.Description,
                Stock = productItemDto.Stock,
                ImageUrl = productItemDto.ImageUrl,
            };
            _context.ProductItems.AddAsync(pr);
            await _context.SaveChangesAsync();
            return pr;
        }

        public async Task<List<ProductItem>> GetAll()
        {
            return await _context.ProductItems.ToListAsync();
        }

        public async Task<ProductItem> GetById(int id)
        {
            return await _context.ProductItems.FindAsync(id);
        }

        public async Task<ProductItem> Update(int id, ProductItemDto productItemDto)
        {
            {
                var pr = await _context.ProductItems.FindAsync(id);
                if (pr == null)
                {
                    throw new KeyNotFoundException("Không tim thấy id!");
                }
                pr.Name = productItemDto.Name;
                pr.Description = productItemDto.Description;
                pr.Stock = productItemDto.Stock;
                pr.ImageUrl = productItemDto.ImageUrl;
                _context.ProductItems.Update(pr);
                await _context.SaveChangesAsync();
                return pr;
            }
        }
        public async Task<ProductItem> DeleteById(int id)
        {
            var pr = _context.ProductItems.Find(id);
            if (pr == null)
            {
                return null;
            }
             _context.ProductItems.Remove(pr);
            await _context.SaveChangesAsync();
            return pr;
        }
    }
}
