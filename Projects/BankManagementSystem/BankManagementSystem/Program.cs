using BankManagementSystem.Infrastructure;
using BankManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<BankContext>(con => con.UseSqlServer("server=localhost;integrated security=True; database=BankDB;TrustServerCertificate=true;"));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IWorkerService, WorkerService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped(typeof(ISQLRepository<>), typeof(SQLRepository<>));

        var app = builder.Build();

        //Calls migration to create or update the database
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            context.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

    }
}
