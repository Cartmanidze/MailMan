using MailMan.Domain.Base;

namespace MailMan.Domain.Mail;

/// <summary>
/// Доменный объект сообщения
/// </summary>
public class MailMessageDomain : IDomain
{
    private readonly List<RecipientDomain> _recipients = new();
    
    private MailMessageDomain(Guid id, string? subject, string body)
    {
        Id = id;
        Subject = subject;
        Body = body;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Тема сообщение
    /// </summary>
    public string? Subject { get; }

    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; }

    /// <summary>
    /// Результат отправки
    /// </summary>
    public ResultType? SendResult { get; private set; }

    public string? FailedMessage { get; private set; }

    /// <summary>
    /// Получатели
    /// </summary>
    public IReadOnlyCollection<RecipientDomain> Recipients => _recipients;

    /// <summary>
    /// Создание почтового сообщения
    /// </summary>
    /// <param name="subject">Тема сообщения</param>
    /// <param name="body">Тело сообщения</param>
    /// <param name="recipients">Получатели</param>
    /// <returns>Результат создания</returns>
    public static Result<MailMessageDomain> Create(string? subject, string body,
        IReadOnlyCollection<RecipientDomain> recipients)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            Result<MailMessageDomain>.Failure("Тело сообщения не может быть пустым");
        }

        if (recipients.Count == 0)
        {
            Result<MailMessageDomain>.Failure("Должен быть хотябы один получатель");
        }

        var mailMessage = new MailMessageDomain(Guid.NewGuid(), subject, body);
        
        mailMessage._recipients.AddRange(recipients);

        return Result<MailMessageDomain>.Success(mailMessage);
    }

    public static MailMessageDomain Restore(Guid id, string? subject, string body,
        IReadOnlyCollection<RecipientDomain> recipients)
    {
        var mailMessage = new MailMessageDomain(id, subject, body);
        
        mailMessage._recipients.AddRange(recipients);

        return mailMessage;
    }

    /// <summary>
    /// Устаналливает статус успешной отправки
    /// </summary>
    public void SendSuccess()
    {
        SendResult = ResultType.Ok;
    }
    
    /// <summary>
    /// Устаналливает статус не успешной отправки
    /// </summary>
    public void SendFailure(string failedMessage)
    {
        FailedMessage = failedMessage;
        
        SendResult = ResultType.Failed;
    }
}