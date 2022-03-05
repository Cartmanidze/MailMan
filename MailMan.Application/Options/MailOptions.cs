namespace MailMan.Application.Options;

/// <summary>
/// Настройки для отправки почты
/// </summary>
public class MailOptions
{
    /// <summary>
    /// Почта отправителя
    /// </summary>
    public string FromEmail { get; set; }
    
    /// <summary>
    /// Имя для отображения в письме
    /// </summary>
    public string DisplayName { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Хост
    /// </summary>
    public string Host { get; set; }
    
    /// <summary>
    /// Порт
    /// </summary>
    public int Port { get; set; }
}