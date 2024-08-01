using ASM_C_6.Data;
using ASM_C_6.DTO.Customer;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_C_6.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(CustomerDto customerDto)
        {
            var ctm = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Age = customerDto.Age,
                Address = customerDto.Address,
                City = customerDto.City,
                Country = customerDto.Country,
                PostalCode = customerDto.PostalCode,
                UserName= customerDto.UserName,
                Email = customerDto.Email,
                PassWord = customerDto.PassWord,
                PhoneNumber = customerDto.PhoneNumber,

            };
            await _context.AddAsync(ctm);
            await _context.SaveChangesAsync();
            return ctm;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> Update(int id, CustomerDto customerDto)
        {
            var ctm = await _context.Customers.FindAsync(id);
            if (ctm == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id!");
            }
            ctm.FirstName = customerDto.FirstName;
            ctm.LastName = customerDto.LastName;
            ctm.Age = customerDto.Age;
            ctm.Address = customerDto.Address;
            ctm.City = customerDto.City;
            ctm.Country = customerDto.Country;
            ctm.PostalCode = customerDto.PostalCode;
            ctm.UserName = customerDto.UserName;
            ctm.Email = customerDto.Email;
            ctm.PassWord = customerDto.PassWord;
            ctm.PhoneNumber = customerDto.PhoneNumber;
            _context.Customers.Update(ctm);
            await _context.SaveChangesAsync();
            return ctm;

        }

        public async Task<Customer> DeleteById(int id)
        {
            var ctm = await _context.Customers.FindAsync(id);
            if (ctm == null)
            {
                return null;
            }
            _context.Customers.Remove(ctm);
            await _context.SaveChangesAsync();

            return ctm;
        }
    }
}
