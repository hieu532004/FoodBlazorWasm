using ASM_C_6.Data;
using ASM_C_6.DTO.Invoice;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Create(InvoiceDto invoiceDto)
        {
            var iv = new Invoice
            {
                Total = (decimal)invoiceDto.Total,               
            };
            _context.Invoices.AddAsync(iv);
            await _context.SaveChangesAsync();
            return iv;
        }

        public async Task<List<Invoice>> GetAll()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetById(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice> Update(int id, InvoiceDto invoiceDto)
        {
            var vi = await _context.Invoices.FindAsync(id);
            if (vi == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id!");
            }

            vi.Total = invoiceDto.Total;
            _context.Invoices.Update(vi);
            await _context.SaveChangesAsync();
            return vi;
            
        }

        public async Task<Invoice> DeleteById(int id)
        {
            var vi = await _context.Invoices.FindAsync(id);
            if (vi ==null)
            {
                return null;
            }
            _context.Invoices.Remove(vi);
            await _context.SaveChangesAsync();
            return vi;
        }
    }
}
