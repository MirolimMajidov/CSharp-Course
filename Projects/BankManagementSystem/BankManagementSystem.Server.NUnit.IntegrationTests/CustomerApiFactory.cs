using BankManagementSystem.Infrastructure;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Server.NUnit.IntegrationTests
{
    public class CustomerApiFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //// Remove the existing DbContextOptions<BankContext> registration
                //var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BankContext>));
                //if (descriptor != null)
                //{
                //    services.Remove(descriptor);
                //}

                //// Add the in-memory database context
                //services..AddDbContext<BankContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDbForTesting");
                //});

                //// Build the service provider
                //var sp = services.BuildServiceProvider();

                //// Create a scope to obtain a reference to the database contexts
                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var db = scopedServices.GetRequiredService<BankContext>();

                //    // Ensure the database is created
                //    db.Database.EnsureCreated();

                //    // Seed the database with test data if needed
                //    SeedData(db);
                //}
            });
        }
    }
}
