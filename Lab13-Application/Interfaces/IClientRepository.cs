using Lab13ClosedXML.Application.DTOs;
using Lab13ClosedXML.Domain.Entities;

namespace Lab13ClosedXML.Application.Interfaces;

public interface IClientRepository
{
    Task<List<ClientReportDto>> GetClientsReportAsync(CancellationToken cancellationToken);
    Task<int> AddAsync(Client client, CancellationToken cancellationToken);
}