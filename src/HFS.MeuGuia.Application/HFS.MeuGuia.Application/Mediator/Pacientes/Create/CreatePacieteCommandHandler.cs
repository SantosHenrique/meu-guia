
namespace HFS.MeuGuia.Application.Mediator.Pacientes.Create;

public class CreatePacieteCommandHandler : IRequestHandler<CreatePacienteCommand, PacienteDto>
{
    public Task<PacienteDto> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
