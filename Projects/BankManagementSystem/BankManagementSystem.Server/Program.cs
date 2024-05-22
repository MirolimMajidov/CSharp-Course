using BankManagementSystem.Infrastructure;
using BankManagementSystem.Middlewares;
using BankManagementSystem.Services;
using BankManagementSystem.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyUser.Models.Helpers;
using System.Text.Json.Serialization;

namespace BankManagementSystem;

public class Program
{
    public const string AppKey = "TestKey";
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Adding custom Auth
        builder.Services.AddMyAuth();

        // Add services to the container.
        builder.Services.AddDbContext<BankContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
          //.UseLazyLoadingProxies()
          //.LogTo(Console.Write, LogLevel.Error)
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        builder.Services.AddLogging();
        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        builder.Services.AddValidatorsFromAssemblyContaining<CardValidation>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });

            // Add the JWT Bearer authentication scheme
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme.",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };
            c.AddSecurityDefinition("Bearer", securityScheme);

            // Use the JWT Bearer authentication scheme globally
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new List<string>() }
            });
        });

        //Adding custom services
        builder.Services.AddMyServices();
        //builder.Services.AddMvc(options => options.Filters.Add(typeof(GlobalExceptionFilter)));

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        //Calls migration to create or update the database
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<BankContext>();
#if DEBUG
            if (builder.Environment.IsEnvironment("Test"))
            {
                context.Database.EnsureCreated();
            }
            else
            {
#endif
                context.Database.Migrate();
#if DEBUG           
            }
#endif
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        };

        app.UseCors();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<ApplicationKeyMiddleware>();
        app.UseMiddleware<EndpointListenerMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapGet("MyMinAPI", (string name) => $"Hello {name}");

        app.Run();

    }
}
