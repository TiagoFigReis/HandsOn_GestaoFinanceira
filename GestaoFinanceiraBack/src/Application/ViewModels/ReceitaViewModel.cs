using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid Id {get; set;}
        public string? Fonte { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao {get; set;}
        public DateTime Data {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId {get; set;}

        public static ReceitaViewModel FromEntity(Receitas receita)
        {
            return new ReceitaViewModel
            {
                Id = receita.Id,
                Fonte = SourceExtension.ToFriendlyString(receita.Fonte),
                Valor = receita.Valor,
                Descricao = receita.Descricao,
                Data = receita.Data,
                CreatedAt = receita.CreatedAt,
                UpdatedAt = receita.UpdatedAt,
                UserId = receita.UserId
            };
        }
    }
}