using Application.Commands.Cliente;

namespace Application.DTOs.Cliente
{
    public interface IClienteService
    {
        Task<Guid> CriarClienteAsync(CriarClienteCommand command);
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<ClienteDto> GetClienteByIdAsync(Guid id);
        Task AtualizarClienteAsync(AtualizarClienteCommand command);
        Task DeletarClienteAsync(Guid id);
    }
}



