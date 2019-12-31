using System.Collections.Generic;

namespace Pipemania
{
    public interface ISource<out TSource> : INode
    {
        void Connect(IEndPoint<TSource> endPoint);
        ISource<TResult> Connect<TResult>(IFilter<TSource, TResult> filter);
    }

    public abstract class Source<TSource> : ISource<TSource>
    {
        public abstract bool IsConnected { get; }
        public virtual void Connect(IEndPoint<TSource> endPoint)
        {
            EndPoints.Add(endPoint);
        }

        public ISource<TResult> Connect<TResult>(IFilter<TSource, TResult> filter)
        {
            Connect(filter as IEndPoint<TSource>);
            return filter;
        }

        public abstract ICollection<IEndPoint<TSource>> EndPoints { get; }
    }
}
