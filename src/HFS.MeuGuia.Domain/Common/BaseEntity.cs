using HFS.MeuGuia.Domain.Interfaces;

namespace HFS.MeuGuia.Domain.Common
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; init; }
    }
}
