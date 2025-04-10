using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Repositories
{
    public interface IReceitaRepository
    {
        Task<Receitas?> GetByIdAsync(Guid Id, Guid UserId);

        Task<IEnumerable<Receitas>?> GetAllAsync(Guid UserId);
        
        Task<Receitas> AddAsync(Receitas receita);

        Task<Receitas> UpdateAsync(Receitas receita);

        Task<Receitas> DeleteAsync(Receitas receita);
    }
}