using MediatR;
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

                var response = await result.Content.ReadFromJsonAsync<UploadResultDto>();
                return response?.FilePath ?? string.Empty;
            }

            _snackbar.Add("A aparut o eroare...", Severity.Error);
            return string.Empty;
        }

        public async Task<string> DeleteFile(string fileName)
        {
            var result = await _httpClient.DeleteAsync($"api/FileUpload/delete?fileName={fileName}");
            if (result.IsSuccessStatusCode)
            {
                _snackbar.Add("Imaginea a fost stearsa cu succes!", Severity.Success);
                return await result.Content.ReadAsStringAsync();
            }

            _snackbar.Add("A aparut o eroare la stergerea imaginii...", Severity.Error);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
