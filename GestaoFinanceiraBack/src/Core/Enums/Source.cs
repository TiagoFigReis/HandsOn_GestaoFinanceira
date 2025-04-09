namespace Core.Enums
{
    public enum Sources
    {
        RendaAtiva,
        RendaPassiva,
        RendaVariavel,
        RendaExtra,
        Outros
    }

    public static class SourceExtension
    {
        public static string ToFriendlyString(this Sources source)
        {
            return source switch
            {
                Sources.RendaAtiva => "Renda Ativa",
                Sources.RendaPassiva => "Renda Passiva",
                Sources.RendaVariavel => "Renda Variável",
                Sources.RendaExtra => "Renda Extra",
                Sources.Outros => "Outros",
                _ => "Unknown",
            };
        }

        public static Sources ToSource(this string source)
        {
            return source.Replace(" ", "") switch
            {
                "Renda Ativa" => Sources.RendaAtiva,
                "Renda Passiva" => Sources.RendaPassiva,
                "Renda Variável" => Sources.RendaVariavel,
                "Renda Extra" => Sources.RendaExtra,
                "Outros" => Sources.Outros,
                _ => Sources.Outros,
            };
        }

        public static Sources[] GetValues()
        {
            return [Sources.RendaAtiva, Sources.RendaPassiva, Sources.RendaVariavel, Sources.RendaExtra, Sources.Outros];
        }
    }
}