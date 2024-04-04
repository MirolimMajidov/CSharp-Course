using BankManagementSystem.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BankManagementSystem.Services;

public static class ServiceCollectionExtensions
{
    public static void AddMyServices(this IServiceCollection service)
    {
        service.AddScoped<AuthService>();
        service.AddScoped<IWorkerService, WorkerService>();
        service.AddScoped<IClientService, ClientService>();
        service.AddScoped(typeof(ISQLRepository<>), typeof(SQLRepository<>));
    }
}
