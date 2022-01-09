namespace Rosd.Models;

/// <summary>
/// Запись по журналу исходящих
/// </summary>
public class Outcome
{
    /// <summary>
    /// Идентификатор документа
    /// </summary>
    public Guid Id { get; set; } // = Guid.NewGuid();

    /// <summary>
    /// Срок начала подготовки ответа
    /// </summary>
    public DateTime? AttnDate { get; set; }

    /// <summary>
    /// Срок ответа
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Дата исходящего документа по журналу
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Номер исходящего документа по журналу
    /// </summary>
    public string Num { get; set; } = "б/н";

    /// <summary>
    /// Способ отправки
    /// </summary>
    public string? Way { get; set; }

    /// <summary>
    /// Получатель документа
    /// </summary>
    public string? RepTo { get; set; }

    /// <summary>
    /// Тема документа
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// Вложенные документы для получателя
    /// </summary>
    public List<Doc>? Attachments { get; set; }

    /// <summary>
    /// Ответственный исполнитель
    /// </summary>
    public string? Person { get; set; }

    /// <summary>
    /// Поле для примечаний
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Связанные входящие документы
    /// </summary>
    public ICollection<Income>? Incomes { get; set; }
}
