using Core.Enums;

namespace Core.Entities
{
    public class Despesas
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Category Categoria { get; set; }
        public decimal Valor { get; set; }

        public string? Descricao {get; set;}

        public DateTime Data {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UserId {get; set;}

        public Despesas() { }

        public Despesas(Category categoria, decimal valor, string descricao, DateTime data, Guid userId)
        {
            Categoria = categoria;
            Valor = valor;
            Descricao = descricao;
            Data = data;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public void Update(
            string? categoria = null,
            decimal? valor = null,
            string? descricao = null,
            DateTime? data = null,
            Guid? userId = null
        )
        {
            Categoria = CategoryExtension.ToCategory(categoria ?? Categoria.ToFriendlyString());
            Valor = valor ?? Valor;
            Descricao = descricao ?? Descricao;
            Data = data ?? Data;
            UserId = userId ?? UserId;
            UpdatedAt = DateTime.Now;
        }
    }
}