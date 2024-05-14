using BankManagementSystem.Client.Sevices;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BankManagementSystem.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var serverURL = new Uri("http://localhost:5002");
            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = serverURL });

            builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = serverURL);
            builder.Services.AddScoped<IHttpAPIProvider, HttpAPIProvider>();
            builder.Services.AddScoped<ITokenProvider, TokenProvider>();
            builder.Services.AddBlazoredLocalStorageAsSingleton();

            await builder.Build().RunAsync();
        }
    }
}
