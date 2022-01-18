using Rosd.Wpf.Data;

using System;
using System.Windows;
using System.Windows.Input;

namespace Rosd.Wpf.ViewModels;

public class ClientViewModel
{
    private readonly ICommand _saveCommand;
    private readonly ICommand _resetCommand;
    private readonly ICommand _editCommand;
    private readonly ICommand _deleteCommand;

    private readonly ClientRepository _repository = new();
    private readonly Client _entity = new();

    public ClientRecord ClientRecord { get; set; } = new();

    public ClientViewModel()
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

    public void SaveData()
    {
        _entity.Id = ClientRecord.Id;
        _entity.INN = ClientRecord.INN;
        _entity.Title = ClientRecord.Title;

        try
        {
            if (ClientRecord.Id <= 0)
            {
                _repository.Add(_entity);
                MessageBox.Show("New record successfully saved.");
            }
            else
            {
                _entity.Id = ClientRecord.Id;
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
        ClientRecord.Id = 0;
        ClientRecord.INN = string.Empty;
        ClientRecord.Title = string.Empty;
    }

    public void EditData(int id)
    {
        var model = _repository.Get(id);

        ClientRecord.Id = model.Id;
        ClientRecord.INN = model.INN;
        ClientRecord.Title = model.Title;
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
        ClientRecord.ClientRecords = new();
        _repository.GetAll().ForEach(data => ClientRecord.ClientRecords.Add(new()
        {
            Id = data.Id,
            INN = data.INN,
            Title = data.Title
        }));
    }
}
