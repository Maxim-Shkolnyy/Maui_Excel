using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Excel.Annotations;
using Microsoft.Toolkit.Mvvm.Input;

namespace Maui_Excel.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
            Items = new ObservableCollection<string>();
    }
    [ObservableProperty]
    string text;

    [ObservableProperty]
    ObservableCollection<string> items;

    [RelayCommand]
    void Add()
    {
        if(string.IsNullOrEmpty(text))  
            return; 

        Items.Add(text);
        //add item
        Text = string.Empty;
    }


    public ObservableCollection<Model.Models> Worksheets { get; } = new ObservableCollection<Model.Models>();

    // Метод для загрузки книги Excel и получения списка листов
    private void LoadExcelFile()
    {
        // Логика загрузки книги Excel и получения списка листов
        // ...

        // После получения списка листов, добавьте их в коллекцию Worksheets
        foreach (var worksheet in worksheetsFromExcel)
        {
            Worksheets.Add(new WorksheetModel { Name = worksheet.Name });
        }
    }