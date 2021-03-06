using System.ComponentModel.DataAnnotations;

namespace Rosd.Models;

/// <summary>
/// Запись по журналу исходящих
/// </summary>
public class Outcome
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; } // = Guid.NewGuid();

    /// <summary>
    /// Срок начала подготовки ответа
    /// </summary>
    [Display(Name = "В работу")]
    [DataType(DataType.Date)]
    public DateTime? AttnDate { get; set; } // DateOnly in NET 6.0

    /// <summary>
    /// Срок ответа
    /// </summary>
    [Display(Name = "Срок")]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Дата исходящей записи по журналу
    /// </summary>
    [Display(Name = "Дата исх.")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Номер исходящей записи по журналу
    /// </summary>
    [Display(Name = "N исх.")]
    public string Num { get; set; } = "б/н";

    /// <summary>
    /// Способ отправки
    /// </summary>
    [Display(Name = "Отпр.как")]
    public string? Way { get; set; }

    /// <summary>
    /// Получатель документа
    /// </summary>
    [Display(Name = "Получатель")]
    public string? RepTo { get; set; }

    /// <summary>
    /// Тема документа
    /// </summary>
    [Display(Name = "Тема")]
    public string? Subject { get; set; }

    /// <summary>
    /// Вложенные документы для получателя
    /// </summary>
    public ICollection<Doc>? Docs { get; set; }

    /// <summary>
    /// Ответственный исполнитель
    /// </summary>
    [Display(Name = "Исполнитель")]
    public string? Person { get; set; }

    /// <summary>
    /// Поле для примечаний
    /// </summary>
    [Display(Name = "Примечания")]
    public string? Note { get; set; }

    /// <summary>
    /// Связанные записи в журнале входящих
    /// </summary>
    public ICollection<Income>? Incomes { get; set; }
}
