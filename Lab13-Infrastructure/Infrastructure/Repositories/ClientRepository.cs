using Lab13ClosedXML.Application.DTOs;
using Lab13ClosedXML.Application.Interfaces;
using Lab13ClosedXML.Domain.Entities;
using Lab13ClosedXML.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab13ClosedXML.Infrastructure.Repositories;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public async Task<List<ClientReportDto>> GetClientsReportAsync(CancellationToken cancellationToken)
    {
        return await context.Clients
            .AsNoTracking()
            .Select(c => new ClientReportDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email,
                TotalOrders = c.Orders.Count(),
                TotalSpent = c.Orders
                    .SelectMany(o => o.Orderdetails)
                    .Sum(d => (decimal?)(d.Quantity * d.Product.Price)) ?? 0
            })
            .OrderBy(c => c.ClientId)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> AddAsync(Client client, CancellationToken cancellationToken)
    {
        context.Clients.Add(client);
        await context.SaveChangesAsync(cancellationToken);
        return client.ClientId;
    }
}