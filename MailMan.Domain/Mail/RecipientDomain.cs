using MailMan.Domain.Base;

namespace MailMan.Domain.Mail;

/// <summary>
/// Получатель
/// </summary>
public class RecipientDomain : IDomain
{
    private RecipientDomain(Guid id, Email email)
    {
        Email = email;
        Id = id;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Почта получаетля
    /// </summary>
    public Email Email { get; }

    /// <summary>
    /// Создание получателя
    /// </summary>
    /// <param name="email">Почта получателя</param>
    /// <returns>Результат создания получателя</returns>
    public static Result<RecipientDomain> Create(Email email)
    {
        return Result<RecipientDomain>.Success(new RecipientDomain(Guid.NewGuid(), email));
    }
}