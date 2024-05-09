
using BankManagementSystem.Client.DTO;

namespace BankManagementSystem.Client.Sevices;

public interface ITokenProvider
{
    bool IsAuthenticated { get; }

    string GetAccessToken(bool refreshAccessTokenIfAuthenticated = false);

    Task<(bool IsAuthenticated, string message)> LoginAsync(LoginModel loginModel);

    void Logout();
}

