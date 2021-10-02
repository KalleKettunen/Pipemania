using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipemania
{
    public interface IEndPoint<in TSource> : INode
    {
        Task Receive(TSource source);
    }

    public interface IBatchEndPoint<TSource> : IEndPoint<TSource>
    {
        Task<TSource> Result();
    }

    public interface IContinuousEndPoint<TSource> : IEndPoint<TSource>, IAsyncEnumerable<TSource>
    {
    }
}
