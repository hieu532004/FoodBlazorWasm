using ASM_C_6.DTO.Payment;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<Payment> Create(PaymentDto paymentDto);
        Task<Payment> Update(int id, PaymentDto paymentDto);
        Task<Payment> DeleteById(int id);
    }
}
