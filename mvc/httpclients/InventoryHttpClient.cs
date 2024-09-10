using mvc.Models;
using System.Text.Json;




namespace mvc.Httpclients
{

    public class InventoryHttpClient
    {


        public readonly HttpClient _httpClient;

        public InventoryHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("mvcClient");

        }


        public async Task<List<Product>> GetProductsAsync()
        {

            var response = await _httpClient.GetAsync("api/Product");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Product>();
        }

        public async Task<List<Inventory>> GetInventoriesAsync(int categoryId = 0)
        {

            var response = await _httpClient.GetAsync($"api/Inventory/{categoryId}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Inventory>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Inventory>();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {

            var response = await _httpClient.GetAsync("api/Category");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Category>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Category>();
        }
    }

}