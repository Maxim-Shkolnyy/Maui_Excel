using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Excel.Annotations;
using Microsoft.Toolkit.Mvvm.Input;

namespace Maui_Excel.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]

}