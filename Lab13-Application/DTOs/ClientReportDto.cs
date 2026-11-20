namespace Lab13ClosedXML.Application.DTOs;

public class ClientReportDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int TotalOrders { get; set; }
    public decimal TotalSpent { get; set; }
}