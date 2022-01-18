using Rosd.Wpf.Data;

using System;
using System.Windows;
using System.Windows.Input;

namespace Rosd.Wpf.ViewModels;

public class TrackViewModel
{
    private readonly ICommand _saveCommand;
    private readonly ICommand _resetCommand;
    private readonly ICommand _editCommand;
    private readonly ICommand _deleteCommand;

    private readonly TrackRepository _repository = new();
    private readonly Track _entity = new();

    public TrackViewModel()
    {
        _saveCommand = new RelayCommand(param => SaveData(), null);
        _resetCommand = new RelayCommand(param => ResetData(), null);
        _editCommand = new RelayCommand(param => EditData((int)param), null);
        _deleteCommand = new RelayCommand(param => DeleteData((int)param), null);

        GetAll();
    }

    public ICommand SaveCommand => _saveCommand;
    public ICommand ResetCommand => _resetCommand;
    public ICommand EditCommand => _editCommand;
    public ICommand DeleteCommand => _deleteCommand;

    public TrackRecord TrackRecord { get; set; } = new();

    public void SaveData()
    {
        _entity.Id = TrackRecord.Id;
        _entity.IDate = TrackRecord.IDate;
        _entity.INo = TrackRecord.INo;
        _entity.Via = TrackRecord.Via;
        _entity.Sender = TrackRecord.Sender;
        _entity.SendDate = TrackRecord.SendDate;
        _entity.SendNo = TrackRecord.SendNo;
        _entity.Attn = TrackRecord.Attn;
        _entity.Client = TrackRecord.Client;
        _entity.INN = TrackRecord.INN;
        _entity.Content = TrackRecord.Content;
        _entity.Person = TrackRecord.Person;
        _entity.Notes = TrackRecord.Notes;
        _entity.JDate = TrackRecord.JDate;
        _entity.JNo = TrackRecord.JNo;
        _entity.JSubject = TrackRecord.JSubject;
        _entity.RDate = TrackRecord.RDate;
        _entity.ODate = TrackRecord.ODate;
        _entity.ONo = TrackRecord.ONo;
        _entity.Receiver = TrackRecord.Receiver;
        _entity.OSubject = TrackRecord.OSubject;

        try
        {
            if (TrackRecord.Id <= 0)
            {
                _repository.Add(_entity);
                MessageBox.Show("New record successfully saved.");
            }
            else
            {
                _entity.Id = TrackRecord.Id;
                _repository.Update(_entity);
                MessageBox.Show("New record successfully saved.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error occured while saving. " + ex.InnerException);
        }
        finally
        {
            GetAll();
            ResetData();
        }
    }

    public void ResetData()
    {
        TrackRecord.Id = 0;
        TrackRecord.IDate = string.Empty;
        TrackRecord.INo = 0;
        TrackRecord.Via = string.Empty;
        TrackRecord.Sender = string.Empty;
        TrackRecord.SendDate = string.Empty;
        TrackRecord.SendNo = string.Empty;
        TrackRecord.Attn = string.Empty;
        TrackRecord.Client = string.Empty;
        TrackRecord.INN = string.Empty;
        TrackRecord.Content = string.Empty;
        TrackRecord.Person = string.Empty;
        TrackRecord.Notes = string.Empty;
        TrackRecord.JDate = string.Empty;
        TrackRecord.JNo = string.Empty;
        TrackRecord.JSubject = string.Empty;
        TrackRecord.RDate = string.Empty;
        TrackRecord.ODate = string.Empty;
        TrackRecord.ONo = string.Empty;
        TrackRecord.Receiver = string.Empty;
        TrackRecord.OSubject = string.Empty;
    }

    public void EditData(int id)
    {
        var model = _repository.Get(id);

        TrackRecord.Id = model.Id;
        TrackRecord.IDate = model.IDate;
        TrackRecord.INo = (int)model.INo;
        TrackRecord.Via = model.Via;
        TrackRecord.Sender = model.Sender;
        TrackRecord.SendDate = model.SendDate;
        TrackRecord.SendNo = model.SendNo;
        TrackRecord.Attn = model.Attn;
        TrackRecord.Client = model.Client;
        TrackRecord.INN = model.INN;
        TrackRecord.Content = model.Content;
        TrackRecord.Person = model.Person;
        TrackRecord.Notes = model.Notes;
        TrackRecord.JDate = model.JDate;
        TrackRecord.JNo = model.JNo;
        TrackRecord.JSubject = model.JSubject;
        TrackRecord.RDate = model.RDate;
        TrackRecord.ODate = model.ODate;
        TrackRecord.ONo = model.ONo;
        TrackRecord.Receiver = model.Receiver;
        TrackRecord.OSubject = model.OSubject;
    }

    public void DeleteData(int id)
    {
        if (MessageBox.Show("Confirm delete of this record?", "Запись", MessageBoxButton.YesNo)
            == MessageBoxResult.Yes)
        {
            try
            {
                _repository.Remove(id);
                MessageBox.Show("Record successfully deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while saving. " + ex.InnerException);
            }
            finally
            {
                GetAll();
            }
        }
    }

    public void GetAll()
    {
        TrackRecord.TrackRecords = new();
        _repository.GetAll().ForEach(data => TrackRecord.TrackRecords.Add(new()
        {
            Id = data.Id,
            IDate = data.IDate,
            INo = Convert.ToInt32(data.INo),
            Via = data.Via,
            Sender = data.Sender,
            SendDate = data.SendDate,
            SendNo = data.SendNo,
            Attn = data.Attn,
            Client = data.Client,
            INN = data.INN,
            Content = data.Content,
            Person = data.Person,
            Notes = data.Notes,
            JDate = data.JDate,
            JNo = data.JNo,
            JSubject = data.JSubject,
            RDate = data.RDate,
            ODate = data.ODate,
            ONo = data.ONo,
            Receiver = data.Receiver,
            OSubject = data.OSubject,
        }));
    }
}
