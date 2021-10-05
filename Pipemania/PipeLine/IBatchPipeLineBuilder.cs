using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.PipeLine
{
    public interface IBatchPipeLineBuilder<TSource>
    {
        IBatchPipeline Close(IBatchEndPoint<TSource> endPoint);
        IBatchPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter);
    }
}