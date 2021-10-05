using System.Collections.Generic;
using System.Linq;
using Pipemania.Core.Interfaces;

namespace Pipemania.Nodes
{
    static class NodeExtensions
    {
        public static bool IsFirstNodeFeeder(this IReadOnlyCollection<INode> nodes)
        {
            return nodes.First() is IFeeder;
        }
    }
}
