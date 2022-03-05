using MailMan.Domain.Mail;

namespace MailMan.Views;

/// <summary>
/// Представление для получения списка сообщений
/// </summary>
public class MailListView
{
    /// <summary>
    /// Тема сообщения
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Результат отправки
    /// </summary>
    public ResultType SendResult { get; set; }

    /// <summary>
    /// Дата сохранения сообщения
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public string? FailedMessage { get; set; }

    /// <summary>
    /// Получатели
    /// </summary>
    public List<string> Recipients { get; set; }
}