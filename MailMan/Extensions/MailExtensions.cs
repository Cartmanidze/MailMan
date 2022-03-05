using MailMan.Domain.Mail;
using MailMan.Views;

namespace MailMan.Extensions;

/// <summary>
/// Методы расширения для работы с объектами сообщений
/// </summary>
internal static class MailExtensions
{
    /// <summary>
    /// Преобразование представления в доменную модель
    /// </summary>
    /// <returns></returns>
    internal static MailMessageDomain ToDomain(this MailSendView view)
    {
        var (subject, body, recipientsEmails) = view;
        
        var recipients = recipientsEmails
            .Select(recipientEmail => RecipientDomain.Create(Email.Create(recipientEmail).Value!).Value)
            .Select(recipient => recipient!)
            .ToList();

        var mailMessage = MailMessageDomain.Create(subject, body, recipients).Value;

        return mailMessage!;
    }
}