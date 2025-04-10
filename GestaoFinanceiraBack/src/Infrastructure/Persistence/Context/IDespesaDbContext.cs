using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public interface IDespesaDbContext
    {
        public DbSet<Despesas> Despesas { get; set; }
    }
}