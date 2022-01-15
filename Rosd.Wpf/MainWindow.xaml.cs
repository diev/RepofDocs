using Microsoft.EntityFrameworkCore;

using Rosd.Wpf.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rosd.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly TrackContext _context = new();

    private readonly CollectionViewSource trackViewSource;
    private readonly CollectionViewSource attnViewSource;
    private readonly CollectionViewSource personViewSource;
    private readonly CollectionViewSource titleViewSource;
    private readonly CollectionViewSource viaViewSource;

    public MainWindow()
    {
        InitializeComponent();
        
        trackViewSource = (CollectionViewSource)FindResource(nameof(trackViewSource));
        attnViewSource = (CollectionViewSource)FindResource(nameof(attnViewSource));
        personViewSource = (CollectionViewSource)FindResource(nameof(personViewSource));
        titleViewSource = (CollectionViewSource)FindResource(nameof(titleViewSource));
        viaViewSource = (CollectionViewSource)FindResource(nameof(viaViewSource));

        DataContext = this;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.TrackItems.Load();
        _context.AttnItems.Load();
        _context.PersonItems.Load();
        _context.TitleItems.Load();
        _context.ViaItems.Load();

        trackViewSource.Source = _context.TrackItems.Local.ToObservableCollection();
        attnViewSource.Source = _context.AttnItems.Local.ToObservableCollection();
        personViewSource.Source = _context.PersonItems.Local.ToObservableCollection();
        titleViewSource.Source = _context.TitleItems.Local.ToObservableCollection();
        viaViewSource.Source = _context.ViaItems.Local.ToObservableCollection();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        _context.Dispose();
        base.OnClosing(e);
    }
}
