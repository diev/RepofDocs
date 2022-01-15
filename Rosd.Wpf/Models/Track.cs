using System;

namespace Rosd.Wpf.Models;

public class Track
{
    public int Id { get; set; }
    public DateOnly? IDate { get; set; }
    public int INo { get; set; }
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
    public DateOnly? JDate { get; set; }
    public string? JNo { get; set; }
    public DateOnly? RDate { get; set; }
    public DateOnly? ODate { get; set; }
    public string? ONo { get; set; }
    public Title? Receiver { get; set; }
    public string? Subject { get; set; }
}
