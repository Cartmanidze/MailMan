using System.ComponentModel.DataAnnotations;
using MailMan.Domain.Mail;

namespace MailMan.Dal.Entities;

/// <summary>
/// Сущность для лога почтового сообщения
/// </summary>
public class MailMessage
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Тема сообщение
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Результат отправки
    /// </summary>
    public ResultType Result { get; set; }

    /// <summary>
    /// Сообщение ошибки отправки
    /// </summary>
    public string? FailedMessage { get; set; }

    /// <summary>
    /// Получатели
    /// </summary>
    public IReadOnlyCollection<Recipient> Recipients { get; set; }
}