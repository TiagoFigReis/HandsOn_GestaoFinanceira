using System.Security.Claims;
using Application.InputModels.InputModelsReceitas;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public interface IReceitaServices
    {
        Task<ReceitaViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser);

        Task<IEnumerable<ReceitaViewModel>?> GetAllAsync(ClaimsPrincipal actionUser);
        
        Task<ReceitaViewModel> Add(ClaimsPrincipal actionUser, CreateReceitaInputModel inputModel);

        Task<ReceitaViewModel> Update(ClaimsPrincipal actionUser, Guid Id, UpdateReceitaInputModel inputModel);

        Task<ReceitaViewModel> Delete(ClaimsPrincipal actionUser, Guid Id);
    }
}