using System.Collections.Immutable;

namespace Pipemania.PipeLine
{
    public sealed class BatchPipeLineBuilder<TSource> : PipeLineBuilder<TSource>, IBatchPipeLineBuilder<TSource>
    {
        public BatchPipeLineBuilder(BatchFeeder<TSource> source) : base(source)
        {

        }

        private BatchPipeLineBuilder(IFeeder feeder, ISource<TSource> source, IImmutableList<INode> nodes) : base(feeder, source, nodes)
        {

        }
        
        public IBatchPipeline Close(IBatchEndPoint<TSource> endPoint)
        {
            Source.Connect(endPoint);
            return new SealedBatchPipeLine(Feeder);  
        }

        public IBatchPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter)
        {
            Source.Connect(filter);
            return new BatchPipeLineBuilder<TResult>(Feeder, filter, PipeLine.Add(filter));
        }
    }
}
