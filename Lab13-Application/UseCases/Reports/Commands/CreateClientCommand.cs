using Lab13ClosedXML.Application.Interfaces;
using Lab13ClosedXML.Domain.Entities;
using MediatR;

namespace Lab13ClosedXML.Application.UseCases.Clients.Commands;

public record CreateClientCommand(string Name, string Email) : IRequest<int>;

public class CreateClientCommandHandler(IClientRepository clientRepository)
    : IRequestHandler<CreateClientCommand, int>
{
    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        return await clientRepository.AddAsync(client, cancellationToken);
    }
}