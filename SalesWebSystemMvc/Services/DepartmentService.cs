using SalesWebSystemMvc.Data;
using SalesWebSystemMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebSystemMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebSystemMvcContext _context;

        public DepartmentService(SalesWebSystemMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
