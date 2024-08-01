using ASM_C_6.Data;
using ASM_C_6.DTO.Category;
using ASM_C_6.DTO.Product;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(ProductDto productDto)
        {
            var pr = new Product
            {
                Name = productDto.Name,
                Price = (decimal)productDto.Price,
                Description = productDto.Description,
                Status = (int)productDto.Status,    
            };
            _context.Products.AddAsync(pr);
            await _context.SaveChangesAsync();
            return pr;
        }

        public async Task<List<Product>> GetAll()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        } 

        public async Task<Product> Update(int id, ProductDto productDto)
        {
            var pr = await _context.Products.FindAsync(id);
            if (pr == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id ");
            }

            pr.Name = productDto.Name;
            pr.Price = (decimal)productDto.Price;
            pr.Description = productDto.Description;
            pr.Status = (int)productDto.Status;
            _context.Products.Update(pr);
            await _context.SaveChangesAsync();
            return pr;
        }

        public async Task<Product> DeleteById(int id)
        {
            var pr = _context.Products.Find(id);
            if (pr == null)
            {
                return null;
            }
            _context.Products.Remove(pr);
            await _context.SaveChangesAsync();
            return pr;
        }

    }
}
