using System.Collections.ObjectModel;

namespace Rosd.Wpf.ViewModels;

public class TrackRecord : ViewModelBase
{
    private int _id = 0;
    private string _iDate = string.Empty;
    private int _iNo = 0;
    private string _via = string.Empty;
    private string _sender = string.Empty;
    private string _sendDate = string.Empty;
    private string _sendNo = string.Empty;
    private string _attn = string.Empty;
    private string _client = string.Empty;
    private string _inn = string.Empty;
    private string _content = string.Empty;
    private string _person = string.Empty;
    private string _notes = string.Empty;
    private string _jDate = string.Empty;
    private string _jNo = string.Empty;
    private string _jSubject = string.Empty;
    private string _rDate = string.Empty;
    private string _oDate = string.Empty;
    private string _oNo = string.Empty;
    private string _receiver = string.Empty;
    private string _oSubject = string.Empty;

    private ObservableCollection<TrackRecord> _records = new();

    public ObservableCollection<TrackRecord> TrackRecords
    {
        get => _records;
        set 
        {
            if (_records != value)
            {
                _records = value; 
                OnPropertyChanged(nameof(TrackRecords));
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

    public string IDate 
    {
        get => _iDate; 
        set
        {
            if (_iDate != value)
            {
                _iDate = value; 
                OnPropertyChanged(nameof(IDate));
            }
        }
    }
    
    public int INo 
    {
        get => _iNo; 
        set
        {
            if (_iNo != value)
            {
                _iNo = value;
                OnPropertyChanged(nameof(INo));
            }
        }
    }
    
    public string Via
    {
        get => _via; 
        set
        {
            if (_via != value)
            {
                _via = value; 
                OnPropertyChanged(nameof(Via)); 
            }
        } 
    }
    
    public string Sender 
    {
        get => _sender;
        set 
        {
            if (_sender != value) 
            {
                _sender = value;
                OnPropertyChanged(nameof(Sender)); 
            }
        }
    }
    
    public string SendDate
    {
        get => _sendDate; 
        set
        {
            if (_sendDate != value) 
            {
                _sendDate = value;
                OnPropertyChanged(nameof(SendDate)); 
            }
        }
    }
    
    public string SendNo 
    {
        get => _sendNo;
        set
        {
            if (_sendNo != value) 
            {
                _sendNo = value; OnPropertyChanged(nameof(SendNo)); 
            }
        }
    }
    
    public string Attn
    {
        get => _attn;
        set 
        {
            if (_attn != value) 
            {
                _attn = value; 
                OnPropertyChanged(nameof(Attn)); 
            }
        }
    }

    public string Client
    {
        get => _client;
        set
        {
            if (_client != value) 
            {
                _client = value;
                OnPropertyChanged(nameof(Client)); 
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

    public string Content 
    {
        get => _content; 
        set
        {
            if (_content != value)
            {
                _content = value;
                OnPropertyChanged(nameof(Content)); 
            }
        }
    }

    public string Person
    {
        get => _person;
        set
        {
            if (_person != value) 
            {
                _person = value;
                OnPropertyChanged(nameof(Person)); 
            }
        }
    }

    public string Notes
    {
        get => _notes;
        set 
        {
            if (_notes != value)
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
    }

    public string JDate
    {
        get => _jDate; 
        set 
        {
            if (_jDate != value)
            {
                _jDate = value;
                OnPropertyChanged(nameof(JDate)); 
            }
        }
    }

    public string JNo
    {
        get => _jNo; 
        set 
        {
            if (_jNo != value) 
            {
                _jNo = value;
                OnPropertyChanged(nameof(JNo));
            }
        }
    }

    public string JSubject
    {
        get => _jSubject; 
        set
        {
            if (_jSubject != value)
            {
                _jSubject = value;
                OnPropertyChanged(nameof(JSubject)); 
            }
        }
    }

    public string RDate 
    {
        get => _rDate; 
        set
        {
            if (_rDate != value)
            {
                _rDate = value;
                OnPropertyChanged(nameof(RDate));
            }
        }
    }

    public string ODate
    {
        get => _oDate; 
        set 
        {
            if (_oDate != value)
            {
                _oDate = value;
                OnPropertyChanged(nameof(ODate));
            }
        }
    }

    public string ONo
    { 
        get => _oNo; 
        set 
        {
            if (_oNo != value) 
            {
                _oNo = value;
                OnPropertyChanged(nameof(ONo));
            }
        }
    }

    public string Receiver 
    {
        get => _receiver; 
        set
        {
            if (_receiver != value) 
            {
                _receiver = value;
                OnPropertyChanged(nameof(Receiver)); 
            }
        }
    }

    public string OSubject
    {
        get => _oSubject; 
        set
        {
            if (_oSubject != value)
            {
                _oSubject = value;
                OnPropertyChanged(nameof(OSubject)); 
            }
        }
    }
}
