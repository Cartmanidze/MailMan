using MailMan.Dal.Entities;
using MailMan.Domain.Mail;

namespace MailMan.Dal.Repositories;

/// <summary>
/// Репозиторий для работы с сообщениями
/// </summary>
public interface IMailMessageRepository
{
    /// <summary>
    /// Сохранить сообщение
    /// </summary>
    /// <param name="mailMessage">Сообщение</param>
    /// <param name="token">Токен отмены</param>
    Task SaveAsync(MailMessageDomain mailMessage, CancellationToken token);

    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<MailMessage>> GetAllAsync(CancellationToken token);
}