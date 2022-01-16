using Microsoft.EntityFrameworkCore;

using Rosd.Wpf.Data;

using System;
using System.Collections.Generic;
using System.IO;
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
    private readonly ApplicationDbContext _context;

    private readonly CollectionViewSource inTrackViewSource;
    private readonly CollectionViewSource jrlTrackViewSource;
    private readonly CollectionViewSource repTrackViewSource;
    private readonly CollectionViewSource outTrackViewSource;

    public MainWindow(ApplicationDbContext context)
    {
        _context = context;
        InitializeComponent();
        
        inTrackViewSource = (CollectionViewSource)FindResource(nameof(inTrackViewSource));
        jrlTrackViewSource = (CollectionViewSource)FindResource(nameof(jrlTrackViewSource));
        repTrackViewSource = (CollectionViewSource)FindResource(nameof(repTrackViewSource));
        outTrackViewSource = (CollectionViewSource)FindResource(nameof(outTrackViewSource));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _context.Tracks.Load();

        inTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        jrlTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        repTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        outTrackViewSource.Source = _context.Tracks.Local.ToObservableCollection();
    }

    private void CollectionViewSource_inFilter(object sender, FilterEventArgs e)
    {
        if (e.Item is Track t)
        {
            e.Accepted = t.INo != string.Empty;
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
