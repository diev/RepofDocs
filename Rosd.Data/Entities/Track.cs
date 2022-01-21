using System.ComponentModel.DataAnnotations;

namespace Rosd.Data.Entities;

public class Track
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string? IDate { get; set; }

    public int INo { get; set; } = 0;

    public string? Via { get; set; }

    public string? Sender { get; set; }

    [StringLength(10)]
    public string? SendDate { get; set; }

    public string? SendNo { get; set; }

    public string? Attn { get; set; }

    public string? Client { get; set; }

    [StringLength(12)]
    public string? INN { get; set; }

    public string? Content { get; set; }

    public string? Person { get; set; }

    public string? Notes { get; set; }

    [StringLength(10)]
    public string? JDate { get; set; }

    [StringLength(8)]
    public string? JNo { get; set; }
    
    public string? JSubject { get; set; }

    [StringLength(10)]
    public string? RDate { get; set; }

    [StringLength(10)]
    public string? ODate { get; set; }

    [StringLength(8)]
    public string? ONo { get; set; }
    
    public string? Receiver { get; set; }
    
    public string? OSubject { get; set; }
}
