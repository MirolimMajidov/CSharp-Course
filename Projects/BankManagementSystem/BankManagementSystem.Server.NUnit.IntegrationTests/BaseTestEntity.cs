using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Reflection;
using NUnit;
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting;

namespace BankManagementSystem.Server.NUnit.IntegrationTests
{
    public abstract class BaseTestEntity
    {
        protected TestServer Server;

        public BaseTestEntity()
        {
            //Server = CreateTestServer();
            Server = new CustomerApiFactory().Server;
        }

        //private TestServer CreateTestServer()
        //{
        //    var path = Assembly.GetAssembly(typeof(Program)).Location;

        //    var builder = new HostBuilder()
        //        .UseContentRoot(Path.GetDirectoryName(path))
        //        .ConfigureWebHost(webHost =>
        //        {
        //            webHost.UseTestServer()
        //                   .ConfigureServices(services =>
        //                   {
        //                       // Register your services here
        //                       services.AddControllers();
        //                       services.AddDbContext<BankContext>(options =>
        //                           options.UseInMemoryDatabase("TestDb"));

        //                       services.AddMyServices();
        //                   })
        //                   .Configure(app =>
        //                   {
        //                       using (var scope = app.ApplicationServices.CreateScope())
        //                       {
        //                           var context = scope.ServiceProvider.GetService<BankContext>();
        //                           context.Database.EnsureCreated();
        //                       }

        //                       // Configure your middleware pipeline here
        //                       app.UseRouting();
        //                       app.UseEndpoints(endpoints =>
        //                       {
        //                           endpoints.MapControllers();
        //                           // Map other endpoints if needed
        //                       });
        //                   });
        //        });

        //    var host = builder.Start();
        //    var _server = host.GetTestServer();

        //    return _server;
        //}
    }
}