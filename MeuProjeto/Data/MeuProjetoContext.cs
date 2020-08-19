using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuProjeto.Models;

namespace MeuProjeto.Data
{
    public class MeuProjetoContext : DbContext
    {
        public MeuProjetoContext (DbContextOptions<MeuProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<MeuProjeto.Models.Department> Department { get; set; }
    }
}
