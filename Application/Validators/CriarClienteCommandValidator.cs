// ClienteApp.Application/Validators/CriarClienteCommandValidator.cs
using Application.Commands.Cliente;
using Domain.Common;
using FluentValidation;

public class CriarClienteCommandValidator : AbstractValidator<CriarClienteCommand>
{
    public CriarClienteCommandValidator()
    {
        RuleFor(x => x.NomeEmpresa).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Porte).IsEnumName(typeof(PorteEmpresa));
    }
}