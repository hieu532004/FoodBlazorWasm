using ASM_C_6.DTO.Invoice;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAll();
        Task<Invoice> GetById(int id);
        Task<Invoice> Create(InvoiceDto invoiceDto);
        Task<Invoice> Update(int id, InvoiceDto invoiceDto);
        Task<Invoice> DeleteById(int id);
    }
}
