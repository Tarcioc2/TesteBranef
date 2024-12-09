using System.Data;
using Dapper;
using MediatR;
using Application.Queries.Cliente;
using Application.Exceptions;
using Domain.Interfaces;

namespace Application.QueryHandlers.Cliente
{
    public class ClienteQueryHandler :
    IRequestHandler<GetClientesQuery, IEnumerable<ClienteDto>>,
    IRequestHandler<GetClienteByIdQuery, ClienteDto>
    {
        private readonly IClienteRepository _repository;

        public ClienteQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repository.GetAllAsync();
            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                NomeEmpresa = c.NomeEmpresa,
                Porte = c.Porte.ToString()
            });
        }

        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);
            if (cliente == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Id);
            }

            return new ClienteDto
            {
                Id = cliente.Id,
                NomeEmpresa = cliente.NomeEmpresa,
                Porte = cliente.Porte.ToString()
            };
        }
    }
}


