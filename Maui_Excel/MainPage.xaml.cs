using ClosedXML.Excel;

namespace Maui_Excel;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}


    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var excelFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.iOS, new[] { "public.spreadsheetml.sheet", "com.microsoft.excel.xls", "org.openxmlformats.spreadsheetml.sheet" } }, // UTType values for Excel files
                { DevicePlatform.Android, new[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" } }, // MIME types for Excel files
                { DevicePlatform.WinUI, new[] { ".xlsx", ".xls" } }, // file extensions for Excel files
                { DevicePlatform.Tizen, new[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" } }, // MIME types for Excel files
                { DevicePlatform.macOS, new[] { "public.spreadsheetml.sheet", "com.microsoft.excel.xls", "org.openxmlformats.spreadsheetml.sheet" } } // UTType values for Excel files
            });


        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Please select excel file",
            FileTypes = excelFileType
        });

        if (result == null)
            return;

        var dataFromTargetFile = await result.OpenReadAsync();

        using (var workbook = new XLWorkbook(dataFromTargetFile))
        {
            var worksheet = workbook.Worksheet(1); // Предполагается, что данные находятся в первом листе

            // Получение диапазона данных в виде двумерного массива
            var range = worksheet.RangeUsed();
            var rowCount = range.RowCount();
            var columnCount = range.ColumnCount();
            var data = new string[rowCount, columnCount];

            for (int row = 1; row <= rowCount; row++)
            {
                for (int column = 1; column <= columnCount; column++)
                {
                    var cellValue = range.Cell(row, column).Value.ToString();
                    data[row - 1, column - 1] = cellValue;
                }
            }

            // Используйте массив данных по вашему усмотрению
            // Например, можно вывести данные в консоль
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    Console.WriteLine($"Cell [{row + 1},{column + 1}]: {data[row, column]}");
                }
            }





            //count++;

            //if (count == 1)
            //	CounterBtn.Text = $"Clicked {count} time";
            //else
            //	CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}

