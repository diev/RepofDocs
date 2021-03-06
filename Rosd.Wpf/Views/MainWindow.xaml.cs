using Rosd.Data.Entities;

using System.Windows;
using System.Windows.Data;

namespace Rosd.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //private readonly RosdDbContext _context;

    //private readonly CollectionViewSource inTrackViewSource;
    //private readonly CollectionViewSource jrlTrackViewSource;
    //private readonly CollectionViewSource repTrackViewSource;
    //private readonly CollectionViewSource outTrackViewSource;
    ////private readonly CollectionViewSource clientViewSource;

    //public MainWindow(RosdDbContext context)
    public MainWindow()
    {
        //_context = context;
        InitializeComponent();
        //this.DataContext = new TrackViewModel();

        //inTrackViewSource = (CollectionViewSource)FindResource(nameof(inTrackViewSource));
        //jrlTrackViewSource = (CollectionViewSource)FindResource(nameof(jrlTrackViewSource));
        //repTrackViewSource = (CollectionViewSource)FindResource(nameof(repTrackViewSource));
        //outTrackViewSource = (CollectionViewSource)FindResource(nameof(outTrackViewSource));
        //clientViewSource = (CollectionViewSource)FindResource(nameof(clientViewSource));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //_context.Tracks.Load();

        //inTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        //jrlTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        //repTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        //outTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();

        //_context.Clients.Load();

        //clientViewSource.Source = _context.Clients.Local.ToObservableCollection();
    }

    private void CollectionViewSource_inFilter(object sender, FilterEventArgs e)
    {
        if (e.Item is Track t)
        {
            e.Accepted = t.INo != 0;
        }
    }

    private void CollectionViewSource_jrlFilter(object sender, FilterEventArgs e)
    {
        if (e.Item is Track t)
        {
            e.Accepted = t.JNo != string.Empty;
        }
    }

    private void CollectionViewSource_repFilter(object sender, FilterEventArgs e)
    {
        if (e.Item is Track t)
        {
            e.Accepted = t.RDate != string.Empty;
        }
    }

    private void CollectionViewSource_outFilter(object sender, FilterEventArgs e)
    {
        if (e.Item is Track t)
        {
            e.Accepted = t.ONo != string.Empty;
        }
    }
}
