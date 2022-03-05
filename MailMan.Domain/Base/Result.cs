namespace MailMan.Domain.Base;

/// <summary>
/// Класс для результата работы с доменной моделью
/// </summary>
/// <typeparam name="T">Тип доменного объекта</typeparam>
public class Result<T> where T : IDomain
{
	private readonly T? _value;
	
	private Result(T? value, string? errorMessage)
	{
		_value = value;

		ErrorMessage = errorMessage;
	}

	/// <summary>
	/// Сообщение ошибки
	/// </summary>
	public string? ErrorMessage { get; }

	/// <summary>
	/// Значение
	/// </summary>
	public T? Value =>
		ErrorMessage == null
			? _value
			: throw new Exception(ErrorMessage);

	/// <summary>
	/// Записать успешный результат
	/// </summary>
	/// <param name="value">Значение</param>
	public static Result<T> Success(T value)
	{
		return new Result<T>(value, null);
	}

	/// <summary>
	/// Записать ошибочный результат
	/// </summary>
	/// <param name="errorMessage">Сообщение об ошибке</param>
	public static Result<T> Failure(string errorMessage)
	{
		return new Result<T>(default, errorMessage);
	}
}