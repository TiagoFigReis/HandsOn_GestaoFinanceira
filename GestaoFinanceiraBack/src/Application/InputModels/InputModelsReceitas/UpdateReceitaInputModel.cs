using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.InputModelsReceitas
{
    public class UpdateReceitaInputModel
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal? Valor { get; set; }

        [MaxLength(50, ErrorMessage = "Fonte de renda não pode exceder 50 caracteres")]
        public string Fonte { get; set; } = string.Empty;

        [DataValida(ErrorMessage = "A data fornecida deve ser menor que e atual")]
        public DateTime? Data { get; set; }

        [MaxLength(50, ErrorMessage = "Descrição não pode exceder 50 caracteres")]
        public string? Descricao { get; set; } = string.Empty;

        public class DataValida : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if (value is DateTime date)
                {
                    return date <= DateTime.Now;
                }
                return true;
            }
        }

    }
}