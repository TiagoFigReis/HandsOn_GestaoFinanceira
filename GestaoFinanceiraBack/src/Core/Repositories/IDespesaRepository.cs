using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Repositories
{
    public interface IDespesaRepository
    {
        Task<Despesas?> GetByIdAsync(Guid Id, Guid UserId);

        Task<IEnumerable<Despesas>?> GetAllAsync(Guid UserId);
        
        Task<Despesas> Add(Despesas despesa);

        Task<Despesas> Update(Despesas despesa);

        Task<Despesas> Delete(Despesas despesa);
    }
}