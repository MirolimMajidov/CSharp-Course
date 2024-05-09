using BankManagementSystem.Client.Sevices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));
            builder.Services.AddScoped<IHttpAPIProvider, HttpAPIProvider>();

            await builder.Build().RunAsync();
        }
    }
}
