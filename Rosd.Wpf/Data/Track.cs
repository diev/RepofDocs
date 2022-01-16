namespace Rosd.Wpf.Data;

public class Track
{
    public int Id { get; set; }
    public string? IDate { get; set; }
    public string? INo { get; set; }
    public virtual string? IFile { get; set; }
    public string? Via { get; set; }
    public string? Sender { get; set; }
    public string? SendDate { get; set; }
    public string? SendNo { get; set; }
    public string? Attn { get; set; }
    public string? Client { get; set; }
    public string? INN { get; set; }
    public string? Content { get; set; }
    public string? Person { get; set; }
    public string? Notes { get; set; }
    public string? JDate { get; set; }
    public string? JNo { get; set; }
    public string? RDate { get; set; }
    public string? ODate { get; set; }
    public string? ONo { get; set; }
    public virtual string? OFile { get; set; }
    public string? Receiver { get; set; }
    public string? Subject { get; set; }
}
