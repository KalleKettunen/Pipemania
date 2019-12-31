using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania.Test.Utils
{
    public interface IAssertingNode : INode
    {
        Task AssertAsync();
    }
}
