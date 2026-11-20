namespace Lab13ClosedXML.Application.DTOs;

public class ProductSalesReportDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int UnitsSold { get; set; }
    public decimal TotalSales { get; set; }
}