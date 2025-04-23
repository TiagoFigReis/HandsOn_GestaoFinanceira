using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class DespesaViewModel
    {
        public Guid Id {get; set;}
        public string? Categoria { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao {get; set;}
        public DateTime Data {get; set;}
        public string? Comprovante {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId {get; set;}

        public static DespesaViewModel FromEntity(Despesas despesa)
        {
            return new DespesaViewModel
            {
                Id = despesa.Id,
                Categoria = CategoryExtension.ToFriendlyString(despesa.Categoria),
                Valor = despesa.Valor,
                Descricao = despesa.Descricao,
                Data = despesa.Data,
                Comprovante = despesa.ComprovanteUrl,
                CreatedAt = despesa.CreatedAt,
                UpdatedAt = despesa.UpdatedAt,
                UserId = despesa.UserId
            };
        }
    }
}