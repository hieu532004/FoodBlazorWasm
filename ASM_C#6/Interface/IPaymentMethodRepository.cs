using ASM_C_6.DTO.PaymentMethod;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethod>> GetAll();
        Task<PaymentMethod> GetById(int id);
        Task<PaymentMethod> Create(PaymentMethodDto paymentMethodDto);
        Task<PaymentMethod> Update(int id, PaymentMethodDto paymentMethodDto);
        Task<PaymentMethod> DeleteById(int id);
    }
}
