using System.Collections.Generic;
using MediatR;

namespace Application.Queries.Cliente
{
    public class GetClientesQuery : IQuery<IEnumerable<ClienteDto>>
    {
    }
}