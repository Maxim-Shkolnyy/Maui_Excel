﻿using ClosedXML.Excel;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml;

namespace Maui_Excel;

public partial class MainPage : ContentPage
{
    int count = 0;

    private string selectedWorksheet { get; set; }

    public MainPage()
    {
        InitializeComponent();
        worksheetPicker.SelectedIndexChanged += OnWorksheetSelectedIndexChanged;

    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var excelFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>> 
            {
                { DevicePlatform.iOS, new[] { "public.spreadsheetml.sheet", "com.microsoft.excel.xls", "org.openxmlformats.spreadsheetml.sheet" } }, // UTType values for Excel files
                { DevicePlatform.Android, new[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" } }, // MIME types for Excel files
                { DevicePlatform.WinUI, new[] { ".xlsx", ".xls" } }, // file extensions for Excel files
                { DevicePlatform.macOS, new[] { "public.spreadsheetml.sheet", "com.microsoft.excel.xls", "org.openxmlformats.spreadsheetml.sheet" } } // UTType values for Excel files
            });


        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Please select excel file", 
            FileTypes = excelFileType
        });

        var path = result.FullPath;

        targetFilePath.Text = path; 

        if (result == null)
            return;

        var dataFromTargetFile = await result.OpenReadAsync();

        using (XLWorkbook workbook = new XLWorkbook(dataFromTargetFile))
        {
            var worksheet = workbook.Worksheet(1); // Предполагается, что данные находятся в первом листе
            var worksheetNames = workbook.Worksheets.Select(sheet => sheet.Name).ToList();
            worksheetPicker.ItemsSource = worksheetNames;
            worksheetPicker.SelectedIndex = 0; 
            //UpdateSelectedWorksheet();
            //UpdateWorksheetList();


            // Получение диапазона данных в виде двумерного массива 
            //var range = worksheet.RangeUsed();
            //var rowCount = range.RowCount();
            //var columnCount = range.ColumnCount();
            //var data = new string[rowCount, columnCount];

            //for (int row = 1; row <= rowCount; row++)
            //{
            //    for (int column = 1; column <= columnCount; column++)
            //    {
            //        var cellValue = range.Cell(row, column).Value.ToString();
            //        data[row - 1, column - 1] = cellValue;
            //    }
            //}


            //var tBook = new XLWorkbook();
            //var tSheet = tBook.Worksheets.Add("New Sheet");

            //// Заполнение ячеек на листе данными из двумерного массива
            //for (int row = 0; row < rowCount; row++)
            //{
            //    for (int column = 0; column < columnCount; column++)
            //    {
            //        tSheet.Cell(row + 1, column + 1).SetValue(data[row, column]); // принудительное сохранение в строку
            //    }
            //}            
            //tBook.SaveAs("D:\\PathToFile2.xlsx");            
        }
    }

    private void UpdateWorksheetList()
    {
        List<string> worksheetList = new();

        using (IXLWorkbook workbook = new XLWorkbook())
        {
            var worksheetNames = workbook.Worksheets.Select(s => s.Name).ToList();
            worksheetPicker.ItemsSource = worksheetNames;
        }
    }

    private void OnWorksheetSelectedIndexChanged(object sender, EventArgs e)
    {
        selectedWorksheet = worksheetPicker.SelectedItem as string;
        // Здесь можно выполнить действия с выбранным листом, сохранить его в переменной или выполнять другую логику
    }

    private void UpdateSelectedWorksheet()
    { 
        selectedWorksheet = worksheetPicker.SelectedItem as string;
        // Здесь можно выполнить действия с выбранным листом, сохранить его в переменной или выполнять другую логику

        
    }

}



