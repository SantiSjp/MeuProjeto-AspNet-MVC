using MeuProjeto.Data;
using MeuProjeto.Models;
using System.Collections.Generic;
using System.Linq;


namespace MeuProjeto.Services
{
    public class DepartmentService
    {

        private readonly MeuProjetoContext _context;

        public DepartmentService(MeuProjetoContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
} 
