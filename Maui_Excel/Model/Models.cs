using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;

namespace Maui_Excel.Model
{
    public class Models
    {
        public string Path { get; set; } = "Оце так шлях!";
        public Workbook WorkBook { get; set; }
        public Worksheet WorkSheetName { get; set; }
        public Cell Cell { get; set; } 
        public IXLRange Range { get; set; }
    }
}
