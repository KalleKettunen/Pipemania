using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pipemania.PipeLine
{
    public class ContinuousPipeLine : SealedPipeLine<Task>
    {
        public ContinuousPipeLine(IFeeder feeder) : base(feeder)
        {
        }

        public override async Task Run()
        {
            if (IsConnected)
            {
                await Feeder.Feed();
            }
        }
    }

    public class ContinuousPipeLine<T> : ContinuousPipeLine, IAsyncEnumerable<T>
    {
        private readonly IContinuousEndPoint<T> _endPoint;

        public ContinuousPipeLine(IFeeder feeder, IContinuousEndPoint<T> endPoint) : base(feeder)
        {
            _endPoint = endPoint;
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return _endPoint.GetAsyncEnumerator(cancellationToken);
        }
    }
}