using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.PipeLine
{
    public interface ISealedPipeLine<out T> where T : Task
    {
        bool IsConnected { get; }
        T Run();
    }
    public interface ISealedPipeLine : ISealedPipeLine<Task>{}
    
    public interface IBatchPipeline<T> : ISealedPipeLine<T> where T : Task 
    {
        bool IsReady { get; }
    }

    public interface IBatchPipeline : IBatchPipeline<Task>, ISealedPipeLine
    {
        
    }

    public abstract class SealedPipeLine<T> : ISealedPipeLine<T> where T : Task 
    {
        protected readonly IFeeder Feeder;

        protected SealedPipeLine(IFeeder feeder)
        {
            Feeder = feeder;
        }


        public bool IsConnected => Feeder.IsConnected;
        public abstract T Run();
    }

    public abstract class SealedPipeLine : SealedPipeLine<Task>
    {
        protected SealedPipeLine(IFeeder feeder) : base(feeder)
        {
            
        }
    }
}
