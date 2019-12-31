using Pipemania.PipeLine;

namespace Pipemania
{
    public interface IPipeLineBuilder<TSource>
    {
        IPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter);
        ISealedPipeLine Close(IEndPoint<TSource> endPoint);
    }

    public interface IPipeLineBuilder<TSource, TPipeLine>
    {
        IPipeLineBuilder<TSource, TResult> Filter<TResult>(IFilter<TPipeLine, TResult> filter);
        IPipeLine<TSource> Close(IEndPoint<TPipeLine> endPoint);
    }
}
