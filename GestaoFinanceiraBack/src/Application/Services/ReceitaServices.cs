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
using Microsoft.AspNetCore.Http;


namespace Application.Services
{
    public class ReceitaServices(IReceitaRepository receitaRepository, IHttpContextAccessor http ) : IReceitaServices
    {
        private readonly IReceitaRepository _receitaRepository = receitaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = http;

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

            var path = string.Empty;

            if (inputModel.Comprovante != null && inputModel.Comprovante.Length > 0)
            {
                path = await FileService.SaveFileAsync(inputModel.Comprovante, receita.Id, _httpContextAccessor.HttpContext! );
            }

            receita.ComprovanteUrl = path;

            await _receitaRepository.Add(receita);
            return ReceitaViewModel.FromEntity(receita);
        }
        public async Task<ReceitaViewModel> Update(ClaimsPrincipal actionUser, Guid Id, UpdateReceitaInputModel inputModel){

            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var receita = await _receitaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Revenue not found");

            var path = string.Empty;

            if (inputModel.Comprovante != null && inputModel.Comprovante.Length > 0)
            {
                path = await FileService.SaveFileAsync(inputModel.Comprovante, receita.Id, _httpContextAccessor.HttpContext! );
            }

            if(path == string.Empty){
               await FileService.DeleteFileAsync(receita.Id);
            }

            receita.Update(
                inputModel.Fonte,
                inputModel.Valor,
                inputModel.Descricao,
                inputModel.Data,
                path,
                userId
            );

            await _receitaRepository.Update(receita);
            return ReceitaViewModel.FromEntity(receita);
        }

        public async Task<ReceitaViewModel> Delete(ClaimsPrincipal actionUser, Guid Id){

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var receita = await _receitaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Revenue not found");

            if(receita.ComprovanteUrl != string.Empty){
               await FileService.DeleteFileAsync(receita.Id);
            }

            await _receitaRepository.Delete(receita);

            return ReceitaViewModel.FromEntity(receita);

        }
    }
}