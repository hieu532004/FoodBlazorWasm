using ASM_C_6.Data;
using ASM_C_6.DTO.Employee;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ASM_C_6.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(EmployeeDto employeeDto)
        {
            EmployeeDto employeeDto1 = employeeDto;
#pragma warning disable CS8629 // Nullable value type may be null.
            var emp = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                PhoneNumber = employeeDto.PhonNumber,
                Age = (int)employeeDto.Age,
                Address = employeeDto.Address,
                City = employeeDto.City,
                Country = employeeDto.Country,                
                HireDate = employeeDto.HireDate,
                Account_Id = employeeDto.Account_Id,
            };
#pragma warning restore CS8629 // Nullable value type may be null.
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> Update(int id, EmployeeDto employeeDto)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                throw new KeyNotFoundException("Không tim thấy id!");
            }
            emp.FirstName = employeeDto.FirstName;
            emp.LastName = employeeDto.LastName;
            emp.PhoneNumber = employeeDto.PhonNumber;
            emp.Age = employeeDto.Age;
            emp.Address = employeeDto.Address;
            emp.City = employeeDto.City;
            emp.Country = employeeDto.Country;
            emp.HireDate = employeeDto.HireDate;
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> DeleteById(int id)
        {
            var emp = _context.Employees.Find(id);
            if(emp == null)
            {
                return null;
            }
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return emp;
        }
    }
}
