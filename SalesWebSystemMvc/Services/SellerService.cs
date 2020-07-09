using SalesWebSystemMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebSystemMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebSystemMvc.Services.Exceptions;

namespace SalesWebSystemMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebSystemMvcContext _context;

        public SellerService(SalesWebSystemMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()        
            => await _context.Seller.ToListAsync();
        

        public async Task InsertDBAsync(Seller obj)
        {            
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
            => await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);        

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }    

}
