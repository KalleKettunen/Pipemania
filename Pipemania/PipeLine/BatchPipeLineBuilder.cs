using System;
using System.Collections.Immutable;

namespace Pipemania.PipeLine
{
    public class BatchPipeLineBuilder<TSource> : IPipeLineBuilder<TSource>
    {
        private readonly ISource<TSource> _source;
        private readonly IImmutableList<INode> _pipeLine;

        public BatchPipeLineBuilder(ISource<TSource> source) : this(source, ImmutableList.Create<INode>(source))
        {

        }

        protected BatchPipeLineBuilder(ISource<TSource> source, IImmutableList<INode> pipeLine)
        {
            _source = source;
            _pipeLine = pipeLine;
        }

        public IPipeLineBuilder<TResult> Filter<TResult>(IFilter<TSource, TResult> filter)
        {
            _source.Connect(filter);
            return new BatchPipeLineBuilder<TResult>(filter, _pipeLine.Add(filter));
        }

        public ISealedPipeLine Close(IEndPoint<TSource> endPoint)
        {
            _source.Connect(endPoint);
            return new SealedBatchPipeLine(_pipeLine.Add(endPoint).ToImmutableList());
        }
    }
    class BatchPipeLineBuilder<TSource, TPipeLine> : IPipeLineBuilder<TSource, TPipeLine>
    {
        private readonly ISource<TSource> _first;
        private readonly ISource<TPipeLine> _current;

        public BatchPipeLineBuilder(ISource<TSource> first, ISource<TPipeLine> source)
        {
            _first = first;
            _current = source;
        }

        public IPipeLineBuilder<TSource, TResult> Filter<TResult>(IFilter<TPipeLine, TResult> filter)
        {
            _current.Connect(filter);
            return new BatchPipeLineBuilder<TSource, TResult>(_first, filter);
        }

        public IPipeLine<TSource> Close(IEndPoint<TPipeLine> endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
