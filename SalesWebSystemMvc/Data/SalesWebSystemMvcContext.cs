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

        public DbSet<SalesWebSystemMvc.Models.Department> Department { get; set; }
    }
}
