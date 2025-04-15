using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Repositories
{
    public interface IReceitaRepository
    {
        Task<Receitas?> GetByIdAsync(Guid Id, Guid UserId);

        Task<IEnumerable<Receitas>?> GetAllAsync(Guid UserId);
        
        Task<Receitas> Add(Receitas receita);

        Task<Receitas> Update(Receitas receita);

        Task<Receitas> Delete(Receitas receita);
    }
}