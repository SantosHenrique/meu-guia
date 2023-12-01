namespace HFS.MeuGuia.Application.Mediator.Pacientes.Create;

public class CreatePacieteCommand : IRequest<PacienteDto>
{
    public string Nome { get; init; } = string.Empty;

}

