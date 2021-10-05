using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Test.Utils
{
    public class AssertingNodeDecorator : IAssertingNode
    {
        private readonly INode _node;
        public bool IsConnected => _node.IsConnected;
        public Task AssertAsync()
        {
            throw new NotImplementedException();
        }

        public AssertingNodeDecorator(INode node)
        {
            _node = node;
        }
    }
}
