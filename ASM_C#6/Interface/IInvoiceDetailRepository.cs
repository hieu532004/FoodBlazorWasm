using ASM_C_6.DTO.Invoice;
using ASM_C_6.DTO.InvoiceDetail;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IInvoiceDetailRepository
    {
        Task<List<InvoiceDetail>> GetAll();
        Task<InvoiceDetail> GetById(int id);
        Task<InvoiceDetail> Create(InvoiceDetailDto invoiceDetailDto);
        Task<InvoiceDetail> Update(int id, InvoiceDetailDto invoiceDetailDto);
        Task<InvoiceDetail> DeleteById(int id);
    }
}
