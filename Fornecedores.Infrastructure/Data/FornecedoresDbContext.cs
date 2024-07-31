using Fornecedores.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Infrastructure.Data
{
    public class FornecedoresDbContext : DbContext
    {
        public FornecedoresDbContext(DbContextOptions<FornecedoresDbContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
