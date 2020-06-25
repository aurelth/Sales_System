using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebSystemMvc.Models;

namespace SalesWebSystemMvc.Data
{
    public class SalesWebSystemMvcContext : DbContext
    {
        public SalesWebSystemMvcContext (DbContextOptions<SalesWebSystemMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
