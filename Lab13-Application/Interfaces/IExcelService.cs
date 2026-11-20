namespace Lab13ClosedXML.Application.Interfaces;

public interface IExcelService
{
    byte[] GenerateReport<T>(IEnumerable<T> data, string sheetName, string title);
}