using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rosd.Wpf.ViewModels;

public class ClientRecord : ViewModelBase
{
    private int _id = 0;
    private string _inn = string.Empty;
    private string _title = string.Empty;

    private ObservableCollection<ClientRecord> _records = new();

    public ObservableCollection<ClientRecord> ClientRecords
    {
        get => _records;
        set 
        {
            if (_records != value)
            {
                _records = value; 
                OnPropertyChanged(nameof(ClientRecords));
            }
        }
    }

    public int Id
    {
        get => _id;
        set
        { 
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public string INN
    {
        get => _inn;
        set
        {
            if (_inn != value) 
            {
                _inn = value; 
                OnPropertyChanged(nameof(INN));
            }
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title)); 
            }
        }
    }
}
