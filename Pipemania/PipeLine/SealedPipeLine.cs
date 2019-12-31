using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pipemania.PipeLine
{
    public interface ISealedPipeLine
    {
        bool IsConnected { get; }
        Task Run();
    }

    public interface IBatchPipeline : ISealedPipeLine
    {
        bool IsReady { get; }
    }

    public abstract class SealedPipeLine : ISealedPipeLine
    {
        protected readonly IReadOnlyCollection<INode> Nodes;

        protected SealedPipeLine(IReadOnlyCollection<INode> nodes)
        {
            Nodes = nodes;
        }


        public bool IsConnected => Nodes.All(n => n.IsConnected);
        public abstract Task Run();
        
    }

    public sealed class SealedBatchPipeLine : SealedPipeLine, IBatchPipeline
    {
        public SealedBatchPipeLine(IReadOnlyCollection<INode> nodes) : base(nodes)
        {
        }

        public override async Task Run()
        {
            if (IsConnected && Nodes.First() is IFeeder feeder)
            {
                
                await feeder.Feed();
                IsReady = true;
            }
        }

        public bool IsReady { get; private set; }
    }
}
