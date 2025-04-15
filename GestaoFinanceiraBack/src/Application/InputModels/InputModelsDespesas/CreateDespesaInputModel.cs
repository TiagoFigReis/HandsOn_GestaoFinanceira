using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.InputModelsDespesas
{
    public class CreateDespesaInputModel
    {
        [Required(ErrorMessage = "É necessário que a receita tenha um valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É necessario uma categoria de despesa")]
        [MaxLength(50, ErrorMessage = "Categoria de despesa não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Categoria de despesa deve ter pelo menos 1 caracter")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário uma data")]
        [DataValida(ErrorMessage = "A data fornecida deve ser menor que e atual")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "É necessário uma descrição")]
        [MaxLength(50, ErrorMessage = "Descrição não pode exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Fonte de renda deve ter pelo menos 1 caracter")]
        public string Descricao { get; set; } = string.Empty;

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