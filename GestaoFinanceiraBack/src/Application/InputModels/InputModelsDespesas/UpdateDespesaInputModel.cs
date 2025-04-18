using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.InputModelsDespesas
{
    public class UpdateDespesaInputModel
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal? Valor { get; set; }

        [MaxLength(50, ErrorMessage = "Categoria de despesa não pode exceder 50 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        [DataValida(ErrorMessage = "A data fornecida deve ser menor que e atual")]
        public DateTime? Data { get; set; }

        [MaxLength(50, ErrorMessage = "Descrição não pode exceder 50 caracteres")]
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