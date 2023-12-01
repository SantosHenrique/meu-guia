
namespace HFS.MeuGuia.Application.Mediator.Pacientes.Create;

public class CreatePacieteCommandHandler : IRequestHandler<CreatePacieteCommand, PacienteDto>
{
    public Task<PacienteDto> Handle(CreatePacieteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
