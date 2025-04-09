using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    public class GoogleService
    {
        public static async Task<string?> VerifyTokenAsync(string code, IConfiguration configuration)
        {
            var clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET") ?? configuration["Google:ClientSecret"]!;
            var clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID") ?? configuration["Google:ClientId"]!;
            var redirectUri = Environment.GetEnvironmentVariable("GOOGLE_REDIRECT_URI") ?? configuration["Google:RedirectUri"]!;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://oauth2.googleapis.com/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["code"] = code,
                    ["client_id"] = clientId,
                    ["client_secret"] = clientSecret,
                    ["redirect_uri"] = redirectUri,
                    ["grant_type"] = "authorization_code"
                })
            };

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<GoogleToken>(content);

            if (token == null || string.IsNullOrEmpty(token.AccessToken)) return null;

            request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v1/userinfo")
            {
                Headers =
                {
                    { HttpRequestHeader.Authorization.ToString(), $"Bearer {token.AccessToken}" }
                }
            };

            response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return null;

            content = await response.Content.ReadAsStringAsync();

            var user = JsonSerializer.Deserialize<GoogleUser>(content);

            if (user == null || string.IsNullOrEmpty(user.Email)) return null;

            return user.Email;
        }
    }

    public class GoogleToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("id_token")]
        public string IdToken { get; set; } = string.Empty;

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = string.Empty;

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonPropertyName("scope")]
        public string Scope { get; set; } = string.Empty;
    }

    public class GoogleUser
    {
        [JsonPropertyName("sub")]
        public string Sub { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; } = string.Empty;

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; } = string.Empty;

        [JsonPropertyName("picture")]
        public string Picture { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }
    }
}
