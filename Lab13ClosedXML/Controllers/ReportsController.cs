using Lab13ClosedXML.Application.UseCases.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13ClosedXML.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IMediator mediator) : ControllerBase
{
    private const string ExcelContentType =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    [HttpGet("clients")]
    [EndpointSummary("Reporte de clientes")]
    [EndpointDescription("Genera un Excel con cada cliente, su cantidad de pedidos y el total gastado.")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, ExcelContentType)]
    public async Task<IActionResult> GetClientsReport(CancellationToken cancellationToken)
    {
        var file = await mediator.Send(new GetClientsReportQuery(), cancellationToken);
        return File(file, ExcelContentType, $"ReporteClientes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }

    [HttpGet("product-sales")]
    [EndpointSummary("Reporte de ventas por producto")]
    [EndpointDescription("Genera un Excel con las unidades vendidas y el total vendido de cada producto.")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, ExcelContentType)]
    public async Task<IActionResult> GetProductSalesReport(CancellationToken cancellationToken)
    {
        var file = await mediator.Send(new GetProductSalesReportQuery(), cancellationToken);
        return File(file, ExcelContentType, $"ReporteVentas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }
}