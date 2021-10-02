using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Pipemania.PipeLine
{
    public sealed class ContinuousPipeLineBuilder<TSource> : PipeLineBuilder<TSource>, IContinuousPipeLineBuilder<TSource>
    {
        public ContinuousPipeLineBuilder(ContinuousFeeder<TSource> source) : base(source)
        {

        }

        private ContinuousPipeLineBuilder(IFeeder feeder,ISource<TSource> source, IImmutableList<INode> nodes) : base(feeder, source, nodes)
        {

        }

        public ISealedPipeLine<Task> Close(Consumer<TSource> endPoint)
        {
            Source.Connect(endPoint);
            return new ContinuousPipeLine(Feeder);
        }

        public ContinuousPipeLine<TSource> Create(IContinuousEndPoint<TSource> endPoint)
        {
            Source.Connect(endPoint);
            return new ContinuousPipeLine<TSource>(Feeder, endPoint);
        }

        public IContinuousPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter)
        {
            Source.Connect(filter);
            return new ContinuousPipeLineBuilder<TResult>(Feeder, filter, PipeLine.Add(filter));
        }

        public ISealedPipeLine<Task> Close(IContinuousEndPoint<TSource> endPoint)
        {
            Source.Connect(endPoint);
            return new ContinuousPipeLine(Feeder);
        }
    }
}