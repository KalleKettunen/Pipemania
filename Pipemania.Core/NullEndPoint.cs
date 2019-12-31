using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public sealed class NullEndPoint<TSource> : IEndPoint<TSource>
    {
        public Task Receive(TSource source)
        {
            return Task.CompletedTask;
        }

        public bool IsConnected => true;
    }
}
