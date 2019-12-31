using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania
{

    public interface IPipeLine<TSource>
    {

    }

    public interface IPipeLine<TSource, TResult> : IFilter<TSource, TResult>
    {

    }

    public interface IContinuousPipeLine<TSource, TResult> : IPipeLine<TSource, TResult>
    {
        Task<TResult> Start();
        Task Stop();
    }
}
