using MediatR;
using MudBlazor;
using WoodArtCons.Interfaces;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Services
{
    public class CategoryProductManagerService : ICategoryProductManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackbar;
        public CategoryProductManagerService(HttpClient httpClient, ISnackbar snackbar)
        {
            _httpClient = httpClient;
            _snackbar = snackbar;
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
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

        public async Task<string> AddProduct(CategoryProductModelDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Product", request);
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Produsul a fost adaugat cu succes!", Severity.Success);
                return default;
            }

            _snackbar.Add("A aparut o eroare...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<string>();
        }

        public async Task<Unit> DeleteProduct(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Product/delete/{id}");
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Produsul a fost stears cu succes!", Severity.Success);
                return await result.Content.ReadFromJsonAsync<Unit>();
            }

            _snackbar.Add("A aparut o eroare...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<Unit>();
        }

        public async Task<Unit> EditProduct(CategoryProductModelDto product)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Product", product);
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Produsul a fost editat cu succes!", Severity.Success);
                return await result.Content.ReadFromJsonAsync<Unit>();
            }

            _snackbar.Add("A aparut o eroare...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<Unit>();
        }
    }
}
