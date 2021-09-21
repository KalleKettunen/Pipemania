using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipemania
{
    public interface ISource<out TSource> : INode
    {
        void Connect(IEndPoint<TSource> endPoint);
        ISource<TResult> Connect<TResult>(IFilter<TSource, TResult> filter);
    }

    public abstract class Source<TSource> : ISource<TSource>
    {
        public virtual bool IsConnected => EndPoints.Any(e => e.IsConnected);
        public virtual void Connect(IEndPoint<TSource> endPoint)
        {
            EndPoints.Add(endPoint); ;
        }

        public ISource<TResult> Connect<TResult>(IFilter<TSource, TResult> filter)
        {
            Connect(filter as IEndPoint<TSource>);
            return filter;
        }

        protected virtual ICollection<IEndPoint<TSource>> EndPoints { get; } =  new List<IEndPoint<TSource>>();
    }
}
