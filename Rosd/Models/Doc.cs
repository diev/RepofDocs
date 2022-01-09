namespace Rosd.Models;

/// <summary>
/// Документ (или папка, или архив документов) в хранилище
/// </summary>
public class Doc
{
    /// <summary>
    /// Идентификатор документа
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Название документа (исходное имя файла)
    /// </summary>
    public string Title { get; set; } = "?";

    /// <summary>
    /// Тип документа (расширение файла)
    /// </summary>
    public string? Ext { get; set; }

    /// <summary>
    /// Дата/время изменения файла документа
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Хэш файла документа (для проверки уникальности и вычисления пути в хранилище)
    /// </summary>
    public Guid? Hash { get; set; }

    /// <summary>
    /// Содержание документа (распознанный или исходный текст)
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Поле для примечаний
    /// </summary>
    public string? Note { get; set; }

    #region Flags

    /// <summary>
    /// Документ помечен к удалению?
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Документ приоритетный?
    /// </summary>
    public bool IsPriority { get; set; } = false;

    /// <summary>
    /// Документ секретный?
    /// </summary>
    public bool IsSecured { get; set; } = false;

    /// <summary>
    /// Документ сжат (это GZip)?
    /// </summary>
    public bool IsCompessed { get; set; } = false;

    /// <summary>
    /// Документ содержит другие документы (это архив Zip)?
    /// </summary>
    public bool IsArchive { get; set; } = false;

    /// <summary>
    /// Документ содержит другие документы (это папка или архив)?
    /// </summary>
    public bool IsContainer { get; set; } = false;

    #endregion Flags

    #region Navigation

    /// <summary>
    /// Вышестоящие документы (папки и архивы)
    /// </summary>
    public ICollection<Doc>? Folders { get; set; }

    /// <summary>
    /// Вложенные документы (в эту папку или архив)
    /// </summary>
    public ICollection<Doc>? Docs { get; set; }

    /// <summary>
    /// Связанные записи по журналу входящих
    /// </summary>
    public ICollection<Income>? Incomes { get; set; }

    /// <summary>
    /// Связанные записи по журналу исходящих
    /// </summary>
    public ICollection<Outcome>? Outcomes { get; set; }

    #endregion Navigation
}
