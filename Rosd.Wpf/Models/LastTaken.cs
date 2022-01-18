using System;

namespace Rosd.Wpf.Data;

public class LastTaken
{
    public int Id { get; set; } = DateTime.Today.Year;
    public int INo { get; set; } = 0;
    public int JNo { get; set; } = 0;
    public int ONo { get; set; } = 0;
}
