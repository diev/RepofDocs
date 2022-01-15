using System;

namespace Rosd.Wpf.Models;

public class TrackItem
{
    public int Id { get; set; }
    public DateOnly? IDate { get; set; }
    public int INo { get; set; }
    public int WayId { get; set; }
    public virtual ViaItem? Way { get; set; }
    public int SenderId { get; set; }
    public virtual TitleItem? Sender { get; set; }
    public DateOnly? SendDate { get; set; }
    public string? SendNo { get; set; }
    public int AttnId { get; set; }
    public virtual AttnItem? Attn { get; set; }
    public string? Client { get; set; }
    public string? INN { get; set; }
    public string? Content { get; set; }
    public int PersonId { get; set; }
    public virtual PersonItem? Person { get; set; }
    public string? Notes { get; set; }
    public DateOnly? JDate { get; set; }
    public string? JNo { get; set; }
    public DateOnly? RDate { get; set; }
    public DateOnly? ODate { get; set; }
    public string? ONo { get; set; }
    public int ReceiverId { get; set; }
    public virtual TitleItem? Receiver { get; set; }
    public string? Subject { get; set; }
}
