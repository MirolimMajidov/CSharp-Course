using BankManagementSystem.Infrastructure;
using BankManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Text.Json.Serialization;

namespace BankManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<BankContext>(con => con.UseSqlServer("server=localhost;integrated security=True; database=BankDB;TrustServerCertificate=true;")
          //.UseLazyLoadingProxies()
          .LogTo(Console.Write, LogLevel.Information)
          /*.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)*/);

        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
            //TODO -- NoTracking
            //var bank = context.Banks.First();
            //var oldName = bank.Name;
            //context.Attach(bank);
            //bank.Name = "Test";
            ////context.Update(bank);
            //context.SaveChanges();

            //bank.Name = oldName;
            //context.SaveChanges();

            //TODO - LazyLoadingProxies
            //var bank = context.Banks.First();
            //var name = bank.Name;
            //var branchs = bank.Branchs;


            //TODO: Lazy loading for spesific properties
            //var branch = context.Branchs.First();
            //var address = branch.Address;
            //var bank = branch.Bank;
            //var bank2 = branch.Bank;
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
