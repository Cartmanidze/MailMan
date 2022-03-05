using MailMan.Application.Options;
using MailMan.Application.Services;
using MailMan.Dal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailMan.Application;

public static class ApplicationLayerRegistrations
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDalLayer(configuration)
            .AddMailOptions(configuration)
            .AddScoped<IMailService, MailService>();

        return services;
    }
}