using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class CustomWebApplicationFactoryClass<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    private const string _connectionString = "Server=IDL-LT-193;Database=ThiemeMeulenhoff-Data;User Id=sa; Password=123456@Aa;TrustServerCertificate=Yes";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ThiemeMeulenhoffPlatformDbContext>));
            var options = new DbContextOptions<ThiemeMeulenhoffPlatformDbContext>();
            var builder = new DbContextOptionsBuilder<ThiemeMeulenhoffPlatformDbContext>(options);

            builder.UseSqlServer(_connectionString);
            builder.EnableSensitiveDataLogging(false);

            services.AddPooledDbContextFactory<ThiemeMeulenhoffPlatformDbContext>(options =>
            {
                options.UseModel(SqlServerDatabaseModelBuilder.Current.GetModel());
                options.UseSqlServer(_connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure();
                });
                options.EnableSensitiveDataLogging();
            });
        });

    }
}
