﻿using SalesWebSystemMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebSystemMvc.Models;

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
        {
            return _context.Seller.ToList();
        }

        public void InsertDB(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }    

}
