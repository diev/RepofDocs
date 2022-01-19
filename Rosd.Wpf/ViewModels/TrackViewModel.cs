using Rosd.Wpf.Data;

using System;
using System.Windows;
using System.Windows.Input;

namespace Rosd.Wpf.ViewModels;

public class TrackViewModel
{
    private readonly ICommand _addCommand;
    private readonly ICommand _cloneCommand;
    private readonly ICommand _editCommand;
    private readonly ICommand _deleteCommand;
    private readonly ICommand _saveCommand;
    private readonly ICommand _resetCommand;

    private readonly TrackRepository _repository = new();

    public TrackViewModel()
    {
        _addCommand = new RelayCommand(param => AddData(), null);
        _cloneCommand = new RelayCommand(param => CloneData((int)param), null);
        _editCommand = new RelayCommand(param => EditData((int)param), null);
        _deleteCommand = new RelayCommand(param => DeleteData((int)param), null);
        _saveCommand = new RelayCommand(param => SaveData(), null);
        _resetCommand = new RelayCommand(param => ResetData(), null);

        GetAll();
    }

    public ICommand AddCommand => _addCommand;
    public ICommand CloneCommand => _cloneCommand;
    public ICommand EditCommand => _editCommand;
    public ICommand DeleteCommand => _deleteCommand;
    public ICommand SaveCommand => _saveCommand;
    public ICommand ResetCommand => _resetCommand;

    public TrackRecord TrackRecord { get; set; } = new();

    public void AddData()
    {
        EditData(0);
    }

    public void CloneData(int id)
    {
        EditData(-id);
        TrackRecord.Id = id;
    }

    public void EditData(int id)
    {
        var data = _repository.Get(id);
        TrackRecord = TrackRecord.Load(data);
    }

    public void DeleteData(int id)
    {
        if (MessageBox.Show("Confirm delete of this record?", App.Title, MessageBoxButton.YesNo)
            == MessageBoxResult.Yes)
        {
            try
            {
                _repository.Remove(id);
                MessageBox.Show("Record successfully deleted.", App.Title);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while saving. " + ex.InnerException, App.Title);
            }
            finally
            {
                GetAll();
            }
        }
    }

    public void SaveData()
    {
        var data = TrackRecord.Save(TrackRecord);

        try
        {
            if (TrackRecord.Id <= 0)
            {
                _repository.Add(data);
                MessageBox.Show("New record successfully added.", App.Title);
            }
            else
            {
                data.Id = TrackRecord.Id;
                _repository.Update(data);
                MessageBox.Show("Record successfully updated.", App.Title);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error occured while saving: " + ex.InnerException, App.Title);
        }
        finally
        {
            GetAll();
            ResetData();
        }
    }

    public void ResetData()
    {
        TrackRecord = new();
    }

    public void GetAll()
    {
        TrackRecord.TrackRecords = new();
        _repository.GetAll().ForEach(data => TrackRecord.TrackRecords.Add(TrackRecord.Load(data))); //TODO simplify
    }
}
