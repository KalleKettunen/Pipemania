using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipemania.PipeLine;
using Xunit;

namespace Pipemania.Test.Utils
{
    class AssertingPipeline : SealedPipeLine, IBatchPipeline
    {
        private readonly IReadOnlyCollection<IAssertingNode> _nodes;

        public AssertingPipeline(IReadOnlyCollection<IAssertingNode> nodes) : base(nodes)
        {
            _nodes = nodes;
        }

        public override async Task Run()
        {
            if (IsConnected && Nodes.First() is IFeeder feeder)
            {

                await feeder.Feed();

                await Task.WhenAll(_nodes.Select(n => n.AssertAsync()));

                IsReady = true;
            }

            Assert.True(false, "Pipeline cannot be tested");
        }

        public bool IsReady { get; private set; }
    }
}
