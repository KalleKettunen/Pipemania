using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipemania.Nodes
{
    static class NodeExtenions
    {
        public static bool IsFirstNodeFeeder(this IReadOnlyCollection<INode> nodes)
        {
            return nodes.First() is IFeeder;
        }
    }
}
