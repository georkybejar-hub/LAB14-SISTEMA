using Lab13ClosedXML.Application.DTOs;

namespace Lab13ClosedXML.Application.Interfaces;

public interface IProductRepository
{
    Task<List<ProductSalesReportDto>> GetProductSalesReportAsync(CancellationToken cancellationToken);
}