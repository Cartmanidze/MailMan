namespace MailMan.Views;

/// <summary>
/// Представление для отправки сообщения
/// </summary>
/// <param name="Subject">Тема сообщения</param>
/// <param name="Body">Тело сообщения</param>
/// <param name="Recipients">Получатели</param>
public record MailSendView(string? Subject, string Body, IReadOnlyCollection<string> Recipients);