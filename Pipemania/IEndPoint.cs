using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania
{
    public interface IEndPoint<in TSource> : INode
    {
        Task Receive(TSource source);
    }
}
