using Rosd.Wpf.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosd.Wpf.ViewModels;

public class TrackViewModel
{
    public ObservableCollection<AttnItem> AttnItems { get; set; } = new();
    public ObservableCollection<PersonItem> PersonItems { get; set; } = new();
    public ObservableCollection<TitleItem> TitleItems { get; set; } = new();
    public ObservableCollection<ViaItem> WayItems { get; set; } = new();

    public TrackViewModel()
    {
        AttnItems.Add(new AttnItem() { Id = 0, Name = "пусто" });
        PersonItems.Add(new PersonItem() { Id = 0, Name = "пусто" });
        TitleItems.Add(new TitleItem() { Id = 0, Name = "пусто" });
        WayItems.Add(new ViaItem() { Id = 0, Name = "пусто" });
    }
}
