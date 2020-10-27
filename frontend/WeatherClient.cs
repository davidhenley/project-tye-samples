using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace frontend
{
    public class WeatherClient
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _client;

        public WeatherClient(HttpClient client) => _client = client;

        public async Task<WeatherForecast[]> GetWeatherAsync()
            => await _client.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast", _options);
    }
}