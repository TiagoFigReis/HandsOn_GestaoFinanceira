using Core.Repositories;
using Application.InputModels.InputModelsDespesas;
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
    public class DespesaServices(IDespesaRepository despesaRepository, IHttpContextAccessor http ) : IDespesaServices
    {
        private readonly IDespesaRepository _despesaRepository = despesaRepository;

        private readonly IHttpContextAccessor _httpContextAccessor = http;

        public async Task<DespesaViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var despesa = await _despesaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Expense not found");
            return DespesaViewModel.FromEntity(despesa);
        }

        public async Task<IEnumerable<DespesaViewModel>?> GetAllAsync(ClaimsPrincipal actionUser){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var despesa = await _despesaRepository.GetAllAsync(userId) ?? throw new NotFoundException("Expense not found");
            
            return despesa.Select(DespesaViewModel.FromEntity);
        }
        
        public async Task<DespesaViewModel> Add(ClaimsPrincipal actionUser, CreateDespesaInputModel inputModel){
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            InputModelValidator.Validate(inputModel);

            var despesa = new Despesas {
                Categoria = CategoryExtension.ToCategory(inputModel.Categoria),
                Valor = inputModel.Valor,
                Descricao = inputModel.Descricao,
                Data = inputModel.Data,
                UserId = userId

            };

            var path = string.Empty;

            if (inputModel.Comprovante != null && inputModel.Comprovante.Length > 0)
            {
                path = await FileService.SaveFileAsync(inputModel.Comprovante, despesa.Id, _httpContextAccessor.HttpContext! );
            }

            despesa.ComprovanteUrl = path;

            await _despesaRepository.Add(despesa);
            return DespesaViewModel.FromEntity(despesa);
        }
        public async Task<DespesaViewModel> Update(ClaimsPrincipal actionUser, Guid Id, UpdateDespesaInputModel inputModel){

            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var despesa = await _despesaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Expense not found");

            var path = string.Empty;

            if (inputModel.Comprovante != null && inputModel.Comprovante.Length > 0)
            {
                path = await FileService.SaveFileAsync(inputModel.Comprovante, despesa.Id, _httpContextAccessor.HttpContext! );
            }

            if(path == string.Empty){
               await FileService.DeleteFileAsync(despesa.Id);
            }

            despesa.Update(
                inputModel.Categoria,
                inputModel.Valor,
                inputModel.Descricao,
                inputModel.Data,
                path,
                userId
            );

            await _despesaRepository.Update(despesa);
            return DespesaViewModel.FromEntity(despesa);
        }

        public async Task<DespesaViewModel> Delete(ClaimsPrincipal actionUser, Guid Id){

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));

            var despesa = await _despesaRepository.GetByIdAsync(Id,userId) ?? throw new NotFoundException("Expense not found");

            if(despesa.ComprovanteUrl != string.Empty){
               await FileService.DeleteFileAsync(despesa.Id);
            }

            await _despesaRepository.Delete(despesa);

            return DespesaViewModel.FromEntity(despesa);

        }
    }
}