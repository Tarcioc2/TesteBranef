using Application.Commands.Cliente;
using Application.DTOs.Cliente;
using Application.Queries.Cliente;
using MediatR;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMediator _mediator;

        public ClienteService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> CriarClienteAsync(CriarClienteCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            return await _mediator.Send(new GetClientesQuery());
        }

        public async Task<ClienteDto> GetClienteByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetClienteByIdQuery(id));
        }

        public async Task AtualizarClienteAsync(AtualizarClienteCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task DeletarClienteAsync(Guid id)
        {
            await _mediator.Send(new DeletarClienteCommand { Id = id });
        }
    }

}

