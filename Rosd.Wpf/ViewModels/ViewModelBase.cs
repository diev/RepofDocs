﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rosd.Wpf.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName]string propertyValue = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
    }
}
