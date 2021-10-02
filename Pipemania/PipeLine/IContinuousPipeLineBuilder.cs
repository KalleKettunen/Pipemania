using System.Threading.Tasks;

namespace Pipemania.PipeLine
{
    public interface IContinuousPipeLineBuilder<TSource>
    {
        ISealedPipeLine<Task> Close(IContinuousEndPoint<TSource> endPoint);
        ISealedPipeLine<Task> Close(Consumer<TSource> endPoint);
        ContinuousPipeLine<TSource> Create(IContinuousEndPoint<TSource> endPoint);
        IContinuousPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter);
    }
}