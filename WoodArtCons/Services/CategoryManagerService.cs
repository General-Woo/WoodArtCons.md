﻿using MediatR;
using Microsoft.JSInterop;
using MudBlazor;
using WoodArtCons.Interfaces;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Services
{
    public class CategoryManagerService : ICategoryManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackbar;
        public CategoryManagerService(HttpClient httpClient, ISnackbar snackbar)
        {
            _httpClient = httpClient;
            _snackbar = snackbar;
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        }

        public async Task<string> AddCategory(CategoryModelDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Category", request);
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Item was successfully added!", Severity.Success);
                return default;
            }

            _snackbar.Add("There was an error...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<string>();
        }

        public async Task<Unit> DeleteCategory(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Category/delete/{id}");
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Item was successfully deteled!", Severity.Success);
                return await result.Content.ReadFromJsonAsync<Unit>();
            }

            _snackbar.Add("There was an error...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<Unit>();
        }

        public async Task<Unit> EditCategory(CategoryModelDto categoryItem)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Category", categoryItem);
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Item was successfully edited!", Severity.Success);
                return await result.Content.ReadFromJsonAsync<Unit>();
            }

            _snackbar.Add("There was an error...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<Unit>();
        }

        public async Task<List<CategoryModelDto>> GetAllCategories()
        {
            var result = await _httpClient.GetAsync("api/Category/all");
            var res = await result.Content.ReadFromJsonAsync<List<CategoryModelDto>>();
            return res;
        }

        public async Task<CategoryModelDto> GetCategoryById(string id)
        {
            var result = await _httpClient.GetAsync($"api/Category/{id}");
            var res = await result.Content.ReadFromJsonAsync<CategoryModelDto>();
            return res;
        }
    }
}