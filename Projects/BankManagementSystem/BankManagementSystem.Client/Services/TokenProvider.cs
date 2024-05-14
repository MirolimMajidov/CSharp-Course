using BankManagementSystem.Client.DTO;
using Blazored.LocalStorage;
using System.Net.NetworkInformation;

namespace BankManagementSystem.Client.Sevices;

public class TokenProvider : ITokenProvider
{
    readonly IServiceProvider _provider;
    readonly ISyncLocalStorageService _localStorage;
    public TokenProvider(IServiceProvider provider, ISyncLocalStorageService localStorage)
    {
        _provider = provider;
        _localStorage = localStorage;
        LoadTokenInfo();
    }

    public bool IsAuthenticated { get; set; }

    bool IsTokenExpired => token == null || token.ExpireTime < DateTimeOffset.Now;

    static TokenInfo token;
    public string GetAccessToken()
    {
        if (IsTokenExpired && token is not null)
            GetNewRefreshToken(token.RefreshToken);

        return token?.AccessToken;
    }

    private IHttpAPIProvider GetHttpAPIProvider() =>
        _provider.GetService<IHttpAPIProvider>();

    public async Task<(bool IsAuthenticated, string message)> LoginAsync(LoginModel loginModel)
    {
        (bool isSuccessStatusCode, TokenInfo tokenInfo, string message) = await GetHttpAPIProvider().PostAsync<TokenInfo>($"Auth/Token?username={loginModel.Username}&password={loginModel.Password}");
        UpdateTokenInfo(isSuccessStatusCode, tokenInfo);

        return (isSuccessStatusCode, message);
    }

    public void Logout()
    {
        UpdateTokenInfo(false);
    }

    private void UpdateTokenInfo(bool successfullyAuthenticated, TokenInfo tokenInfo = null)
    {
        if (successfullyAuthenticated)
        {
            IsAuthenticated = true;
            token = tokenInfo;

            _localStorage.SetItem(nameof(TokenInfo), tokenInfo);
        }
        else
        {
            IsAuthenticated = false;
            token = null;

            _localStorage.RemoveItem(nameof(TokenInfo));
        }
    }

    private void LoadTokenInfo()
    {
        if (_localStorage.ContainKey(nameof(TokenInfo)))
        {
            token = _localStorage.GetItem<TokenInfo>(nameof(TokenInfo));
            IsAuthenticated = !IsTokenExpired;
        }
    }

    private void GetNewRefreshToken(string refreshToken)
    {
        (bool isSuccessStatusCode, TokenInfo tokenInfo, string message) = GetHttpAPIProvider().PostAsync<TokenInfo>($"Auth/RefreshToken?refreshToken={refreshToken}").GetAwaiter().GetResult();
        UpdateTokenInfo(isSuccessStatusCode, tokenInfo);
    }
}
