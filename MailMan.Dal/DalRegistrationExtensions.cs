using MailMan.Dal.Constants;
using MailMan.Dal.Context;
using MailMan.Dal.Repositories;
using MailMan.Domain.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailMan.Dal;

/// <summary>
/// Сервис регистрации слоя доступа к данным
/// </summary>
public static class DalRegistrationExtensions
{
    /// <summary>
    /// Добавить слой доступа данных
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="configuration">Конфигурация</param>
    /// <returns>Вернуть коллекцию сервисов</returns>
    public static IServiceCollection AddDalLayer(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<MailManContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString(DataBaseConstants.DataBaseName)));

        services.AddAutoMapper(typeof(MailManContext));

        services.AddScoped<IMailMessageRepository, MailMessageRepository>();
        
        
        return services;
    }
}