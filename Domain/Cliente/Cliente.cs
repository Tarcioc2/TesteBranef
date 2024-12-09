using Domain.Common;

namespace Domain.Clientes
{
    public class Cliente
    {
        // Construtor privado para EF Core
        private Cliente() { }

        public Cliente(string nomeEmpresa, PorteEmpresa porte)
        {
            Id = Guid.NewGuid();
            SetNomeEmpresa(nomeEmpresa);
            SetPorte(porte);
        }
        public Guid Id { get; private set; }
        public string NomeEmpresa { get; private set; }
        public PorteEmpresa Porte { get; private set; }


        public void SetNomeEmpresa(string nomeEmpresa)
        {
            if (string.IsNullOrWhiteSpace(nomeEmpresa))
                throw new ArgumentException("Nome da empresa não pode ser vazio.", nameof(nomeEmpresa));

            NomeEmpresa = nomeEmpresa;
        }

        public void SetPorte(PorteEmpresa porte)
        {
            Porte = porte;
        }
    }
}