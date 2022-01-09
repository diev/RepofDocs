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
    [DataType(DataType.Date)]
    public DateTime? IncDate { get; set; } // DateOnly in NET 6.0

    /// <summary>
    /// Номер первичного поступления
    /// </summary>
    public string? IncNum { get; set; }

    /// <summary>
    /// Первичный регистратор
    /// </summary>
    public string? IncPerson { get; set; }

    /// <summary>
    /// Способ поступления
    /// </summary>
    public string? Way { get; set; }

    /// <summary>
    /// Входящая дата по журналу
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Входящий номер по журналу
    /// </summary>
    public string Num { get; set; } = "б/н";

    /// <summary>
    /// Отправитель входящего запроса
    /// </summary>
    public string? DocFrom { get; set; }

    /// <summary>
    /// Исходящая дата документа отправителя
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime? DocDate { get; set; }

    /// <summary>
    /// Исходящий номер документа отправителя
    /// </summary>
    public string? DocNum { get; set; }

    /// <summary>
    /// Тема документа отправителя
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// Какими лицами интересуется отправитель
    /// </summary>
    public string? AttnTo { get; set; }

    /// <summary>
    /// Вложенные документы отправителя
    /// </summary>
    public ICollection<Doc>? Docs { get; set; }

    /// <summary>
    /// Ответственный исполнитель
    /// </summary>
    public string? Person { get; set; }

    /// <summary>
    /// Поле для примечаний
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Связанные записи в журнале исходящих
    /// </summary>
    public ICollection<Outcome>? Outcomes { get; set; }
}
