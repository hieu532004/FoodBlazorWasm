using ASM_C_6.DTO.Customer;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Create(CustomerDto customerDto);
        Task<Customer> Update(int id, CustomerDto customerDto);
        Task<Customer> DeleteById(int id);
    }
}
