using ClosedXML.Excel;
using Lab13ClosedXML.Application.Interfaces;

namespace Lab13ClosedXML.Infrastructure.Services;

public class ExcelService : IExcelService
{
    public byte[] GenerateReport<T>(IEnumerable<T> data, string sheetName, string title)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(sheetName);

        var columnCount = typeof(T).GetProperties().Length;

        var titleRange = worksheet.Range(1, 1, 1, columnCount);
        titleRange.Merge();
        titleRange.Value = title;
        titleRange.Style.Font.Bold = true;
        titleRange.Style.Font.FontSize = 14;
        titleRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
        titleRange.Style.Font.FontColor = XLColor.White;
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(2, 1).Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";
        worksheet.Cell(2, 1).Style.Font.Italic = true;

        var table = worksheet.Cell(4, 1).InsertTable(data, sheetName, true);
        table.Theme = XLTableTheme.TableStyleMedium2;
        table.ShowTotalsRow = true;

        foreach (var field in table.Fields)
        {
            var name = field.Name;
            if (name.StartsWith("Total") || name == "Price" || name == "UnitsSold")
            {
                field.TotalsRowFunction = XLTotalsRowFunction.Sum;
            }

            if (name == "Price" || name == "TotalSpent" || name == "TotalSales")
            {
                field.Column.Style.NumberFormat.Format = "\"S/\" #,##0.00";
            }
        }

        table.Fields.First().TotalsRowLabel = "TOTAL";

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}