using BankManagementSystem.Infrastructure;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Text.Json.Serialization;
using BankManagementSystem.Filters;
using BankManagementSystem.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BankManagementSystem;

public class Program
{
    public const string AppKey = "TestKey";
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Auth
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => { });

        // Add services to the container.
        builder.Services.AddDbContext<BankContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
          //.UseLazyLoadingProxies()
          //.LogTo(Console.Write, LogLevel.Error)
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        builder.Services.AddLogging();
        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<IWorkerService, WorkerService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped(typeof(ISQLRepository<>), typeof(SQLRepository<>));
        //builder.Services.AddMvc(options => options.Filters.Add(typeof(GlobalExceptionFilter)));

        var app = builder.Build();

        //Calls migration to create or update the database
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<BankContext>();
            context.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        };

        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<ApplicationKeyMiddleware>();
        app.UseMiddleware<EndpointListenerMiddleware>();

        app.UseAuthorization();

        app.MapControllers();
        app.MapGet("MyMinAPI", (string name) => $"Hello {name}");

        app.Run();

    }
}
