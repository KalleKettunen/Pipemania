using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;
using Pipemania.PipeLine;
using Xunit;

namespace Pipemania.Test.Utils
{
    class AssertingPipeline : SealedPipeLine, IBatchPipeline
    {
        private readonly IReadOnlyCollection<IAssertingNode> _nodes;

        public AssertingPipeline(IFeeder feeder, IReadOnlyCollection<IAssertingNode> nodes) : base(feeder)
        {
            _nodes = nodes;
        }

        public override async Task Run()
        {
            if (IsConnected)
            {

                await Feeder.Feed();

                await Task.WhenAll(_nodes.Select(n => n.AssertAsync()));

                IsReady = true;
            }

            Assert.True(false, "Pipeline cannot be tested");
        }

        public bool IsReady { get; private set; }
    }
}
