﻿using MediatR;
using MudBlazor;
using WoodArtCons.Interfaces;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackbar;
        public FileUploadService(HttpClient httpClient, ISnackbar snackbar)
        {
            _httpClient = httpClient;
            _snackbar = snackbar;
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        }

        public async Task<string> UploadFile(MultipartFormDataContent content)
        {
            var result = await _httpClient.PostAsync("api/FileUpload/upload", content);
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Imaginea s-a incarcat cu succes!", Severity.Success);
                var res = await result.Content.ReadFromJsonAsync<string>();
                return result.ToString();
            }

            _snackbar.Add("A aparut o eroare...", Severity.Error);
            return await result.Content.ReadFromJsonAsync<string>();
        }
    }
}