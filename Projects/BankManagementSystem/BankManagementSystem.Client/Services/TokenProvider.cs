using BankManagementSystem.Client.DTO;

namespace BankManagementSystem.Client.Sevices;

public class TokenProvider : ITokenProvider
{
    readonly IHttpAPIProvider _httpAPIProvider;
    public TokenProvider(IHttpAPIProvider httpAPIProvider)
    {
        _httpAPIProvider = httpAPIProvider;
    }

    public bool IsAuthenticated { get; set; }

    static TokenInfo token;
    public string GetAccessToken(bool forceGetAccessToken)
    {
        if (forceGetAccessToken && IsAuthenticated)
            GetNewRefreshToken(token?.RefreshToken);

        return token?.AccessToken;
    }

    public async Task<(bool IsAuthenticated, string message)> LoginAsync(LoginModel loginModel)
    {
        (bool isSuccessStatusCode, TokenInfo tokenInfo, string message) = await _httpAPIProvider.PostAsync<TokenInfo>($"Auth/Token?username={loginModel.Username}&password={loginModel.Password}");
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
        }
        else
        {
            IsAuthenticated = false;
            token = null;
        }
    }

    private void GetNewRefreshToken(string refreshToken)
    {
        (bool isSuccessStatusCode, TokenInfo tokenInfo, string message) = _httpAPIProvider.PostAsync<TokenInfo>($"Auth/RefreshToken?refreshToken={refreshToken}").GetAwaiter().GetResult();
        UpdateTokenInfo(isSuccessStatusCode, tokenInfo);
    }
}
