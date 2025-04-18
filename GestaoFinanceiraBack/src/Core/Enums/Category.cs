namespace Core.Enums
{
    public enum Category
    {
        DespesaFixa,
        DespesaVariavel,
        DespesaOcasional,
        DespesaEmergencial,
        Outros
    }

    public static class CategoryExtension
    {
        public static string ToFriendlyString(this Category category)
        {
            return category switch
            {
                Category.DespesaFixa => "Despesa Fixa",
                Category.DespesaVariavel => "Despesa Variável",
                Category.DespesaOcasional => "Despesa Ocasional",
                Category.DespesaEmergencial => "Despesa Emergencial",
                _ => "Outros",
            };
        }

        public static Category ToCategory(this string category)
        {
            return category switch
            {
                "Despesa Fixa" => Category.DespesaFixa,
                "Despesa Variável" => Category.DespesaVariavel,
                "Despesa Ocasional" => Category.DespesaOcasional,
                "Despesa Emergencial" => Category.DespesaEmergencial,
                _ => Category.Outros,
            };
        }

        public static Category[] GetValues()
        {
            return [Category.DespesaFixa, Category.DespesaVariavel, Category.DespesaOcasional, Category.DespesaEmergencial, Category.Outros];
        }
    }
}