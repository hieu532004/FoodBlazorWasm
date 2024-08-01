using ASM_C_6.Data;
using ASM_C_6.DTO.Payment;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class PaymentReposytory : IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentReposytory (DataContext context)
        {
            _context = context;
        }

        public async Task<Payment> Create(PaymentDto paymentDto)
        {
            var pm = new Payment()
            {
                Amount = paymentDto.Amount,
                Payment_Date = paymentDto.Payment_Date,
                Payment_Status = paymentDto.Payment_Status,
                Transaction_Id = paymentDto.Transaction_Id,
                PaymentMethod_Id = paymentDto.PaymentMethod_Id,
                InvoiceDetail_Id = paymentDto.InvoiceDetail_Id,
            };
            _context.payments.AddAsync(pm);
            await _context.SaveChangesAsync();
            return pm;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.payments.ToListAsync();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _context.payments.FindAsync(id);
        }

        public async Task<Payment> Update(int id, PaymentDto paymentDto)
        {
            var pm = await _context.payments.FindAsync(id);
            if (pm == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id");
            }
            pm.Amount = paymentDto.Amount;
            pm.Payment_Date = paymentDto.Payment_Date;
            pm.Payment_Status = paymentDto.Payment_Status;
            pm.Transaction_Id = paymentDto.Transaction_Id;
            pm.PaymentMethod_Id = paymentDto.PaymentMethod_Id;
            pm.InvoiceDetail_Id = paymentDto.InvoiceDetail_Id;
            _context.payments.Update(pm);
            await _context.SaveChangesAsync();
            return pm;
        }

        public async Task<Payment> DeleteById (int id)
        {
            var pm = await _context.payments.FindAsync(id);
            if (pm == null)
            {
                return null;
            }
            _context.payments.Remove(pm);
            await _context.SaveChangesAsync();
            return pm;
        }
    }
}
