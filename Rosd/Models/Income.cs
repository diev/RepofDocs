using System.ComponentModel.DataAnnotations;

namespace Rosd.Models;

/// <summary>
/// Запись по журналу входящих
/// </summary>
public class Income
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; } // = Guid.NewGuid();

    /// <summary>
    /// Дата первичного поступления
    /// </summary>
    [Display(Name = "Пост.дата")]
    [DataType(DataType.Date)]
    public DateTime? IncDate { get; set; } // DateOnly in NET 6.0

    /// <summary>
    /// Номер первичного поступления
    /// </summary>
    [Display(Name = "Пост.N")]
    public string? IncNum { get; set; }

    /// <summary>
    /// Первичный регистратор
    /// </summary>
    [Display(Name = "Пост.кому")]
    public string? IncPerson { get; set; }

    /// <summary>
    /// Способ поступления
    /// </summary>
    [Display(Name = "Пост.как")]
    public string? Way { get; set; }

    /// <summary>
    /// Входящая дата по журналу
    /// </summary>
    [Display(Name = "Дата вх.")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Входящий номер по журналу
    /// </summary>
    [Display(Name = "N вх.")]
    public string Num { get; set; } = "б/н";

    /// <summary>
    /// Отправитель входящего запроса
    /// </summary>
    [Display(Name = "Отправитель")]
    public string? DocFrom { get; set; }

    /// <summary>
    /// Исходящая дата документа отправителя
    /// </summary>
    [Display(Name = "Исх.дата")]
    [DataType(DataType.Date)]
    public DateTime? DocDate { get; set; }

    /// <summary>
    /// Исходящий номер документа отправителя
    /// </summary>
    [Display(Name = "Исх.N")]
    public string? DocNum { get; set; }

    /// <summary>
    /// Тема документа отправителя
    /// </summary>
    [Display(Name = "Тема")]
    public string? Subject { get; set; }

    /// <summary>
    /// Какими лицами интересуется отправитель
    /// </summary>
    [Display(Name = "Про кого")]
    public string? AttnTo { get; set; }

    /// <summary>
    /// Вложенные документы отправителя
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
    /// Связанные записи в журнале исходящих
    /// </summary>
    public ICollection<Outcome>? Outcomes { get; set; }
}
