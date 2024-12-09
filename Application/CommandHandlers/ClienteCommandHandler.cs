using MediatR;
using Application.Commands.Cliente;
using Domain.Interfaces;
using Domain.Common;
using Domain.Clientes;
using Application.Exceptions;

public class ClienteCommandHandler :
    IRequestHandler<CriarClienteCommand, Guid>,
    IRequestHandler<AtualizarClienteCommand, Unit>,
    IRequestHandler<DeletarClienteCommand, Unit>
{
    private readonly IClienteRepository _repository;

    public ClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
    {
        var porte = Enum.Parse<PorteEmpresa>(request.Porte);
        var cliente = new Cliente(request.NomeEmpresa, porte);
        await _repository.AddAsync(cliente);
        return cliente.Id;
    }

    public async Task<Unit> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.Id);
        if (cliente == null)
        {
            throw new NotFoundException(nameof(Cliente), request.Id);
        }

        cliente.SetNomeEmpresa(request.NomeEmpresa);
        cliente.SetPorte(Enum.Parse<PorteEmpresa>(request.Porte));

        await _repository.UpdateAsync(cliente);

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.Id);
        if (cliente == null)
        {
            throw new NotFoundException(nameof(Cliente), request.Id);
        }

        await _repository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}