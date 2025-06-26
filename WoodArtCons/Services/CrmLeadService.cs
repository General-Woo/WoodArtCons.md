using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace WoodArtCons.Services
{
    public class CrmLeadService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://woodartcons1.kommo.com/api/v4/leads";
        private const string BearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjE2MGE0NWU2MjI3ZmM2Yjg1YmIyYmQyYmZiMGQxMzM5NDdjNGFlYjBlOGM4MTFkNjdiM2U4ZWEzZmVkZWEwYWE5ZTQ0MWE5YWMwNzhiYjUxIn0.eyJhdWQiOiI2MDU5Y2JhOC05NzNiLTRhYWItODNkNy02Yjc2NTAwYjFkMDgiLCJqdGkiOiIxNjBhNDVlNjIyN2ZjNmI4NWJiMmJkMmJmYjBkMTMzOTQ3YzRhZWIwZThjODExZDY3YjNlOGVhM2ZlZGVhMGFhOWU0NDFhOWFjMDc4YmI1MSIsImlhdCI6MTc1MDkyNTAyMSwibmJmIjoxNzUwOTI1MDIxLCJleHAiOjE4MTQ0MDAwMDAsInN1YiI6IjEyMDQxMzM1IiwiZ3JhbnRfdHlwZSI6IiIsImFjY291bnRfaWQiOjMzNTcwODU5LCJiYXNlX2RvbWFpbiI6ImtvbW1vLmNvbSIsInZlcnNpb24iOjIsInNjb3BlcyI6WyJjcm0iLCJmaWxlcyIsImZpbGVzX2RlbGV0ZSIsIm5vdGlmaWNhdGlvbnMiLCJwdXNoX25vdGlmaWNhdGlvbnMiXSwiaGFzaF91dWlkIjoiNTRkMmQ3NGEtMDU0YS00NDdhLWE5ZDMtZDc3MDY1MWU1NjM5IiwiYXBpX2RvbWFpbiI6ImFwaS1nLmtvbW1vLmNvbSJ9.JhkOA7NHrfk16zYnT3O-ioMCnXje2CrRY5aKq1VzflK6oEQO59oZmk0BlgpO6zwdaQcgdi-e6YtK9aA1oJkmC_UaCIg51pNbl0vtjHajckxMgeOupJgEAGXGbACO-Yyh2QREVY7fA6DnF2YNaLm77m2qngxnsxLwPNJ82SijsDvH15-gxti_yvwn1aZCYMcSWZ9aNXeAOrRdwSu8Deffsqr40c6Tg0wRPKW7Ujn--hWfeiyYKILN4jLgiK7IETkOVLrujO6SkjBEMzXNoLsuX5TY3QoTPl_UAApWVAWE0bBcs8f6-yxeesmnht_T5D5CovifJL7KHEJpllsqN9sCzg";
        private const int PipelineId = 9697487;

        public CrmLeadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendOfferRequest(object offerModel)
        {
            // Expecting offerModel to have Name, Contact, Request
            var nameProp = offerModel.GetType().GetProperty("Name")?.GetValue(offerModel)?.ToString();
            var contactProp = offerModel.GetType().GetProperty("Contact")?.GetValue(offerModel)?.ToString();
            var requestProp = offerModel.GetType().GetProperty("Request")?.GetValue(offerModel)?.ToString();
            var concatenated = $"{nameProp} | {requestProp} | {contactProp}";
            var payload = new[] {
                new {
                    pipeline_id = PipelineId,
                    name = concatenated
                }
            };
            var json = JsonSerializer.Serialize(payload);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(httpRequest);
            return response.IsSuccessStatusCode;
        }
    }
} 
