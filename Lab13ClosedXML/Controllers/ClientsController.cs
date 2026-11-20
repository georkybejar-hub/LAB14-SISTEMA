using Lab13ClosedXML.Application.DTOs;
using Lab13ClosedXML.Application.UseCases.Clients.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13ClosedXML.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [EndpointSummary("Registrar cliente")]
    [EndpointDescription("Crea un nuevo cliente y devuelve su ID.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateClientDto dto, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateClientCommand(dto.Name, dto.Email), cancellationToken);
        return Created($"api/clients/{id}", new { ClientId = id });
    }
}