using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.PipeLine
{
    public sealed class SealedBatchPipeLine : SealedPipeLine, IBatchPipeline 
    {
        public SealedBatchPipeLine(IFeeder feeder) : base(feeder)
        {
        }

        public override async Task Run()
        {
            if (IsConnected)
            {
                await Feeder.Feed();
                IsReady = true;
            }
        }

        public bool IsReady { get; private set; }
    }
}