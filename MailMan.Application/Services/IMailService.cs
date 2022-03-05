using MailMan.Domain.Mail;

namespace MailMan.Application.Services;

/// <summary>
/// Сервис для отправки почтовых сообщений
/// </summary>
public interface IMailService
{
    /// <summary>
    /// Отправка сообщения
    /// </summary>
    /// <param name="mailMessage">Сообщение</param>
    /// <param name="token">Токен отмены</param>
    /// <returns></returns>
    Task SendAsync(MailMessageDomain mailMessage, CancellationToken token);
}