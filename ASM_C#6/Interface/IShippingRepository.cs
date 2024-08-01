using ASM_C_6.DTO.Shipping;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IShippingRepository
    {
        Task<List<Shipping>> GetAll();
        Task<Shipping> GetById(int id);
        Task<Shipping> Create(ShippingDto shippingDto);
        Task<Shipping> Update(int id, ShippingDto shippingDto);
        Task<Shipping> DeleteById(int id);
    }
}
