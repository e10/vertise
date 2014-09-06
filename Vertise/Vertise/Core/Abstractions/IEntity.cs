namespace Vertise.Core.Abstractions
{
    public interface IEntity : ISoftDelete {
        int Id { get; }
    }
}