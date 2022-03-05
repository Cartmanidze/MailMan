using System.ComponentModel.DataAnnotations;

namespace MailMan.Dal.Entities;

/// <summary>
/// Получатель
/// </summary>
public class Recipient
{
    /// <summary>
    /// Почта
    /// </summary>
    [Key]
    public string Email { get; set; }

    /// <summary>
    /// Сообщения для получателя
    /// </summary>
    public IReadOnlyCollection<MailMessage> MailMessages { get; set; }
}