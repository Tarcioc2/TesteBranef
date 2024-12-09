using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Application.Queries.Cliente;
using Application.Exceptions;

namespace Application.QueryHandlers.Cliente
{
    public class ClienteQueryHandler :
        IRequestHandler<GetClientesQuery, IEnumerable<ClienteDto>>,
        IRequestHandler<GetClienteByIdQuery, ClienteDto>
    {
        private readonly string _connectionString;

        public ClienteQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<ClienteDto>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            const string sql = @"
                SELECT Id, NomeEmpresa, Porte
                FROM Clientes with(nolock)";

            return await connection.QueryAsync<ClienteDto>(sql);
        }

        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            const string sql = @"
                SELECT Id, NomeEmpresa, Porte
                FROM Clientes with(nolock)
                WHERE Id = @Id";

            var cliente = await connection.QuerySingleOrDefaultAsync<ClienteDto>(sql, new { Id = request.Id });

            if (cliente == null)
            {
                throw new NotFoundException(nameof(Domain.Clientes), request.Id);
            }

            return cliente;
        }
    }
}