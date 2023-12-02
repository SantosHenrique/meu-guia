using HFS.MeuGuia.Infrastructure.Data.Interceptors;
using HFS.MeuGuia.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using HFS.MeuGuia.Infrastructure.Data;
using Ardalis.GuardClauses;
using HFS.MeuGuia.Infrastructure.Common.Constants;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DataConstants.DefaultConnection);

        Guard.Against.NullOrWhiteSpace(connectionString, message: "Connection string 'DefaultConnection' não encontrada.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}