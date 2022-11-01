using Graphs.Core.Entities;

namespace Graphs.Infrastructure.UnitTests;

public interface IGraphLoader<T>
{
    public Graph<T> Load(string graphContent);
}