using MailKit.Net.Smtp;
using MailKit.Security;
using MailMan.Application.Options;
using MailMan.Dal.Repositories;
using MailMan.Domain.Mail;
using MimeKit;

namespace MailMan.Application.Services;

/// <inheritdoc />
internal class MailService : IMailService
{
    private readonly IMailMessageRepository _repository;

    private readonly MailOptions _mailOptions;

    /// <summary>
    /// Конструктор
    /// </summary>
    public MailService(IMailMessageRepository repository, MailOptions mailOptions)
    {
        _repository = repository;
        _mailOptions = mailOptions;
    }

    /// <inheritdoc />
    public async Task SendAsync(MailMessageDomain mailMessage, CancellationToken token)
    {
        try
        {
            await InnerSendAsync(mailMessage, token).ConfigureAwait(false);
            
            mailMessage.SendSuccess();

            await _repository.SaveAsync(mailMessage, token).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            mailMessage.SendFailure(e.Message);
            
            await _repository.SaveAsync(mailMessage, token).ConfigureAwait(false);
            
            throw;
        }
    }

    private async Task InnerSendAsync(MailMessageDomain mailMessage, CancellationToken token)
    {
        var email = new MimeMessage();

        var sender = Email.Create(_mailOptions.FromEmail).Value;

        email.Sender = MailboxAddress.Parse(sender!.Value);

        foreach (var recipient in mailMessage.Recipients)
        {
            email.To.Add(MailboxAddress.Parse(recipient.Email.Value));
        }
        
        email.Subject = mailMessage.Subject;
        
        var builder = new BodyBuilder
        {
            TextBody = mailMessage.Body
        };
        
        email.Body = builder.ToMessageBody();
        
        using var smtp = new SmtpClient();
        
        await smtp.ConnectAsync(_mailOptions.Host, _mailOptions.Port, SecureSocketOptions.StartTls, token)
            .ConfigureAwait(false);
        
        await smtp.AuthenticateAsync(sender.Value, _mailOptions.Password, token)
            .ConfigureAwait(false);
        
        await smtp.SendAsync(email, token).ConfigureAwait(false);
        
        await smtp.DisconnectAsync(true, token).ConfigureAwait(false);
    }
}