using Core.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Data.Common;

namespace API.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {


        public CustomWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Integration");
            base.ConfigureWebHost(builder);

            // Get a database path for the Sqlite database.
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "IntegrationTests.db");

            builder
                .ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(
                                 d => d.ServiceType == typeof(DbContextOptions<DemoContext>));

                    services.Remove(dbContextDescriptor!);

                    services.AddDbContext<DemoContext>((container, options) =>
                    {
                        options.UseSqlite($"Data Source={dbPath}");
                    });

                    var sp = services.BuildServiceProvider();
                    var context = sp.GetRequiredService<DemoContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                });
        }
    }
}
