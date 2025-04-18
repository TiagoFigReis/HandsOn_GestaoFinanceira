using Core.Repositories;
using Application.InputModels.InputModelsReceitas;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Core.Entities;
using Core.Enums;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace Application.Services
{
    public class ReceitaServices(IReceitaRepository receitaRepository ) : IReceitaServices
    {
        private readonly IReceitaRepository _receitaRepository = receitaRepository;

        public async Task<ReceitaViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var receita = await _receitaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Revenue not found");
            return ReceitaViewModel.FromEntity(receita);
        }

        public async Task<IEnumerable<ReceitaViewModel>?> GetAllAsync(ClaimsPrincipal actionUser){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var receita = await _receitaRepository.GetAllAsync(userId) ?? throw new NotFoundException("Revenue not found");
            return receita.Select(ReceitaViewModel.FromEntity);
        }
        
        public async Task<ReceitaViewModel> Add(ClaimsPrincipal actionUser, CreateReceitaInputModel inputModel){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            InputModelValidator.Validate(inputModel);

            var receita = new Receitas {
                Fonte = SourceExtension.ToSource(inputModel.Fonte),
                Valor = inputModel.Valor,
                Descricao = inputModel.Descricao,
                Data = inputModel.Data,
                UserId = userId

            };

            await _receitaRepository.Add(receita);
            return ReceitaViewModel.FromEntity(receita);
        }
        public async Task<ReceitaViewModel> Update(ClaimsPrincipal actionUser, Guid Id, UpdateReceitaInputModel inputModel){

            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var receita = await _receitaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Revenue not found");

            receita.Update(
                inputModel.Fonte,
                inputModel.Valor,
                inputModel.Descricao,
                inputModel.Data,
                userId
            );

            await _receitaRepository.Update(receita);
            return ReceitaViewModel.FromEntity(receita);
        }

        public async Task<ReceitaViewModel> Delete(ClaimsPrincipal actionUser, Guid Id){

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var receita = await _receitaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Revenue not found");

            await _receitaRepository.Delete(receita);

            return ReceitaViewModel.FromEntity(receita);

        }
    }
}