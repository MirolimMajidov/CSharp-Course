using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BankManagementSystem.Client.Sevices;

public class HttpAPIProvider : IHttpAPIProvider
{
    readonly IHttpClientFactory _httpClientFactory;
    readonly ITokenProvider _tokenProvider;
    NavigationManager _navigationManager;
    public HttpAPIProvider(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider, NavigationManager navigationManager)
    {
        _httpClientFactory = httpClientFactory;
        _tokenProvider = tokenProvider;
        _navigationManager = navigationManager;
    }

    public HttpClient GetHttpClient() => _httpClientFactory.CreateClient("ServerAPI");

    public async Task<(bool isSuccessStatusCode, T result, string message)> GetAsync<T>(string endponit) where T : class
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, endponit);
        return await SendAsync<T>(request);
    }

    public async Task<(bool isSuccessStatusCode, T result, string message)> PostAsync<T>(string endponit, object body = null) where T : class
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, endponit);
        if (body is not null)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            var content = new StringContent(bodyJson, null, "application/json");
            request.Content = content;
        }
        return await SendAsync<T>(request);
    }

    public async Task<(bool isSuccessStatusCode, T result, string message)> PutAsync<T>(string endponit, object body = null) where T : class
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, endponit);
        if (body is not null)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            var content = new StringContent(bodyJson, null, "application/json");
            request.Content = content;
        }
        return await SendAsync<T>(request);
    }

    public async Task<(bool isSuccessStatusCode, T result, string message)> DeleteAsync<T>(string endponit) where T : class
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, endponit);
        return await SendAsync<T>(request);
    }

    private async Task<(bool isSuccessStatusCode, T result, string message)> SendAsync<T>(HttpRequestMessage request) where T : class
    {
        try
        {
            if (_tokenProvider.IsAuthenticated)
                request.Headers.Add("Authorization", $"Bearer {_tokenProvider.GetAccessToken()}");
            using var response = await GetHttpClient().SendAsync(request);
            var responseMessage = await response.Content.ReadAsStringAsync();
            T result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(responseMessage);
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    _navigationManager.NavigateTo("/sign-in");

                result = Activator.CreateInstance<T>();
            }

            return (response.IsSuccessStatusCode, result, responseMessage);
        }
        catch (Exception ex)
        {
            return (default, default, ex.Message);
        }
    }

}
