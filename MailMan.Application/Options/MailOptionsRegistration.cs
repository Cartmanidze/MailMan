using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailMan.Application.Options;

/// <summary>
/// Регистрация опций для отправки эл. сообщений
/// </summary>
internal static class MailOptionsRegistration
{
    /// <summary>
    /// Добавить опции для отправки эл. сообщений
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="configuration">Конфигурация</param>
    /// <returns></returns>
    internal static IServiceCollection AddMailOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(MailOptions));

        if (!section.Exists())
        {
            throw new Exception("Секция '{0}' не была найдена! Укажите ее в appsettings.json"); 
        }
        
        var options = section.Get<MailOptions>();
        
        services.AddSingleton(options);

        return services;
    }
}