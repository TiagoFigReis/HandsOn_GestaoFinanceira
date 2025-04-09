using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.InputModelsReceitas
{
    public class CreateReceitaInputModel
    {
        [Required(ErrorMessage = "É necessário que a receita tenha um valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "É necessario uma fonte de renda")]
        [MaxLength(50, ErrorMessage = "Fonte de renda não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Fonte de renda deve ter pelo menos 1 caracter")]
        public string? Fonte { get; set; }

        [Required(ErrorMessage = "É necessário uma data")]
        [DataValida(ErrorMessage = "A data fornecida deve ser menor que e atual")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "É necessário uma descrição")]
        [MaxLength(50, ErrorMessage = "Descrição não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Fonte de renda deve ter pelo menos 1 caracter")]
        public string? Descricao { get; set; }

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