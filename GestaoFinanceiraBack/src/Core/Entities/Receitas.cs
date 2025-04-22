using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Entities
{
    public class Receitas
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Sources Fonte { get; set; }
        public decimal Valor { get; set; }
        public string Descricao {get; set;} = string.Empty;
        public DateTime Data {get; set;}
        public string ComprovanteUrl {get; set;} = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UserId {get; set;}

        public Receitas() { }

        public Receitas(Sources fonte, decimal valor, string descricao, DateTime data, string comprovanteUrl, Guid userId)
        {
            Fonte = fonte;
            Valor = valor;
            Descricao = descricao;
            Data = data;
            ComprovanteUrl = comprovanteUrl;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public void Update(
            string? fonte = null,
            decimal? valor = null,
            string? descricao = null,
            DateTime? data = null,
            string? comprovanteUrl = null,
            Guid? userId = null
        )
        {
            Fonte = SourceExtension.ToSource(fonte ?? Fonte.ToFriendlyString());
            Valor = valor ?? Valor;
            Descricao = descricao ?? Descricao;
            Data = data ?? Data;
            ComprovanteUrl = comprovanteUrl ?? ComprovanteUrl;
            UserId = userId ?? UserId;
            UpdatedAt = DateTime.Now;
        }
    }
}