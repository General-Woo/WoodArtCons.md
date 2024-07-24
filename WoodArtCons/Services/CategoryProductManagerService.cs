using WoodArtCons.Interfaces;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Services
{
    public class CategoryProductManagerService : ICategoryProductManagerService
    {
        private readonly HttpClient _httpClient;
        public CategoryProductManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CategoryProductModelDto> GetProductById(string id)
        {
            var result = await _httpClient.GetAsync($"api/Product/byId/{id}");
            var res = await result.Content.ReadFromJsonAsync<CategoryProductModelDto>();
            return res;
        }

        public async Task<List<CategoryProductModelDto>> GetProductsByCategoryId(string id)
        {
            var result = await _httpClient.GetAsync($"api/Product/byCategoryId/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<CategoryProductModelDto>>();
            return res;
        }
    }
}
