using MediatR;

namespace Application.Queries.Cliente
{
    public class GetClienteByIdQuery : IQuery<ClienteDto>
    {
        public Guid Id { get; set; }
    }
}
