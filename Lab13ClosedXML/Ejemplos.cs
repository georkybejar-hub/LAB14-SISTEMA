using ClosedXML.Excel;

namespace Lab13ClosedXML;

public class Ejemplos
{
    public void FirstExample()
    {
        // Crear un nuevo libro de trabajo de Excel
        using (var workbook = new XLWorkbook())
        {
            // Crear una hoja de trabajo
            var worksheet = workbook.Worksheets.Add("Hoja1");

            // Agregar algunos datos
            worksheet.Cell(1, 1).Value = "Nombre";
            worksheet.Cell(1, 2).Value = "Edad";
            worksheet.Cell(2, 1).Value = "Juan";
            worksheet.Cell(2, 2).Value = 28;

            // Guardar el archivo en la ubicación deseada
            workbook.SaveAs("C:\\ruta\\a\\tu\\archivo.xlsx");
        }
    }

    public void SecondExample()
    {
        // Abrir el archivo de Excel existente
        using (var workbook = new XLWorkbook("C:\\ruta\\a\\tu\\archivo.xlsx"))
        {
            // Obtener la primera hoja de trabajo
            var worksheet = workbook.Worksheet(1);

            // Modificar una celda existente
            worksheet.Cell(2, 2).Value = 30;

            // Guardar el archivo con los cambios
            workbook.Save();
        }
    }
    public void ThirdExample()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Datos");

            // Agregar los datos de la tabla
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nombre";
            worksheet.Cell(1, 3).Value = "Edad";

            worksheet.Cell(2, 1).Value = 1;
            worksheet.Cell(2, 2).Value = "Juan";
            worksheet.Cell(2, 3).Value = 28;

            worksheet.Cell(3, 1).Value = 2;
            worksheet.Cell(3, 2).Value = "María";
            worksheet.Cell(3, 3).Value = 34;

            // Crear una tabla con los datos
            var range = worksheet.Range("A1:C3");
            range.CreateTable();

            // Guardar el archivo con la tabla
            workbook.SaveAs("C:\\ruta\\a\\tu\\tabla.xlsx");
        }
    }
    public void FourthExample()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Estilos");

            // Aplicar un formato a la primera fila
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Agregar datos
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nombre";
            worksheet.Cell(1, 3).Value = "Edad";

            worksheet.Cell(2, 1).Value = 1;
            worksheet.Cell(2, 2).Value = "Juan";
            worksheet.Cell(2, 3).Value = 28;

            // Guardar el archivo con formato
            workbook.SaveAs("C:\\ruta\\a\\tu\\archivo_con_estilos.xlsx");
        }
    }
}
