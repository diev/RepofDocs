namespace Rosd.Models;

/// <summary>
/// Запись по журналу входящих
/// </summary>
public class Income
{
    /// <summary>
    /// Идентификатор документа
    /// </summary>
    public Guid Id { get; set; } // = Guid.NewGuid();

    /// <summary>
    /// Дата первичного поступления
    /// </summary>
    public DateTime? IncDate { get; set; }

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
    public List<string>? AttnTo { get; set; }

    /// <summary>
    /// Какими ИНН интересуется отправитель
    /// </summary>
    public List<string>? AttnINN { get; set; }

    /// <summary>
    /// Какими днями рождения интересуется отправитель
    /// </summary>
    public List<DateTime>? AttnBirth { get; set; }

    /// <summary>
    /// Какими СНИЛС интересуется отправитель
    /// </summary>
    public List<string>? AttnSnils { get; set; }

    /// <summary>
    /// Вложенные документы отправителя
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
    /// Связанные исходящие документы
    /// </summary>
    public ICollection<Outcome>? Outcomes { get; set; }
}
