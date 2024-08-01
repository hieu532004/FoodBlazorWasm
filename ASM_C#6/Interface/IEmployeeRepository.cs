using ASM_C_6.DTO.Employee;
using ASM_C_6.Models;

namespace ASM_C_6.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Create(EmployeeDto employeeDto);
        Task<Employee> Update(int id, EmployeeDto employeeDto);
        Task<Employee> DeleteById(int id);
    }
}
