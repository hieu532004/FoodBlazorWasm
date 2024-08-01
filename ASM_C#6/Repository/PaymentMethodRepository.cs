using ASM_C_6.Data;
using ASM_C_6.DTO.PaymentMethod;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DataContext _context;

        public PaymentMethodRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> Create(PaymentMethodDto paymentMethodDto)
        {
            var pmm = new PaymentMethod()
            {
                Name = paymentMethodDto.Name,
            };
            _context.paymentMethods.AddAsync(pmm);
            await _context.SaveChangesAsync();
            return pmm;
        }

        public async Task<List<PaymentMethod>> GetAll()
        {
            return await _context.paymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetById(int id)
        {
            return await _context.paymentMethods.FindAsync(id);
        }

        public async Task<PaymentMethod> Update(int id, PaymentMethodDto paymentMethodDto)
        {
            var pmm = await _context.paymentMethods.FindAsync(id);
            if (pmm == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id");
            }
            pmm.Name = paymentMethodDto.Name;
            _context.paymentMethods.Update(pmm);
            await _context.SaveChangesAsync();
            return pmm;
                       
        }

        public async Task<PaymentMethod> DeleteById(int id)
        {
            var pmm = await _context.paymentMethods.FindAsync(id);
            if (pmm == null)
            {
                return null;
            }
            _context.paymentMethods.Remove(pmm);
            await _context.SaveChangesAsync();
            return pmm;
        }
    }
}
