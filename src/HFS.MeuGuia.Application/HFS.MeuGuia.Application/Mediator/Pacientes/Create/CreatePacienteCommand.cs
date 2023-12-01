namespace HFS.MeuGuia.Application.Mediator.Pacientes.Create;

public class CreatePacienteCommand : IRequest<PacienteDto>
{
    public string Nome { get; init; } = string.Empty;

}

