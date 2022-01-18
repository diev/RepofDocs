using System.Collections.ObjectModel;

namespace Rosd.Wpf.ViewModels;

public class TrackRecord : ViewModelBase
{
    private int _id;
    private string? _iDate;
    private int? _iNo;
    private string? _via;
    private string? _sender;
    private string? _sendDate;
    private string? _sendNo;
    private string? _attn;
    private string? _client;
    private string? _inn;
    private string? _content;
    private string? _person;
    private string? _notes;
    private string? _jDate;
    private string? _jNo;
    private string? _jSubject;
    private string? _rDate;
    private string? _oDate;
    private string? _oNo;
    private string? _receiver;
    private string? _oSubject;

    private ObservableCollection<TrackRecord> _trackRecords = null!;

    public int Id 
    { 
        get => _id; 
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }
    public string? IDate 
    {
        get => _iDate; 
        set { if (_iDate != value) { _iDate = value; OnPropertyChanged(nameof(IDate)); } }
    }
    public int? INo 
    {
        get => _iNo; 
        set { if (_iNo != value) { _iNo = value; OnPropertyChanged(nameof(INo)); } }
    }
    public string? Via
    {
        get => _via; 
        set { if (_via != value) { _via = value; OnPropertyChanged(nameof(Via)); } } 
    }
    public string? Sender 
    {
        get => _sender;
        set { if (_sender != value) { _sender = value; OnPropertyChanged(nameof(Sender)); } }
    }
    public string? SendDate
    {
        get => _sendDate; 
        set { if (_sendDate != value) { _sendDate = value; OnPropertyChanged(nameof(SendDate)); } }
    }
    public string? SendNo 
    {
        get => _sendNo;
        set { if (_sendNo != value) { _sendNo = value; OnPropertyChanged(nameof(SendNo)); } }
    }
    public string? Attn
    {
        get => _attn;
        set { if (_attn != value) { _attn = value; OnPropertyChanged(nameof(Attn)); } }
    }
    public string? Client
    {
        get => _client;
        set { if (_client != value) { _client = value; OnPropertyChanged(nameof(Client)); } }
    }
    public string? INN
    {
        get => _inn;
        set { if (_inn != value) { _inn = value; OnPropertyChanged(nameof(INN)); } }
    }
    public string? Content 
    {
        get => _content; 
        set { if (_content != value) { _content = value; OnPropertyChanged(nameof(Content)); }}
    }
    public string? Person
    {
        get => _person;
        set { if (_person != value) { _person = value; OnPropertyChanged(nameof(Person)); } }
    }
    public string? Notes
    {
        get => _notes;
        set { if (_notes != value) { _notes = value; OnPropertyChanged(nameof(Notes)); } }
    }
    public string? JDate
    {
        get => _jDate; 
        set { if (_jDate != value) { _jDate = value; OnPropertyChanged(nameof(JDate)); } }
    }
    public string? JNo
    {
        get => _jNo; 
        set { if (_jNo != value) { _jNo = value; OnPropertyChanged(nameof(JNo)); } }
    }
    public string? JSubject
    {
        get => _jSubject; 
        set { if (_jSubject != value) { _jSubject = value; OnPropertyChanged(nameof(JSubject)); } }
    }
    public string? RDate 
    {
        get => _rDate; 
        set { if (_rDate != value) { _rDate = value; OnPropertyChanged(nameof(RDate)); } }
    }
    public string? ODate
    {
        get => _oDate; 
        set { if (_oDate != value) { _oDate = value; OnPropertyChanged(nameof(ODate)); } }
    }
    public string? ONo
    { 
        get => _oNo; 
        set { if (_oNo != value) { _oNo = value; OnPropertyChanged(nameof(ONo)); } }
    }
    public string? Receiver 
    {
        get => _receiver; 
        set { if (_receiver != value) { _receiver = value; OnPropertyChanged(nameof(Receiver)); } }
    }
    public string? OSubject
    {
        get => _oSubject; 
        set { if (_oSubject != value) { _oSubject = value; OnPropertyChanged(nameof(OSubject)); } }
    }

    public ObservableCollection<TrackRecord> TrackRecords
    {
        get => _trackRecords;
        set { if (_trackRecords != value) { _trackRecords = value; OnPropertyChanged(nameof(TrackRecords)); } }
    }
}
