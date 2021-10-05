using System.Collections.Immutable;
using Pipemania.Core.Interfaces;

namespace Pipemania.PipeLine
{
    public abstract class PipeLineBuilder<TSource>
    {
        protected readonly IFeeder Feeder;
        protected readonly ISource<TSource> Source;
        protected readonly IImmutableList<INode> PipeLine;

        protected PipeLineBuilder(Feeder<TSource> feeder)
        {
            Feeder = feeder;
            Source = feeder;
            PipeLine = ImmutableList.Create<INode>(Feeder);
        }
        
        protected PipeLineBuilder(IFeeder feeder, ISource<TSource> source, IImmutableList<INode> pipeLine)
        {
            Feeder = feeder;
            Source = source;
            PipeLine = pipeLine;
        }
    }
}