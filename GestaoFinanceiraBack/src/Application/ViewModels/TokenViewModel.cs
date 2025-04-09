namespace Application.ViewModels
{
    public class TokenViewModel(string token)
    {
        public string Token { get; set; } = token;
    }
}