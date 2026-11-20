using Lab13ClosedXML.Application.Interfaces;
using MediatR;

namespace Lab13ClosedXML.Application.UseCases.Reports.Queries;

public record GetClientsReportQuery : IRequest<byte[]>;

public class GetClientsReportQueryHandler(
    IClientRepository clientRepository,
    IExcelService excelService) : IRequestHandler<GetClientsReportQuery, byte[]>
{
    public async Task<byte[]> Handle(GetClientsReportQuery request, CancellationToken cancellationToken)
    {
        var clients = await clientRepository.GetClientsReportAsync(cancellationToken);
        return excelService.GenerateReport(clients, "Clientes", "Reporte de Clientes y Pedidos");
    }
}