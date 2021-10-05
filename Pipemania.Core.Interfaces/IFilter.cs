namespace Pipemania.Core.Interfaces
{
    public interface IFilter<in TSource, out TResult> : ISource<TResult>, IEndPoint<TSource>
    {
    }
}
