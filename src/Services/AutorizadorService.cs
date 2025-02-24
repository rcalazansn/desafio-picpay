using desafio.api.Core;
using desafio.api.Services.Interfaces;
using System.Text.Json;

namespace desafio.api.Services
{
    public class AutorizadorService : IAutorizadorService
    {
        private readonly HttpClient _httpClient;

        public AutorizadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private const string URL = "https://util.devi.tools/api/v2/authorize";

        public async Task<bool> AuthorizeAsync()
        {
            string content = string.Empty;

            var response = await _httpClient.GetAsync(URL);

            if (!response.IsSuccessStatusCode)
                return false;

            response.EnsureSuccessStatusCode();

            content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse>(content);

            return result?.status == "success";

        }
    }
}
