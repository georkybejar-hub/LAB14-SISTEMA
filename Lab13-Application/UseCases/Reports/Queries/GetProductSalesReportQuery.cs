using Lab13ClosedXML.Application.Interfaces;
using MediatR;

namespace Lab13ClosedXML.Application.UseCases.Reports.Queries;

public record GetProductSalesReportQuery : IRequest<byte[]>;

public class GetProductSalesReportQueryHandler(
    IProductRepository productRepository,
    IExcelService excelService) : IRequestHandler<GetProductSalesReportQuery, byte[]>
{
    public async Task<byte[]> Handle(GetProductSalesReportQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductSalesReportAsync(cancellationToken);
        return excelService.GenerateReport(products, "Ventas", "Reporte de Ventas por Producto");
    }
}