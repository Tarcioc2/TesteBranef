using MediatR;

namespace Application.Commands.Cliente
{
    public class CriarClienteCommand : ICommand<Guid>
    {
        public string NomeEmpresa { get; set; }
        public string Porte { get; set; }
    }
}