using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania
{

    public abstract class Consumer<TSource> : IEndPoint<TSource>
    {
        public abstract Task Receive(TSource source);

        public virtual bool IsConnected => true;
    }
}
