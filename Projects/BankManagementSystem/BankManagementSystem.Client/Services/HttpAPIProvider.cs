using Newtonsoft.Json;

namespace BankManagementSystem.Client.Sevices;

public class HttpAPIProvider : IHttpAPIProvider
{
    readonly IHttpClientFactory _httpClientFactory;
    public HttpAPIProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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
            using var response = await GetHttpClient().SendAsync(request);
            var responseMessage = await response.Content.ReadAsStringAsync();
            T result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(responseMessage);
            }
            else
            {
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
