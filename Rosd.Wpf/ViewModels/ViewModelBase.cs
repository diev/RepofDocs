using System.ComponentModel;

namespace Rosd.Wpf.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyValue)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
    }
}
