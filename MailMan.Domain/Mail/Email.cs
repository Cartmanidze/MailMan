using System.Net.Mail;
using MailMan.Domain.Base;

namespace MailMan.Domain.Mail;

/// <summary>
/// Объект эл.адреса
/// </summary>
public record Email : ValueObject, IDomain
{
    private Email(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Значение
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Создание эл.почты
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns>Результата создания эл.почты</returns>
    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result<Email>.Failure("Значение эл. почты не может быть пустым");
        }
        
        return MailAddress.TryCreate(value, out _) ? Result<Email>.Success(new Email(value)) : Result<Email>.Failure("Значение эл.почты не валидно");
    }
}