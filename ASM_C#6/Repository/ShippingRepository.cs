using ASM_C_6.Data;
using ASM_C_6.DTO.Shipping;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace ASM_C_6.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly DataContext _context;
        
        public ShippingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Shipping> Create(ShippingDto shippingDto)
        {
            var sh = new Shipping()
            {
                Shipping_Address = shippingDto.Shipping_Address,
                Shipping_City = shippingDto.Shipping_City,
                Shipping_State = shippingDto.Shipping_State,
                Shipping_ZipCode = shippingDto.Shipping_ZipCode,
                Shipping_Country = shippingDto.Shipping_Country,
                Shipping_Method = shippingDto.Shipping_Method,
                Shipping_Cost = shippingDto.Shipping_Cost,
                Tracking_Number = shippingDto.Tracking_Number,
                Shipping_Status = shippingDto.Shipping_Status,
                Shipping_Date = shippingDto.Shipping_Date,
                Expected_Delivery_Date = shippingDto.Expected_Delivery_Date,
                Delivered_Date = shippingDto.Delivered_Date,
            };
            _context.shippings.AddAsync(sh);
            await _context.SaveChangesAsync();
            return sh;
        }

        public async Task<List<Shipping>> GetAll()
        {
            return await _context.shippings.ToListAsync();
        }

        public async Task<Shipping> GetById(int id)
        {
            return await _context.shippings.FindAsync(id);
        }

        public async Task<Shipping> Update(int id, ShippingDto shippingDto)
        {
            var sh = await _context.shippings.FindAsync(id);
            if (shippingDto == null)
            {
                throw new KeyNotFoundException("Không tìm thấy id!");
            }
            sh.Shipping_Address = shippingDto.Shipping_Address;
            sh.Shipping_City = shippingDto.Shipping_City;
            sh.Shipping_State = shippingDto.Shipping_State;
            sh.Shipping_ZipCode = shippingDto.Shipping_ZipCode;
            sh.Shipping_Country = shippingDto.Shipping_Country;
            sh.Shipping_Method = shippingDto.Shipping_Method;
            sh.Shipping_Cost = shippingDto.Shipping_Cost;
            sh.Tracking_Number = shippingDto.Tracking_Number;
            sh.Shipping_Status = shippingDto.Shipping_Status;
            sh.Shipping_Date = shippingDto.Shipping_Date;
            sh.Expected_Delivery_Date = shippingDto.Expected_Delivery_Date;
            sh.Delivered_Date = shippingDto.Delivered_Date;
            _context.shippings.Update(sh);
            await _context.SaveChangesAsync();
            return sh;
        }

        public async Task<Shipping> DeleteById(int id)
        {
            var sh = await _context.shippings.FindAsync(id);
            if (sh ==  null)
            {
                return null;
            }
            _context.shippings.Remove(sh);
            await _context.SaveChangesAsync();
            return sh;
        }
    }
}
