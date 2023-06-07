﻿using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;

namespace Maui_Excel.Model
{
    public class Models
    {
        public string Path { get; set; } = "jkhklhkjh";
        public Workbook WorkBook { get; set; }
        public Worksheet WorkSheet { get; set; }
        public Cell Cell { get; set; } 
        public IXLRange Range { get; set; }
    }
}
