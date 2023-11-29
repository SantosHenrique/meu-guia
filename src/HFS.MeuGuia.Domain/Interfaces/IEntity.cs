
namespace HFS.MeuGuia.Domain.Interfaces
{
    internal interface IEntity<T>
    {
        T Id { get; init; }
    }
}
