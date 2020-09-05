using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Data
{
    public class MeuProjetoContext : DbContext
    {
        public MeuProjetoContext (DbContextOptions<MeuProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<MeuProjeto.Models.Department> Department { get; set; }
        public DbSet<MeuProjeto.Models.Seller> Seller { get; set; }
        public DbSet<MeuProjeto.Models.SalesRecord> SalesRecord { get; set; }
    }
}
