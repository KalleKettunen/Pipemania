using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public class FunctionMapper<TSource, TResult> : Mapper<TSource, TResult>
    {
        private readonly Func<TSource, TResult> _func;

        public FunctionMapper(Func<TSource, TResult> func)
        {
            _func = func;
        }

        public override bool IsConnected  => EndPoints.Any(e => e.IsConnected);
        public override ICollection<IEndPoint<TResult>> EndPoints { get; } = new List<IEndPoint<TResult>>();
        public override Task<TResult> Map(TSource source)
        {
            return Task.FromResult(_func(source));
        }
    }
}
