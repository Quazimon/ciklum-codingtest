using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Qzk.CodingTest.Entities.JustEat;
using Qzk.CodingTest.Entities.Settings;

namespace Qzk.CodingTest.Core.JustEat.Queries.Impl
{
    public class JustEatQueryClient : IJustEatQueryClient
    {
        private readonly IOptions<JustEatApiSettings> _apiSettings;

        public JustEatQueryClient(IOptions<JustEatApiSettings> apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task<GetRestaurantsResponse> GetRestaurants(string criteria)
        {
            if (string.IsNullOrEmpty(criteria))
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            using (var client = new HttpClient())
            {
                AddHeaders(client);

                var urlSuffix = $"restaurants?q={criteria}";
                var response = await GetAsync(urlSuffix);

                return JsonConvert.DeserializeObject<GetRestaurantsResponse>(response);
            }
        }

        private async Task<string> GetAsync(string urlSuffix)
        {
            using (var client = new HttpClient())
            {
                AddHeaders(client);

                var response = await client.GetAsync(urlSuffix);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        private void AddHeaders(HttpClient client)
        {
            client.BaseAddress = new Uri(_apiSettings.Value.Url);
            client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en-GB"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_apiSettings.Value.AuthSchema, _apiSettings.Value.AuthToken);
        }
    }
}
