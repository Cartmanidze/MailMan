using AutoMapper;
using MailMan.Dal.Context;
using MailMan.Dal.Entities;
using MailMan.Domain.Mail;
using Microsoft.EntityFrameworkCore;

namespace MailMan.Dal.Repositories;

/// <inheritdoc />
internal class MailMessageRepository : IMailMessageRepository
{
    private readonly MailManContext _mailManContext;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    public MailMessageRepository(MailManContext mailManContext, IMapper mapper)
    {
        _mailManContext = mailManContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task SaveAsync(MailMessageDomain mailMessage, CancellationToken token)
    {
        if (mailMessage == null) throw new ArgumentNullException(nameof(mailMessage));
        
        var mailMessageForDb = _mapper.Map<MailMessage>(mailMessage);

        var newRecipientsEmails = mailMessage.Recipients.Select(x => x.Email.Value).ToArray();

        var alreadyExistsRecipients = await _mailManContext.Recipients
            .Where(x => newRecipientsEmails.Contains(x.Email))
            .AsNoTracking()
            .ToArrayAsync(token)
            .ConfigureAwait(false);

        foreach (var recipient in mailMessageForDb.Recipients)
        {
            if (alreadyExistsRecipients.Any(x => x.Email == recipient.Email))
            {
                _mailManContext.Entry(recipient).State = EntityState.Modified;
            }
        }

        await _mailManContext.MailMessages.AddAsync(mailMessageForDb, token).ConfigureAwait(false);

        await _mailManContext.SaveChangesAsync(token).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<MailMessage>> GetAllAsync(CancellationToken token)
    {
        return await _mailManContext.MailMessages
            .Include(x => x.Recipients)
            .AsNoTracking()
            .ToArrayAsync(token)
            .ConfigureAwait(false);
    }
}