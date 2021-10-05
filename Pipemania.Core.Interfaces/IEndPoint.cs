using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipemania.Core.Interfaces
{
    public interface IEndPoint<in TSource> : INode
    {
        Task Receive(TSource source);
        void Ready(bool ready);
    }

    public interface IBatchEndPoint<in TSource> : IEndPoint<TSource>
    {
    }

    public interface IContinuousEndPoint<TSource> : IEndPoint<TSource>, IAsyncEnumerable<TSource>
    {
    }
}
