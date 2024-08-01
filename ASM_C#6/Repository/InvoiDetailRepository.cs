using ASM_C_6.Data;
using ASM_C_6.DTO.InvoiceDetail;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ASM_C_6.Repository
{
    public class InvoiDetailRepository : IInvoiceDetailRepository
    {
        private readonly DataContext _context;

        public InvoiDetailRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<InvoiceDetail> Create(InvoiceDetailDto invoiceDetailDto)
        {
            var iv = new InvoiceDetail()
            {
                Quantity = invoiceDetailDto.Quantity,
                UnitPrice = invoiceDetailDto.UnitPrice,
                Product_Id = invoiceDetailDto.Product_Id,
                Invoice_Id = invoiceDetailDto.Invoice_Id,
            };
            _context.invoiceDetails.Add(iv);
            await _context.SaveChangesAsync();
            return iv;
        }
        public async Task<List<InvoiceDetail>> GetAll()
        {
            return await _context.invoiceDetails.ToListAsync();
        }

        public async Task<InvoiceDetail> GetById(int id)
        {
            return await _context.invoiceDetails.FindAsync(id);
        }
        
        public async Task<InvoiceDetail> Update(int id, InvoiceDetailDto invoiceDetailDto)
        {
            var iv = await _context.invoiceDetails.FindAsync(id);
            if (iv == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id!");
            }
            iv.Quantity = invoiceDetailDto.Quantity;
            iv.UnitPrice = invoiceDetailDto.UnitPrice;
            iv.Product_Id = invoiceDetailDto.Product_Id;
            iv.Invoice_Id = invoiceDetailDto.Invoice_Id;
            _context.invoiceDetails.Update(iv);
            await _context.SaveChangesAsync();
            return iv;
        }

        public async Task<InvoiceDetail> DeleteById (int id)
        {
            var iv = await _context.invoiceDetails.FindAsync (id);
            if(iv == null)
            {
                return null;
            }
            _context.invoiceDetails.Remove(iv);
            await _context.SaveChangesAsync();
            return iv;
        }

    }
}
