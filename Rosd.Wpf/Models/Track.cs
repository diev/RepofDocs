namespace Rosd.Wpf.Models;

public class Track
{
    public int Id { get; set; }
    public string? IDateNo { get; set; }
    public Way? Way { get; set; }
    public Title? Sender { get; set; }
    public string? SendDate { get; set; }
    public string? SendNo { get; set; }
    public Attn? Attn { get; set; }
    public string? Client { get; set; }
    public string? INN { get; set; }
    public string? Content { get; set; }
    public Person? Person { get; set; }
    public string? Notes { get; set; }
    public string? JDateNo { get; set; }
    public string? RDate { get; set; }
    public string? ODateNo { get; set; }
    public Title? Receiver { get; set; }
    public string? Subject { get; set; }
}
