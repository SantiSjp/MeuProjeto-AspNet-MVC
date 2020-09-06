using MeuProjeto.Data;
using MeuProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.Services
{
    public class DepartmentService
    {

        private readonly MeuProjetoContext _context;

        public DepartmentService(MeuProjetoContext context)
        {
            _context = context;
        }

        // TASK para definir acesso a dados Assincrono (melhora performance)
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
} 
