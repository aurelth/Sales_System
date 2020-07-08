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

        public List<Seller> FindAll()        
            => _context.Seller.ToList();
        

        public void InsertDB(Seller obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
            => _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);        

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }    

}
