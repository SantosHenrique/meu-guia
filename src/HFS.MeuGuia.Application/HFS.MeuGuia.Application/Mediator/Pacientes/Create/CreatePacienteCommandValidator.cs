using FluentValidation;
using HFS.MeuGuia.Application.Common.Messages;

namespace HFS.MeuGuia.Application.Mediator.Pacientes.Create;

public class CreatePacienteCommandValidator : AbstractValidator<CreatePacienteCommand>
{
    public CreatePacienteCommandValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage(MensagensValidacao.PreenchimentoObrigatorio);
    }
}
