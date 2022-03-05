using MailMan.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailMan.Dal.Context;

/// <summary>
/// Контекст базы данных
/// </summary>
public class MailManContext : DbContext
{
	/// <summary>
	/// Конструктор
	/// </summary>
	public MailManContext()
	{
		
	}
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции</param>
	public MailManContext(DbContextOptions<MailManContext> options) : base(options)
	{
		
	}

	/// <summary>
	/// Таблица сообщений
	/// </summary>
	internal DbSet<MailMessage> MailMessages { get; set; }

	/// <summary>
	/// Таблица поулчателей
	/// </summary>
	internal DbSet<Recipient> Recipients { get; set; }
}