using MediatR;

namespace Application.Commands.Cliente
{
    public class AtualizarClienteCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Porte { get; set; }
    }
}
