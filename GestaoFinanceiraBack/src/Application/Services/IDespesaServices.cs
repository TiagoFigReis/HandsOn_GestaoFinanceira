using System.Security.Claims;
using Application.InputModels.InputModelsDespesas;
using Application.ViewModels;

namespace Application.Services
{
    public interface IDespesaServices
    {
        Task<DespesaViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser);

        Task<IEnumerable<DespesaViewModel>?> GetAllAsync(ClaimsPrincipal actionUser);
        
        Task<DespesaViewModel> Add(ClaimsPrincipal actionUser, CreateDespesaInputModel inputModel);

        Task<DespesaViewModel> Update(ClaimsPrincipal actionUser, Guid Id, UpdateDespesaInputModel inputModel);

        Task<DespesaViewModel> Delete(ClaimsPrincipal actionUser, Guid id);
    }
}