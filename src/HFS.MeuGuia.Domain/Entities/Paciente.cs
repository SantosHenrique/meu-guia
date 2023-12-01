using HFS.MeuGuia.Domain.Common;

namespace HFS.MeuGuia.Domain.Entities;

public class Paciente : BaseEntity
{
    public string Nome { get; init; } = string.Empty;
}

