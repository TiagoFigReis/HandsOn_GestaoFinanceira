using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public interface IReceitaDbContext
    {
        public DbSet<Receitas> Receitas { get; set; }
    }
}